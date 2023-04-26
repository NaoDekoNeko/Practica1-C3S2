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
        }
        private Tablero tablero;
        private Juego juego;
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
            for (int i = 0; i < tablero.Tamanio; i++)
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
                return new JuegoSimple(tablero);
            }
            else
            {
                return new JuegoGeneral(tablero);
            }
        }
        private void ShowGameStatus()
        {
            switch(tablero.EstadoDeJuego)
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
            dataGridView1.DataSource = ConvertToDataTable(tablero.Grid);
            //Hace que al principio el color de la fuente 
            //sea blanca para que coincida con el color de fondo
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            //Segundo resize del DataGridView
            for (int i = 0; i < tablero.Tamanio; i++)
            {
                dataGridView1.RowTemplate.Height = dataGridView1.Height / ((int)numericUpDown1.Value + 1);
            }
            //Que ninguna celda empiece seleccionada
            dataGridView1.CurrentCell = null;
        }
        private void ClickeoGrid(object sender, DataGridViewCellEventArgs e)
        {
            Tablero.Jugador turno = tablero.Turno;
            Tablero.Cell ficha = (turno == Tablero.Jugador.AZUL) ?
                (radioButton3.Checked == true ?
                Tablero.Cell.S : Tablero.Cell.O) :
                (radioButton1.Checked == true ?
                Tablero.Cell.S : Tablero.Cell.O);
            juego.MakeMove(e.RowIndex, e.ColumnIndex, ficha);
            if (tablero.ValidMove)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ficha;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor =
                (turno == Tablero.Jugador.AZUL) ? Color.Blue : Color.Red;
            }
            dataGridView1.CurrentCell = null;
            ShowGameStatus();
            ShowTurn();
        }
        // Restricción: no se puede cambiar el tamaño ni modo de juego durante una partida
        private void ReIniciarJuego()
        {
            // Al ir cambiando  el "numericUpDown1" se va cambiando el tamaño del tablero
            tablero = new Tablero((int)numericUpDown1.Value);
            if (juego != null)
                GC.SuppressFinalize(juego);
            juego = GameSelector();
            CargarAlDataGrid();
            ShowGameStatus();
            ShowTurn();
            dataGridView1.CurrentCell = null;
        }

        private void NuevaPartida(object sender, EventArgs e)
        {
            ReIniciarJuego();
        }
        private void ShowTurn()
        {
            label3.Text = tablero.Turno.ToString();
            label3.ForeColor = tablero.Turno == Tablero.Jugador.AZUL ? Color.Blue : Color.Red;
        }
    }
}
