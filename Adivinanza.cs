using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoAdivinanza
{
    public partial class Adivinanza : Form
    {



        /// <summary>
        /// Al iniciar el Form llamado adivinanza se inicializa el metodo NumeroAzar(), El cual nos genera el numero al empezar 
        /// el juego y ademas las imagenes que no deseamos que se nos muestren en el inicio 
        /// </summary>
        public Adivinanza()
        {
            InitializeComponent();
            NumeroAzar();
            pictureBox1.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;    
        }


        #region Variables e Instanciamento 
        // instanciamiento del objeto que nos va permitir llamar todos los metodos de la clase ClsNumerosAdivinanza
        ClsNumerosAdivinaza Onumeros = new ClsNumerosAdivinaza();


        // Creacion de variables: 1 Ramdon para generar numero aleatorio, Bandera y las variables de los numeros
        //del usuario y el numero adivinanza 

        Random rnd = new Random();
        bool bandera = false;
        int intentos = 0;
        int NumeroAdivinanza = 0;
        int NUsuario = 0;
        #endregion





        #region Metodos de generacion de numero al azar y comparacion de numero de usuario
        /// <summary>
        /// Este metodo genera el numero random, mediante la asigancion del valor de la 
        /// instancia a la variable NumeroAdivinanza
        /// </summary>
        public void NumeroAzar()
        {

            NumeroAdivinanza = Onumeros.NumeroAdivinanza = rnd.Next(1, 100);

        }


        /// <summary>
        /// Este metodo toma el numero ingresado por el usuario y lo compara con el numero generado 
        /// en el random
        /// </summary>
        public void IngresoNumero()
        {
            try
            {
                NUsuario = Onumeros.NumeroUsuario;

                do
                {

                    NUsuario = Convert.ToInt32(TxtNumero.Text);

                    //LBL PARA PRUEBAS EN ESTE SE MUESTRA EL NUMERO PARA ADIVINAR
                    // lblResultado.Text = NumeroAdivinanza.ToString();    

                    if (NUsuario == NumeroAdivinanza)
                    {
                        lblResultado.Text = NumeroAdivinanza.ToString();
                        MessageBox.Show("Felicidades Has acertado ");
                        NumeroAzar();
                        bandera = true;

                        DialogResult resultado2 = MessageBox.Show("Deseas continuar jugando?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado2 == DialogResult.Yes)
                        {
                            NumeroAzar();
                            intentos = -1;
                        }
                        else
                        {
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Numero Incorrecto");


                        if (NUsuario > NumeroAdivinanza)
                        {
                            MessageBox.Show("El numero es mayor al adivinar");

                        }
                        else
                        {
                            MessageBox.Show("El numero es inferior al adivinar");

                        }
                        bandera = true;
                    }


                    intentos++;


                    // se muestra mensajes al jugador de acuerdo al numero de intentos
                    if (intentos == 3)
                    {
                        pictureBox4.Visible = true;

                        MessageBox.Show("APROVECHA ES TU ULTIMA OPORTUNIDAD");

                        pictureBox4.Visible = false;
                    }


                    if (intentos == 2)
                    {

                        pictureBox1.Visible = true;

                        MessageBox.Show("APROVECHA LOS 2 INTENTOS RESTANTES");

                        pictureBox1.Visible = false;
                    }



                    if (intentos == 4)
                    {

                        MessageBox.Show("OH NOOO, 'PARECE QUE HAS AGOTADO TUS INTENTOS'");

                        NumeroAzar();
                        intentos = 0;

                        pictureBox3.Visible = true;

                        DialogResult resultado2 = MessageBox.Show("Deseas continuar jugando?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado2 == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            this.Close();
                        }
                        pictureBox3.Visible = false;
                    }








                } while (bandera == false && intentos <= 4);

            }
            catch (Exception)
            {

                MessageBox.Show("POR FAVOR INGRESE UN NUMERO VALIDO DEL 1-6");
            }






        }
        #endregion




        #region Region de Logica de botones
        // se llama el metodo de ingreso al evento click del boton
        private void BtnCalcular_Click(object sender, EventArgs e)
        {

            IngresoNumero();

        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            DialogResult resultado3 = MessageBox.Show("Deseas Reiniciar el Juego?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado3 == DialogResult.Yes)
            {
                NumeroAzar();
                intentos = 0;
                TxtNumero.Text = null;
            }
            else
            {

            }



        }
        #endregion























        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       



    }
}
