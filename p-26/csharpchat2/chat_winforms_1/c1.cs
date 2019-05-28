using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_winforms_1
{
    public partial class c1 : Form
    {  conexion cn = new conexion();
       Client cl = new Client();
        public c1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            

        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            cl.Connect(txt_ip.Text, int.Parse(txt_puerto.Text));
            
        }

        private void btn_listener_Click(object sender, EventArgs e)
        {
            cn.Start();
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            cn.enviar(txt_mensaje.Text);
        }
    }
}
