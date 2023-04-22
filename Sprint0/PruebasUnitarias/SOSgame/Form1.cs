using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //extraemos las coordenadas y las convertimos a double
            double X1 = Convert.ToDouble(textBox1.Text);
            double Y1 = Convert.ToDouble(textBox2.Text);

            //instanciamos las clases  
            var distancia = new Distancia();
            var coordenadas = new Coordenada(X1, Y1);
            var impri = new Imprimir();

            //variable que guarda el resultado en double
            var resultado = distancia.CalcularDistancia(coordenadas);
            //decision de cómo se mostrará (decimales a usar)
            //no se usó if inmediato (condition ? consecuente : alternativa)
            if (checkBox1.Checked)
                textBox5.Text = impri.Impresion(resultado, Convert.ToInt16(numericUpDown1.Value));
            else
                textBox5.Text = impri.Impresion(resultado);
        }
    }
}
