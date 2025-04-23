using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_parcial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                //USUARIO Y CONTRASEÑA
                string usuario = textBoxUsuario.Text;
                string contraseña = textBoxContraseña.Text;

                string UsuarioCorrecto = "123";
                string ContraseñaCorrecta = "456";
                if (usuario == UsuarioCorrecto && contraseña == ContraseñaCorrecta)
                {
                    MessageBox.Show("Bienvenido");
                    Form nuevoFormulario = new Form1();
                    this.Hide();
                    nuevoFormulario.ShowDialog();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }


            }
        }
    }
}
