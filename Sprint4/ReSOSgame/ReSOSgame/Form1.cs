using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReSOSgame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
        }
        private Controller controller;
        
        //Este método convierte un array 2D de cualquier tipo
        //a un DataTable;
        private DataTable ConvertToDataTable<T>(T[,] array)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                table.Columns.Add($"Column{i + 1}", typeof(T));
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }
                table.Rows.Add(row);
            }
            //acá se hará el primer resize del DataGridView
            for (int i = 0; i < controller.Tamanio; i++)
            {
                dataGridView1.RowTemplate.Height = dataGridView1.Height / (int)numericUpDown1.Value;
            }
            return table;
        }
        // Retorna el tipo de juego segun el radio button seleccionado
        private Juego GameSelector()
        {
            if (radioButton5.Checked)
            {

                return new JuegoSimple(controller.Tablero);
            }
            else
            {
                return new JuegoGeneral(controller.Tablero);
            }
        }
        private void ShowGameStatus()
        {
            switch(controller.Tablero.EstadoDeJuego)
            {
                case Tablero.GameState.JUGANDO:
                    label2.Text = "JUGANDO";
                    label2.ForeColor = Color.Black;
                    break;
                case Tablero.GameState.GANOROJO:
                    label2.Text = "GANÓ EL JUGADOR ROJO";
                    label2.ForeColor = Color.Red;
                    break;
                case Tablero.GameState.GANOAZUL:
                    label2.Text = "GANÓ EL JUGADOR AZUL";
                    label2.ForeColor = Color.Blue;
                    break;
                case Tablero.GameState.EMPATE:
                    label2.Text = "EMPATE";
                    label2.ForeColor = Color.Green;
                    break;
            }
            
        }
        //Este método cargará los datos de Grid
        //al DataGridView
        private void CargarAlDataGrid()
        {
            dataGridView1.DataSource = ConvertToDataTable(controller.Tablero.Grid);
            //Hace que al principio el color de la fuente 
            //sea blanca para que coincida con el color de fondo
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            //Segundo resize del DataGridView
            for (int i = 0; i < controller.Tamanio; i++)
            {
                dataGridView1.RowTemplate.Height = dataGridView1.Height / ((int)numericUpDown1.Value + 1);
            }
            //Que ninguna celda empiece seleccionada
            dataGridView1.CurrentCell = null;
        }

        private void AsignarFicha(Player player)
        {
            player.Ficha = (controller.Turno == Tablero.Jugador.JAZUL) ?
                (radioButton3.Checked == true ?
                Tablero.Cell.S : Tablero.Cell.O) :
                (radioButton1.Checked == true ?
                Tablero.Cell.S : Tablero.Cell.O);
        }

        private void ClickeoGrid(object sender, DataGridViewCellEventArgs e)
        {
            Tablero.Jugador turno = controller.Turno; // rellena el turno 
            Player playerActual = controller.CurrentPlayer;
            if(playerActual is Human)
            {
                AsignarFicha(playerActual);
                controller.CurrentPlayer.MakeMove(e.RowIndex, e.ColumnIndex, playerActual.Ficha, controller.Juego);
                if(controller.Tablero.ValidMove && controller.CurrentPlayer is Human)
                {
                    PaintGrid();
                }
                ShowGameStatus();
                ShowTurn();
            }    
        }
        private void PaintGrid()
        {
            dataGridView1.CellValueChanged -= UpdateGrid;
            dataGridView1.Rows[controller.X].Cells[controller.Y].Value = controller.Ficha;
            dataGridView1.Rows[controller.X].Cells[controller.Y].Style.ForeColor =
                (controller.Turno == Tablero.Jugador.JAZUL) ? Color.Blue : Color.Red;
            //Es posible que la asignación de turnos esté fallando aquí
            dataGridView1.CurrentCell = null;
            dataGridView1.CellValueChanged += UpdateGrid;
        }
        // Inicializa el tipo de jugador Azul segun los radiobutton
        private Player BluePlayerSelector()
        {
            if(radioButton10.Checked)
            {
                return new Human(Tablero.Jugador.JAZUL);
            }
            return new Computer(Tablero.Jugador.JAZUL);
        }
        // Inicializa el tipo de jugador Rojo segun los radiobutton
        private Player RedPlayerSelector()
        {
            if (radioButton8.Checked)
            {
                return new Human(Tablero.Jugador.JROJO);
            }
            return new Computer(Tablero.Jugador.JROJO);
            
        }
       
        // Restricción: no se puede cambiar el tamaño ni modo de juego durante una partida
        private void ReIniciarJuego()
        {
            // Al ir cambiando  el "numericUpDown1" se va cambiando el tamaño del tablero
            controller.Tablero = new Tablero((int)numericUpDown1.Value);
            if (controller.Juego != null)
                GC.SuppressFinalize(controller.Juego);
            controller.Juego = GameSelector();
            controller.Player1 = BluePlayerSelector();
            controller.Player2 = RedPlayerSelector();
            controller.InitTurn();
            CargarAlDataGrid();
            ShowGameStatus();
            ShowTurn();
            dataGridView1.CurrentCell = null;
            if(controller.Player1 is Computer && controller.Player2 is Human)
            {
                controller.Player1.MakeMove(0,0,0,controller.Juego); // El player1 que es un Computer hace la primera jugada ,inicializa las coordenadas e inicializa la ficha

            }
        }

        private void NuevaPartida(object sender, EventArgs e)
        {
            ReIniciarJuego();
        }

        private void UpdateGrid(object sender, DataGridViewCellEventArgs e)
        {
            PaintGrid();
        }


        private void ShowTurn()
        {
            label3.Text = controller.Tablero.Turno.ToString();
            label3.ForeColor = controller.Tablero.Turno == Tablero.Jugador.JAZUL ? Color.Blue : Color.Red;
        }
    }
}
