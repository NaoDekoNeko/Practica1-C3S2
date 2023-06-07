using System;
using System.Diagnostics.Contracts;
using System.IO;
using static ReSOSGame.Tablero;

namespace ReSOSGame
{
    public class GameRecorder
    {
        private Tablero Tablero { get; }
        private Juego Juego { get; }
        public string FilePath { get; set; }
        public GameRecorder(Juego juego)
        {
            Tablero = juego.Tablero;
            Juego = juego;
        }

        //va a imprimir en un txt el tablero además de otros elementos
        public void PrintGame()
        {
            string contenido = null;

            Contract.Requires(File.Exists(FilePath),"El archivo de la partida debe existir");
            Contract.Ensures(File.ReadAllText(FilePath).Contains(contenido), "Se agrega la jugada");
            Contract.Ensures(Tablero.EstadoDeJuego != GameState.JUGANDO &&
                             (File.GetAttributes(FilePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly,
                "Archivo de solo lectura cuando acabe la partida");

            contenido += "Turno: ";
            contenido += Tablero.Turno != Jugador.JAZUL ? "Azul\n" : "Rojo\n";
            // Construir el contenido a escribir
            contenido += TableroHelper.GetFormattedBoard(Tablero);
            if (Juego is JuegoGeneral aux)
            {
                contenido += "Puntaje Azul: " + aux.PuntajeAzul + "\n";
                contenido += "Puntaje Rojo: " + aux.PuntajeRojo + "\n";
            }

            contenido += "Estado de juego: ";
            switch (Tablero.EstadoDeJuego)
            {
                case GameState.JUGANDO:
                    contenido += "JUGANDO\n";
                    break;
                case GameState.GANOROJO:
                    contenido += "GANÓ EL JUGADOR ROJO\n";
                    break;
                case GameState.GANOAZUL:
                    contenido += "GANÓ EL JUGADOR AZUL\n";
                    break;
                case GameState.EMPATE:
                    contenido += "EMPATE\n";
                    break;
            }

            if (Tablero.ValidMove)
            {
                //si el archivo ya se hizo de solo lectura porque acabó la partida, hace return
                if (File.GetAttributes(FilePath).HasFlag(FileAttributes.ReadOnly)) return;
                // Añadir contenido al archivo existente o al archivo recién creado
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    sw.Write(contenido);
                }
            }

            if (Tablero.EstadoDeJuego != GameState.JUGANDO)
            {
                //Cuando la partida acabe, hace que el archivo sea de solo lectura
                File.SetAttributes(FilePath, FileAttributes.ReadOnly);
            }
        }

        private static string NewPath()
        {
            return @"C:\Users\Ademar\OneDrive\Desktop\Practica1-C3S2\Sprint5\Registros\game_" + 
                   DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
        }

        //Inicia el grabado de juego
        public void SaveGame()
        {
            FilePath = NewPath();
            // Verificar si el archivo existe
            if (File.Exists(FilePath)) return;
            // Crear el archivo si no existe
            using (File.Create(FilePath))
            {
                // El archivo se crea y se cierra automáticamente
            }
        }
    }
}