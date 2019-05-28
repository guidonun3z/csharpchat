using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace chat_winforms_1
{
    public partial class Form1 : Form
    {
        conexion cn = new conexion();
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Thread newThread = new Thread();
            //newThread.Start(10);
           // cn.Start(int.Parse(txt_lis_port.Text));
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {

            cn.Connect_to(txt_ip.Text, int.Parse(txt_puerto.Text));

           // Thread t = new Thread(()=> cn.Connect_to(txt_ip.Text, int.Parse(txt_puerto.Text)) );
            //t.Start();
            
        }

        private void btn_listener_Click(object sender, EventArgs e)
        {
            cn.Start(int.Parse(txt_lis_port.Text));

            /*Thread t = new Thread(() => cn.Start(int.Parse(txt_lis_port.Text)));
            t.Start();*/
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            string sms_actual= cn.enviar(txt_mensaje.Text) + Environment.NewLine;
            txt_ml_mensajes.Text = txt_ml_mensajes.Text + sms_actual;
        }
    }
}
