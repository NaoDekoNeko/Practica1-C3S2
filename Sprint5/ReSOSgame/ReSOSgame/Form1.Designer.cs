using System.Windows.Forms;

namespace ReSOSgame
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.FichasRojo = new System.Windows.Forms.GroupBox();
            this.FichaO_PlayerRed = new System.Windows.Forms.RadioButton();
            this.FichaS_PlayerRed = new System.Windows.Forms.RadioButton();
            this.FichasAzul = new System.Windows.Forms.GroupBox();
            this.FichaO_PlayerBlue = new System.Windows.Forms.RadioButton();
            this.FichaS_PlayerBlue = new System.Windows.Forms.RadioButton();
            this.ModoJuego = new System.Windows.Forms.GroupBox();
            this.JGeneral = new System.Windows.Forms.RadioButton();
            this.JSimple = new System.Windows.Forms.RadioButton();
            this.BoardSizeSel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EstadoJuego = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Turno = new System.Windows.Forms.Label();
            this.TipoRojo = new System.Windows.Forms.GroupBox();
            this.RComputadora = new System.Windows.Forms.RadioButton();
            this.RHumano = new System.Windows.Forms.RadioButton();
            this.TipoAzul = new System.Windows.Forms.GroupBox();
            this.AComputadora = new System.Windows.Forms.RadioButton();
            this.AHumano = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.Puntaje_Rojo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Puntaje_Azul = new System.Windows.Forms.Label();
            this.Record = new System.Windows.Forms.CheckBox();
            this.FichasRojo.SuspendLayout();
            this.FichasAzul.SuspendLayout();
            this.ModoJuego.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardSizeSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TipoRojo.SuspendLayout();
            this.TipoAzul.SuspendLayout();
            this.SuspendLayout();
            // 
            // FichasRojo
            // 
            this.FichasRojo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FichasRojo.Controls.Add(this.FichaO_PlayerRed);
            this.FichasRojo.Controls.Add(this.FichaS_PlayerRed);
            this.FichasRojo.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FichasRojo.ForeColor = System.Drawing.Color.Red;
            this.FichasRojo.Location = new System.Drawing.Point(663, 207);
            this.FichasRojo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichasRojo.Name = "FichasRojo";
            this.FichasRojo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichasRojo.Size = new System.Drawing.Size(149, 100);
            this.FichasRojo.TabIndex = 1;
            this.FichasRojo.TabStop = false;
            this.FichasRojo.Text = "Jugador Rojo";
            // 
            // FichaO_PlayerRed
            // 
            this.FichaO_PlayerRed.AutoSize = true;
            this.FichaO_PlayerRed.Location = new System.Drawing.Point(5, 74);
            this.FichaO_PlayerRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichaO_PlayerRed.Name = "FichaO_PlayerRed";
            this.FichaO_PlayerRed.Size = new System.Drawing.Size(45, 27);
            this.FichaO_PlayerRed.TabIndex = 1;
            this.FichaO_PlayerRed.TabStop = true;
            this.FichaO_PlayerRed.Text = "O";
            this.FichaO_PlayerRed.UseVisualStyleBackColor = true;
            // 
            // FichaS_PlayerRed
            // 
            this.FichaS_PlayerRed.AutoSize = true;
            this.FichaS_PlayerRed.Checked = true;
            this.FichaS_PlayerRed.Location = new System.Drawing.Point(5, 30);
            this.FichaS_PlayerRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichaS_PlayerRed.Name = "FichaS_PlayerRed";
            this.FichaS_PlayerRed.Size = new System.Drawing.Size(41, 27);
            this.FichaS_PlayerRed.TabIndex = 0;
            this.FichaS_PlayerRed.TabStop = true;
            this.FichaS_PlayerRed.Text = "S";
            this.FichaS_PlayerRed.UseVisualStyleBackColor = true;
            // 
            // FichasAzul
            // 
            this.FichasAzul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FichasAzul.Controls.Add(this.FichaO_PlayerBlue);
            this.FichasAzul.Controls.Add(this.FichaS_PlayerBlue);
            this.FichasAzul.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FichasAzul.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FichasAzul.Location = new System.Drawing.Point(17, 207);
            this.FichasAzul.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichasAzul.Name = "FichasAzul";
            this.FichasAzul.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichasAzul.Size = new System.Drawing.Size(149, 100);
            this.FichasAzul.TabIndex = 2;
            this.FichasAzul.TabStop = false;
            this.FichasAzul.Text = "Jugador Azul";
            // 
            // FichaO_PlayerBlue
            // 
            this.FichaO_PlayerBlue.AutoSize = true;
            this.FichaO_PlayerBlue.Location = new System.Drawing.Point(5, 74);
            this.FichaO_PlayerBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichaO_PlayerBlue.Name = "FichaO_PlayerBlue";
            this.FichaO_PlayerBlue.Size = new System.Drawing.Size(45, 27);
            this.FichaO_PlayerBlue.TabIndex = 3;
            this.FichaO_PlayerBlue.TabStop = true;
            this.FichaO_PlayerBlue.Text = "O";
            this.FichaO_PlayerBlue.UseVisualStyleBackColor = true;
            // 
            // FichaS_PlayerBlue
            // 
            this.FichaS_PlayerBlue.AutoSize = true;
            this.FichaS_PlayerBlue.Checked = true;
            this.FichaS_PlayerBlue.Location = new System.Drawing.Point(5, 30);
            this.FichaS_PlayerBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FichaS_PlayerBlue.Name = "FichaS_PlayerBlue";
            this.FichaS_PlayerBlue.Size = new System.Drawing.Size(41, 27);
            this.FichaS_PlayerBlue.TabIndex = 2;
            this.FichaS_PlayerBlue.TabStop = true;
            this.FichaS_PlayerBlue.Text = "S";
            this.FichaS_PlayerBlue.UseVisualStyleBackColor = true;
            // 
            // ModoJuego
            // 
            this.ModoJuego.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ModoJuego.Controls.Add(this.JGeneral);
            this.ModoJuego.Controls.Add(this.JSimple);
            this.ModoJuego.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModoJuego.Location = new System.Drawing.Point(12, 27);
            this.ModoJuego.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModoJuego.Name = "ModoJuego";
            this.ModoJuego.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModoJuego.Size = new System.Drawing.Size(149, 80);
            this.ModoJuego.TabIndex = 3;
            this.ModoJuego.TabStop = false;
            this.ModoJuego.Text = "Modo de Juego";
            // 
            // JGeneral
            // 
            this.JGeneral.AutoSize = true;
            this.JGeneral.Location = new System.Drawing.Point(5, 54);
            this.JGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JGeneral.Name = "JGeneral";
            this.JGeneral.Size = new System.Drawing.Size(94, 27);
            this.JGeneral.TabIndex = 4;
            this.JGeneral.TabStop = true;
            this.JGeneral.Text = "General";
            this.JGeneral.UseVisualStyleBackColor = true;
            // 
            // JSimple
            // 
            this.JSimple.AutoSize = true;
            this.JSimple.Checked = true;
            this.JSimple.Location = new System.Drawing.Point(5, 21);
            this.JSimple.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JSimple.Name = "JSimple";
            this.JSimple.Size = new System.Drawing.Size(88, 27);
            this.JSimple.TabIndex = 3;
            this.JSimple.TabStop = true;
            this.JSimple.Text = "Simple";
            this.JSimple.UseVisualStyleBackColor = true;
            // 
            // BoardSizeSel
            // 
            this.BoardSizeSel.Location = new System.Drawing.Point(693, 38);
            this.BoardSizeSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoardSizeSel.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.BoardSizeSel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BoardSizeSel.Name = "BoardSizeSel";
            this.BoardSizeSel.Size = new System.Drawing.Size(60, 22);
            this.BoardSizeSel.TabIndex = 4;
            this.BoardSizeSel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(643, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tamaño del tablero";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(213, 145);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.Height = 300;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(400, 300);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickeoGrid);
            // 
            // EstadoJuego
            // 
            this.EstadoJuego.AutoSize = true;
            this.EstadoJuego.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstadoJuego.Location = new System.Drawing.Point(283, 491);
            this.EstadoJuego.Name = "EstadoJuego";
            this.EstadoJuego.Size = new System.Drawing.Size(0, 23);
            this.EstadoJuego.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(693, 74);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Nueva partida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.NuevaPartida);
            // 
            // Turno
            // 
            this.Turno.AutoSize = true;
            this.Turno.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Turno.Location = new System.Drawing.Point(346, 50);
            this.Turno.Name = "Turno";
            this.Turno.Size = new System.Drawing.Size(0, 23);
            this.Turno.TabIndex = 9;
            // 
            // TipoRojo
            // 
            this.TipoRojo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TipoRojo.Controls.Add(this.RComputadora);
            this.TipoRojo.Controls.Add(this.RHumano);
            this.TipoRojo.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoRojo.ForeColor = System.Drawing.Color.Red;
            this.TipoRojo.Location = new System.Drawing.Point(632, 444);
            this.TipoRojo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipoRojo.Name = "TipoRojo";
            this.TipoRojo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipoRojo.Size = new System.Drawing.Size(180, 100);
            this.TipoRojo.TabIndex = 2;
            this.TipoRojo.TabStop = false;
            this.TipoRojo.Text = "Tipo de oponente";
            // 
            // RComputadora
            // 
            this.RComputadora.AutoSize = true;
            this.RComputadora.Location = new System.Drawing.Point(5, 74);
            this.RComputadora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RComputadora.Name = "RComputadora";
            this.RComputadora.Size = new System.Drawing.Size(142, 27);
            this.RComputadora.TabIndex = 1;
            this.RComputadora.TabStop = true;
            this.RComputadora.Text = "Computadora";
            this.RComputadora.UseVisualStyleBackColor = true;
            // 
            // RHumano
            // 
            this.RHumano.AutoSize = true;
            this.RHumano.Checked = true;
            this.RHumano.Location = new System.Drawing.Point(5, 30);
            this.RHumano.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RHumano.Name = "RHumano";
            this.RHumano.Size = new System.Drawing.Size(100, 27);
            this.RHumano.TabIndex = 0;
            this.RHumano.TabStop = true;
            this.RHumano.Text = "Humano";
            this.RHumano.UseVisualStyleBackColor = true;
            // 
            // TipoAzul
            // 
            this.TipoAzul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TipoAzul.Controls.Add(this.AComputadora);
            this.TipoAzul.Controls.Add(this.AHumano);
            this.TipoAzul.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoAzul.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TipoAzul.Location = new System.Drawing.Point(21, 443);
            this.TipoAzul.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipoAzul.Name = "TipoAzul";
            this.TipoAzul.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TipoAzul.Size = new System.Drawing.Size(180, 100);
            this.TipoAzul.TabIndex = 4;
            this.TipoAzul.TabStop = false;
            this.TipoAzul.Text = "Tipo de oponente";
            // 
            // AComputadora
            // 
            this.AComputadora.AutoSize = true;
            this.AComputadora.Location = new System.Drawing.Point(5, 74);
            this.AComputadora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AComputadora.Name = "AComputadora";
            this.AComputadora.Size = new System.Drawing.Size(142, 27);
            this.AComputadora.TabIndex = 3;
            this.AComputadora.TabStop = true;
            this.AComputadora.Text = "Computadora";
            this.AComputadora.UseVisualStyleBackColor = true;
            // 
            // AHumano
            // 
            this.AHumano.AutoSize = true;
            this.AHumano.Checked = true;
            this.AHumano.Location = new System.Drawing.Point(5, 30);
            this.AHumano.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AHumano.Name = "AHumano";
            this.AHumano.Size = new System.Drawing.Size(100, 27);
            this.AHumano.TabIndex = 2;
            this.AHumano.TabStop = true;
            this.AHumano.Text = "Humano";
            this.AHumano.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(677, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Puntaje";
            // 
            // Puntaje_Rojo
            // 
            this.Puntaje_Rojo.AutoSize = true;
            this.Puntaje_Rojo.Location = new System.Drawing.Point(747, 373);
            this.Puntaje_Rojo.Name = "Puntaje_Rojo";
            this.Puntaje_Rojo.Size = new System.Drawing.Size(14, 16);
            this.Puntaje_Rojo.TabIndex = 11;
            this.Puntaje_Rojo.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightCyan;
            this.label6.Location = new System.Drawing.Point(19, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Puntaje";
            // 
            // Puntaje_Azul
            // 
            this.Puntaje_Azul.AutoSize = true;
            this.Puntaje_Azul.Location = new System.Drawing.Point(96, 373);
            this.Puntaje_Azul.Name = "Puntaje_Azul";
            this.Puntaje_Azul.Size = new System.Drawing.Size(14, 16);
            this.Puntaje_Azul.TabIndex = 13;
            this.Puntaje_Azul.Text = "0";
            // 
            // Record
            // 
            this.Record.AutoSize = true;
            this.Record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(534, 116);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(79, 24);
            this.Record.TabIndex = 14;
            this.Record.Text = "Grabar";
            this.Record.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(824, 551);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.Puntaje_Azul);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Puntaje_Rojo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TipoAzul);
            this.Controls.Add(this.TipoRojo);
            this.Controls.Add(this.Turno);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EstadoJuego);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoardSizeSel);
            this.Controls.Add(this.ModoJuego);
            this.Controls.Add(this.FichasAzul);
            this.Controls.Add(this.FichasRojo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "SOS";
            this.FichasRojo.ResumeLayout(false);
            this.FichasRojo.PerformLayout();
            this.FichasAzul.ResumeLayout(false);
            this.FichasAzul.PerformLayout();
            this.ModoJuego.ResumeLayout(false);
            this.ModoJuego.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardSizeSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TipoRojo.ResumeLayout(false);
            this.TipoRojo.PerformLayout();
            this.TipoAzul.ResumeLayout(false);
            this.TipoAzul.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox FichasRojo;
        private RadioButton FichaO_PlayerRed;
        private RadioButton FichaS_PlayerRed;
        private GroupBox FichasAzul;
        private RadioButton FichaO_PlayerBlue;
        private RadioButton FichaS_PlayerBlue;
        private GroupBox ModoJuego;
        private RadioButton JGeneral;
        private RadioButton JSimple;
        private NumericUpDown BoardSizeSel;
        private Label label1;
        private DataGridView dataGridView1;
        private Label EstadoJuego;
        private Button button1;
        private Label Turno;
        private GroupBox TipoRojo;
        private RadioButton RComputadora;
        private RadioButton RHumano;
        private GroupBox TipoAzul;
        private RadioButton AComputadora;
        private RadioButton AHumano;
        private Label label4;
        private Label Puntaje_Rojo;
        private Label label6;
        private Label Puntaje_Azul;
        private CheckBox Record;
    }
}

