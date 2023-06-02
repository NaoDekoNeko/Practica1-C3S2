using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReSOSgame;

namespace ReSOSGame
{
    public partial class Form1 : Form
    {
        // Inicializa las componente e instancia el objeto controller
        private Controller controller;
        //se tendrá el recorder
        private GameRecorder gameRecorder;
        //private bool actualizarGrid = false;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void StartRecording()
        {
            gameRecorder = new GameRecorder(controller.Juego);
            gameRecorder.SaveGame();
        }

        //Este método convierte un array 2D de cualquier tipo a un DataTable;        
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
                dataGridView1.RowTemplate.Height = dataGridView1.Height / (int)BoardSizeSel.Value;
            }
            return table;
        }
        // Retorna el tipo de juego segun el radio button seleccionado
        private Juego GameSelector()
        {
            if (JSimple.Checked)
            {
                return new JuegoSimple(controller.Tablero);
            }
            return new JuegoGeneral(controller.Tablero);
        }
        private void ShowGameStatus()
        {
            switch (controller.Tablero.EstadoDeJuego)
            {
                case Tablero.GameState.JUGANDO:
                    EstadoJuego.Text = "JUGANDO";
                    EstadoJuego.ForeColor = Color.Black;
                    break;
                case Tablero.GameState.GANOROJO:
                    EstadoJuego.Text = "GANÓ EL JUGADOR ROJO";
                    EstadoJuego.ForeColor = Color.Red;
                    break;
                case Tablero.GameState.GANOAZUL:
                    EstadoJuego.Text = "GANÓ EL JUGADOR AZUL";
                    EstadoJuego.ForeColor = Color.Blue;
                    break;
                case Tablero.GameState.EMPATE:
                    EstadoJuego.Text = "EMPATE";
                    EstadoJuego.ForeColor = Color.Green;
                    break;
            }
            EnableSettings();
        }

        //Este método cargará los datos de Grid al DataGridView        
        private void CargarAlDataGrid()
        {
            dataGridView1.DataSource = ConvertToDataTable(controller.Tablero.Grid);
            //Hace que al principio el color de la fuente 
            //sea blanca para que coincida con el color de fondo
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            //Segundo resize del DataGridView
            for (int i = 0; i < controller.Tamanio; i++)
            {
                dataGridView1.RowTemplate.Height = dataGridView1.Height / ((int)BoardSizeSel.Value + 1);
            }
            //Que ninguna celda empiece seleccionada
            dataGridView1.CurrentCell = null;
        }
        //Este metodo asigna la ficha correspondiente al atributo Ficha del player al que se le pasa como parametro de acuerdo con los radio button
        private void AsignarFicha(Player player)
        {
            player.Ficha = (controller.Turno == Tablero.Jugador.JAZUL) ?
                (FichaS_PlayerBlue.Checked ? Tablero.Cell.S : Tablero.Cell.O) : (FichaS_PlayerRed.Checked ? Tablero.Cell.S : Tablero.Cell.O);
        }
        //Este metodo pinta y coloca la ficha de la casilla en el DatagridView 
        private void PaintGrid()
        {
            if (controller.X < 0 || controller.X >= controller.Tablero.Tamanio ||
                controller.Y < 0 || controller.Y >= controller.Tablero.Tamanio) return;
            // Desactiva la escucha para el update y no entre de nuevo a la funcion que captura el evento de updategrid
            dataGridView1.CellValueChanged -= UpdateGrid;
            controller.Tablero[controller.X, controller.Y] = controller.Ficha;
            dataGridView1.Rows[controller.X].Cells[controller.Y].Value = controller.Ficha;


            // Mientras se siga jugando (Estado de juego == JUGANDO) Va pintar el valor del datagrid
            if (controller.Tablero.EstadoDeJuego == Tablero.GameState.JUGANDO)
                dataGridView1.Rows[controller.X].Cells[controller.Y].Style.ForeColor =
                    (controller.Turno == Tablero.Jugador.JROJO) ? Color.Blue : Color.Red;
            else
                dataGridView1.Rows[controller.X].Cells[controller.Y].Style.ForeColor =
                    (controller.Turno == Tablero.Jugador.JROJO) ? Color.Red : Color.Blue;
            //Es posible que la asignación de turnos esté fallando aquí
            dataGridView1.CurrentCell = null; // Cuando se ahce click en el data grid ya no se sombreea azul
            dataGridView1.CellValueChanged += UpdateGrid; // Se vuelve a activar al escucha a este updategrid
            UpdateScore();
            if (Record.Checked)
                gameRecorder.PrintGame();
        }

        //Este metodo escucha cuando se clikea en la casilla de una Datagrid
        private void ClickeoGrid(object sender, DataGridViewCellEventArgs e)
        {
            // Se crean variables temporales para turno {JAZUL,JROJO} y player (Human o Computer)
            Tablero.Jugador turno = controller.Turno; // rellena el turno 
            Player playerActual = controller.CurrentPlayer; // variable que alamcena el jugador actual
            if (playerActual is Human)
            {
                AsignarFicha(playerActual); // rellena el valor de ficha en palyerActual segun los radio button
                controller.CurrentPlayer.MakeMove(e.RowIndex, e.ColumnIndex, playerActual.Ficha, controller.Juego);
                if (controller.Tablero.ValidMove && controller.CurrentPlayer is Human)
                {
                    PaintGrid();
                }
                ShowGameStatus();
                ShowTurn();
                controller.ChangeTurn();
                UpdateScore();
            }

            if (!(controller.CurrentPlayer is Computer)) return;
            controller.CurrentPlayer.MakeMove(0, 0, 0, controller.Juego); // Realiza el movimiento del jugador de tipo Computer
            PaintGrid();
            ShowGameStatus();
            ShowTurn();
            controller.ChangeTurn();
            UpdateScore();
        }

        // Inicializa el tipo de jugador Azul segun los radiobutton
        private Player BluePlayerSelector()
        {
            if (AHumano.Checked)
            {
                return new Human(Tablero.Jugador.JAZUL);
            }
            return new Computer(Tablero.Jugador.JAZUL);
        }
        // Inicializa el tipo de jugador Rojo segun los radiobutton
        private Player RedPlayerSelector()
        {
            if (RHumano.Checked)
            {
                return new Human(Tablero.Jugador.JROJO);
            }
            return new Computer(Tablero.Jugador.JROJO);

        }

        // Restricción: no se puede cambiar el tamaño ni modo de juego durante una partida
        private void ReIniciarJuego()
        {
            // Al ir cambiando  el "numericUpDown1" se va cambiando el tamaño del tablero
            controller.Tablero = new Tablero((int)BoardSizeSel.Value);
            if (controller.Juego != null)
                GC.SuppressFinalize(controller.Juego);
            controller.Juego = GameSelector(); // Verifica los radio button y retorna el tipo de juego seleccionado
            controller.Player1 = BluePlayerSelector(); // Verrifica el radio button y se asigna como jugador azul al primer player
            controller.Player2 = RedPlayerSelector(); // Verrifica el radio button y se asigna como jugador rojo al segundo player
            controller.InitTurn(); // Inicializa el CurrentPlayer como palyer1 , es decir el player1 empieza el juego
            if (Record.Checked)
            {
                StartRecording();
            }
            CargarAlDataGrid(); // Carga los datos al dataGrid
            ShowGameStatus(); // muestra en un label el estado del juego
            ShowTurn(); // muetra en un label el turno
            dataGridView1.CurrentCell = null; // Se desaparece que este sombreado azul en el datagrid
            switch (controller.Player1)
            {
                case Computer _ when controller.Player2 is Human:
                    controller.CurrentPlayer.MakeMove(0, 0, 0, controller.Juego); // Realiza el movimiento del jugador de tipo Computer
                    PaintGrid();
                    ShowGameStatus();
                    ShowTurn();
                    controller.ChangeTurn();
                    UpdateScore();
                    break;
                case Computer _ when controller.Player2 is Computer:
                    StartComputerVsComputerGame();
                    break;
            }
            EnableSettings();
        }
        private void StartComputerVsComputerGame()
        {
            // Desactiva los controles que no se deben modificar durante el juego
            //numericUpDown1.Enabled = false;
            

            // Ciclo recursivo para que los jugadores computadoras realicen sus movimientos automáticamente
            PerformComputerMove();
        }
        private void PerformComputerMove()
        {
            if (controller.CurrentPlayer is Computer)
            {
                Invoke((MethodInvoker)delegate
                {
                    controller.CurrentPlayer.MakeMove(0, 0, 0, controller.Juego);
                    PaintGrid();
                    ShowGameStatus();
                    ShowTurn();
                    controller.ChangeTurn();
                    UpdateScore();
                });

                // Verifica si el juego ha terminado
                if (controller.Tablero.EstadoDeJuego == 0)
                {
                    // Espera un breve período de tiempo antes de realizar el siguiente movimiento del jugador computadora
                    // Esto evita que los movimientos se realicen instantáneamente y permite visualizarlos
                    int delayInMilliseconds = 1000; // Ajusta el tiempo de espera según tus necesidades
                    Task.Delay(delayInMilliseconds).ContinueWith(_ =>
                    {
                        PerformComputerMove(); // Realiza el siguiente movimiento del jugador computadora
                    });
                }
                else
                {
                    EndComputerVsComputerGame(); // Finaliza el juego entre las dos computadoras
                }
            }
        }
        private void EndComputerVsComputerGame()
        {
            // Realiza cualquier acción necesaria al finalizar el juego entre las dos computadoras
        }
        //Este metodo llama a la funcion reiniciarJuego
        private void NuevaPartida(object sender, EventArgs e)
        {
            
            ReIniciarJuego();
        }

        private void UpdateGrid(object sender, DataGridViewCellEventArgs e)
        {
                      
        }

        //Este metodo muestra el turno en la interfaz grafica a traves del label : "Turno" y lo pinta segun el jugador actual
        private void ShowTurn()
        {
            Turno.Text = controller.Tablero.Turno == 0 ? "JUGADOR AZUL" : "JUGADOR ROJO";
            Turno.ForeColor = controller.Tablero.Turno == Tablero.Jugador.JAZUL ? Color.Blue : Color.Red;
        }

        private void UpdateScore()
        {
            //si el tipo de juego es general, entonces se asignará una variable aux de tipo JuegoGeneral
            //para que pueda acceder a las propiedades PuntajeAzul y PuntajeRojo
            if (!(controller.Juego is JuegoGeneral aux)) return;
            Puntaje_Azul.Text = aux.PuntajeAzul.ToString();
            Puntaje_Rojo.Text = aux.PuntajeRojo.ToString();
        }
        private void EnableSettings()
        {
            // Cambio de ajustes
            // Si el estado de juego es "JUGANDO", se deshabilitan
            if (controller.Tablero.EstadoDeJuego == Tablero.GameState.JUGANDO)
            {
                Record.Enabled = false; 
                ModoJuego.Enabled = false;
                TipoAzul.Enabled = false;
                TipoRojo.Enabled = false;
                BoardSizeSel.Enabled = false;
                return;
            }
            // Si el estado de juego no es "JUGANDO", se habilitan

            Record.Enabled = true;
            ModoJuego.Enabled = true;
            TipoAzul.Enabled = true;
            TipoRojo.Enabled = true;
            BoardSizeSel.Enabled = true;
        }
    }
}
