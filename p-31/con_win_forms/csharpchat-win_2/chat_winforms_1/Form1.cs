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

        public string SetText
        {
            get { return txt_ml_mensajes.Text; }
            set { txt_ml_mensajes.Text = value; }
        }

        public static Form1 _Form1;
        public Form1()
        {
            InitializeComponent();
            _Form1 = this;
        }
        public void update(string message)
        {
            txt_ml_mensajes.Text = message;
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

            string mensaje;
            do
            {

                mensaje = txt_mensaje.Text + Environment.NewLine;
                txt_ml_mensajes.Text = txt_ml_mensajes.Text + mensaje;
                streamWriter.WriteLine(mensaje);
                streamWriter.Flush();

            } while (socketcliente.Connected);
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

        static public void StarClient(string ip, int port)
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
            string mensaje;
            do
            {
                /*new Thread(() =>
                {*/
                    mensaje = streamReader.ReadLine();
                    //mensaje = mensaje + Environment.NewLine;
                    // txt_ml_mensajes.Text = txt_ml_mensajes.Text + mensaje;
                    form.txt_ml_mensajes.Text = form.txt_ml_mensajes.Text + mensaje;


                    Form1._Form1.update(mensaje);
                   
                    MessageBox.Show(mensaje);
                //}).Start();


            } while (socketservidor.Connected);
        }
        public void actualiza_chat(Form1 form)
        {
            txt_ml_mensajes.Text = form.txt_ml_mensajes.Text; 
        }

    }
}
