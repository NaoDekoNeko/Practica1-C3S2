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
            juego = GameSelector();
        }
        public readonly static int CANVAS_WIDTH = 400;
        public readonly static int CANVAS_HEIGHT = 400;
        public readonly static int GRID_WIDTH = 4;
        public readonly static int GRID_WIDTH_HALF = GRID_WIDTH / 2;
        public readonly static int X = 180;
        public readonly static int Y = 60;
        private GameBoardCanvas gameBoardCanvas;
        private Tablero tablero;
        private Juego juego;
        private void SetContentPane()
        {
            gameBoardCanvas = new GameBoardCanvas(tablero);
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
        class GameBoardCanvas : Panel
        {
            private readonly Juego juego;
            private readonly Tablero tablero;
            public int CELL_SIZE;
            public int CELL_PADDING;
            public static int SYMBOL_SIZE = 20;
            public GameBoardCanvas(Tablero tablero)
            {
                this.tablero = tablero;
                MouseClick += new MouseEventHandler(Clickeo);
            }

            private void Clickeo(object sender, MouseEventArgs e)
            {
                CELL_SIZE = CANVAS_HEIGHT / (tablero.Tamanio+1);
                CELL_PADDING = CELL_SIZE/6;
                if (tablero.EstadoDeJuego == "JUGANDO")
                {
                    int rowSelected = e.Y / CELL_SIZE;
                    int colSelected = e.X / CELL_SIZE;
                    tablero.MakeMove(rowSelected, colSelected, tablero.Ficha);
                }
                else
                {
                    tablero.InitBoard();
                }
                Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                DrawGrid(g,tablero.Tamanio,tablero.Tamanio,GRID_WIDTH, Color.Black);
                DrawBoard(g);
            }
            // Delinean lineas horizontales y verticales del tablero
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
            private void DrawBoard(Graphics g)
            {
                Pen pen;
                for (int row =0;row<tablero.Tamanio;row++)
                {
                    for(int col=0;col<tablero.Tamanio;col++)
                    {

                        int x1 = col * CELL_SIZE;
                        int y1 = row * CELL_SIZE;
                        
                        if(tablero.GetCell(row,col) == Tablero.Cell.S)
                        {
                            if (tablero.Jugador == "Azul")
                            {
                                pen = new Pen(Color.Blue, 5);
                            }
                            else
                            {
                                pen = new Pen(Color.Red, 5);
                            }
                            /*
                            Point[] points = new Point[]
                            {
                                new Point(2+x1, 12+y1),
                                new Point(7+x1, 5+y1),
                                new Point(17 + x1, 20 + y1),
                                new Point(22 + x1, 12 + y1)
                            };
                            int centerX = (points[1].X + points[2].X) / 2;
                            //int offsetY = CANVAS_HEIGHT / 2;
                            points[0].X = centerX - ((points[3].X - centerX) / 2);
                            g.DrawCurve(pen, points);
                            */
                            g.DrawEllipse(pen, x1, y1, SYMBOL_SIZE / 2, SYMBOL_SIZE / 2);
                        }
                        else if(tablero.GetCell(row, col) == Tablero.Cell.O)
                        {
                            if (tablero.Jugador == "Azul")
                            {
                                pen = new Pen(Color.Blue, 5);
                            }
                            else
                            {
                                pen = new Pen(Color.Red, 5);
                            }
                            g.DrawEllipse(pen,x1,y1,SYMBOL_SIZE/2,SYMBOL_SIZE/2);
                        }
                    }
                }
            }
        }
        // Al ir cambiando  el "numericUpDown1" se va cambiando el tamaño del tablero
        // Problemas: cuando se cambie de tamaño de juego se tendra que tener en
        // cuenta el tipo de juego selecccionado con anterioridad , no se pondra cambiar luego de cambiar el tamaño.
        private void SeleccionarTamanioTablero(object sender, EventArgs e)
        {
            tablero = new Tablero((int)numericUpDown1.Value); // Se crea un nuevo tablero
            SetContentPane();// Dibuja el tablero
            juego = GameSelector(); // Se inicializa el juego segun el tipo de Juego
            
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
