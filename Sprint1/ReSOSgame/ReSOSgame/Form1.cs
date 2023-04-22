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
            SetContentPane();
        }
        public readonly static int CANVAS_WIDTH = 400;
        public readonly static int CANVAS_HEIGHT = 400;
        public readonly static int GRID_WIDTH = 4;
        public readonly static int GRID_WIDTH_HALF = GRID_WIDTH / 2;
        public readonly static int X = 180;
        public readonly static int Y = 60;
        private GameBoardCanvas gameBoardCanvas;
        private Tablero tablero; //= new Tablero(1);
        private void SetContentPane()
        {
            gameBoardCanvas = new GameBoardCanvas((int)numericUpDown1.Value);
            if(panel1.Controls.OfType<GameBoardCanvas>()==null)
                panel1.Controls.Add(gameBoardCanvas);
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(gameBoardCanvas);
            }
            gameBoardCanvas.Dock = DockStyle.Fill;
            gameBoardCanvas.Location = new Point((panel1.Width-gameBoardCanvas.Width)/2,
                (panel1.Height-gameBoardCanvas.Height)/2);
        }
        public Tablero Tablero { get { return tablero; } }
        class GameBoardCanvas : Panel
        {
            private readonly int tamanio;

            public GameBoardCanvas(int tamanio)
            {
                this.tamanio = tamanio;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                DrawGrid(g,tamanio,tamanio,GRID_WIDTH, Color.Black);
            }
            private void DrawGrid(Graphics g, int numRows, int numCols, int lineWidth, Color lineColor)
            {
                // Calcular el ancho y alto de cada celda de la grid
                int cellWidth = ClientSize.Width / numCols;
                int cellHeight = ClientSize.Height / numRows;

                // Dibujar las líneas horizontales
                for (int row = 0; row <= numRows; row++)
                {
                    int y = row * cellHeight;
                    g.DrawLine(new Pen(lineColor, lineWidth), 0, y, ClientSize.Width, y);
                }

                // Dibujar las líneas verticales
                for (int col = 0; col <= numCols; col++)
                {
                    int x = col * cellWidth;
                    g.DrawLine(new Pen(lineColor, lineWidth), x, 0, x, ClientSize.Height);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tablero = new Tablero((int)numericUpDown1.Value);
            SetContentPane();            
        }
    }
}
