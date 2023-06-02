using System;
using System.IO;
using ReSOSGame;

namespace ReSOSgame
{
    public class GameRecorder
    {
        private Tablero Tablero { get; }
        private Tablero.Jugador Turno { get; }
        private Juego Juego { get; }
        public string FilePath { get; set; }
        public GameRecorder(Juego juego)
        {
            Tablero = juego.Tablero;
            Juego = juego;
            Turno = Tablero.Turno;
        }

        public void PrintGame()
        {
            //const string filePath = "game.txt";
            string contenido = "Turno: ";
            contenido += Turno == Tablero.Jugador.JAZUL ? "Azul\n" : "Rojo\n";
            // Construir el contenido a escribir
            contenido += "-------\n";
            for (var row = 0; row < Tablero.Tamanio; row++)
            {
                for (var column = 0; column < Tablero.Tamanio; column++)
                {
                    contenido += "|" + Symbol(Tablero[row, column]);
                }
                contenido += "|\n";
            }
            contenido += "-------\n";
            if (Juego is JuegoGeneral aux)
            {
                contenido += "Puntaje Azul: " + aux.PuntajeAzul + "\n";
                contenido += "Puntaje Rojo: " + aux.PuntajeRojo + "\n";
            }

            contenido += "Estado de juego: ";
            switch (Tablero.EstadoDeJuego)
            {
                case Tablero.GameState.JUGANDO:
                    contenido += "JUGANDO\n";
                    break;
                case Tablero.GameState.GANOROJO:
                    contenido += "GANÓ EL JUGADOR ROJO\n";
                    break;
                case Tablero.GameState.GANOAZUL:
                    contenido += "GANÓ EL JUGADOR AZUL\n";
                    break;
                case Tablero.GameState.EMPATE:
                    contenido += "EMPATE\n";
                    break;
            }

            // Verificar si el archivo existe
            if (!File.Exists(FilePath))
            {
                // si no existe, regresa
                return;
            }


            if (Tablero.ValidMove)
            {
                //Cuando se intente escribir en un archivo que es de solo lectura, no hará nada
                //caso contrario, agregará el contenido
                try
                {
                    // Añadir contenido al archivo existente o al archivo recién creado
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.Write(contenido);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    return;
                }
                catch (Exception)
                {
                    return;
                }
            }

            if (Tablero.EstadoDeJuego != Tablero.GameState.JUGANDO)
            {
                //Cuando la partida acabe, hace que el archivo sea de solo lectura
                File.SetAttributes(FilePath, FileAttributes.ReadOnly);
            }
        }

        private static string Symbol(Tablero.Cell a)
        {
            switch (a)
            {
                case Tablero.Cell.S:
                    return "S";
                case Tablero.Cell.O:
                    return "O";
                case Tablero.Cell.VACIA:
                case Tablero.Cell.INVALIDA:
                default:
                    return " ";
            }
        }

        private string ObtenerRutaNuevoArchivo()
        {
            return @"C:\Users\Ademar\OneDrive\Desktop\Practica1-C3S2\Sprint5\Registros\game_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
        }

        public void SaveGame()
        {
            FilePath = ObtenerRutaNuevoArchivo();
            // Verificar si el archivo existe
            if (!File.Exists(FilePath))
            {
                // Crear el archivo si no existe
                using (File.Create(FilePath))
                {
                    // El archivo se crea y se cierra automáticamente
                }
            }
            PrintGame();
        }
    }
}
