using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;



namespace chat_winforms_1
{

    public partial class Form1 : Form
    {
       
        static TcpClient socketcliente;
        static string mensaje;
        private delegate void DELEGATE();
        public Form1()
        {
            InitializeComponent();
     
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {    
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            Thread cliente = new Thread(()=>StarClient(txt_ip.Text,int.Parse(txt_puerto.Text)));
            cliente.Start();
        }

        private void btn_listener_Click(object sender, EventArgs e)
        {
            Thread servidor = new Thread(() => StarService(int.Parse(txt_lis_port.Text)));
            servidor.Start();
         

        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            NetworkStream networkStream = socketcliente.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);

            txt_ml_mensajes.Text = txt_ml_mensajes.Text+ txt_alias.Text + " : " + txt_mensaje.Text + Environment.NewLine;
            streamWriter.WriteLine(txt_alias.Text + " : "+txt_mensaje.Text);
            streamWriter.Flush();
            txt_mensaje.Clear();
        }

        /*Funciones*/

        static public void StarService(int port)
        {
            IPAddress ipaddress = IPAddress.Parse("192.168.1.5");
            TcpListener socket = new TcpListener(ipaddress, port);
            socket.Start();

            MessageBox.Show("esperando al cliente");
            socketcliente = socket.AcceptTcpClient();

            if (socketcliente.Connected)
                MessageBox.Show("cliente conectado");
        }

        public void StarClient(string ip, int port)
        {
            Form1 form = new Form1();

            //Thread.Sleep(10000);
            TcpClient socketservidor;

            socketservidor = new TcpClient(ip, port);
            if (socketservidor.Connected)
                MessageBox.Show("listo");
            else
                MessageBox.Show("no se pudo conectar");
            
            NetworkStream networkStream = socketservidor.GetStream();
            StreamReader streamReader = new StreamReader(networkStream);
            
            do
            {
                /*new Thread(() =>
                {*/
                mensaje = streamReader.ReadLine();
                Delegate del = new DELEGATE(actualizar_chat);
                this.Invoke(del);
                //}).Start();

            } while (socketservidor.Connected);
        }
        private void actualizar_chat()
        {
            mensaje = mensaje + Environment.NewLine;
            txt_ml_mensajes.Text = txt_ml_mensajes.Text = txt_ml_mensajes.Text + mensaje; ;
        }
     

    }
}
