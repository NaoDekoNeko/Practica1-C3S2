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
            tablero = new Tablero((int)numericUpDown1.Value);
            ReIniciarJuego();
        }
        private Tablero tablero;
        private Juego juego;
       // Al ir cambiando  el "numericUpDown1" se va cambiando el tamaño del tablero
        // Problemas: cuando se cambie de tamaño de juego se tendra que tener en
        // cuenta el tipo de juego selecccionado con anterioridad , no se pondra cambiar luego de cambiar el tamaño.
        private void SeleccionarTamanioTablero(object sender, EventArgs e)
        {
            tablero = new Tablero((int)numericUpDown1.Value); // Se crea un nuevo tablero
            ReIniciarJuego();
        }
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
            return table;
        }
        // Retorna el tipo de juego segun el radio button seleccionado
        private Juego GameSelector()
        {
            if(radioButton5.Checked)
            {
                return new JuegoSimple(tablero);
            }
            else
            {
                return new JuegoGeneral(tablero);
            }
        }
        private void CargarAlDataGrid()
        {
            dataGridView1.DataSource = ConvertToDataTable(tablero.Grid);
        }
        private void ClickeoGrid(object sender, DataGridViewCellEventArgs e)
        {
            Tablero.Jugador turno = tablero.Turno;
            Tablero.Cell ficha = (turno == Tablero.Jugador.AZUL) ? (radioButton3.Checked == true ? Tablero.Cell.S:
                Tablero.Cell.O):
                (radioButton1.Checked == true ? Tablero.Cell.S:Tablero.Cell.O);
            tablero.MakeMove(e.RowIndex,e.ColumnIndex,ficha);
            CargarAlDataGrid();
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = 
                (turno!=Tablero.Jugador.AZUL)?Color.Blue:Color.Red;
        }
        private void ReIniciarJuego()
        { 
            if(juego!=null)
                GC.SuppressFinalize(juego);
            juego = GameSelector();
            CargarAlDataGrid();
        }
    }
}
