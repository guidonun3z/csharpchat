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

      static TcpClient socketForClient;
      static TcpClient socketForServer;
        static String t;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
               
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            conectar_con(txt_ip.Text, int.Parse(txt_puerto.Text));          
        }

        private void btn_listener_Click(object sender, EventArgs e)
        {
            Start(int.Parse(txt_lis_port.Text));
        
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
           string sms_actual= enviar(txt_mensaje.Text) + Environment.NewLine;
            txt_ml_mensajes.Text = txt_ml_mensajes.Text + sms_actual;
            
        }


        /**Funciones**/
        static public void Start(int port)
        {

            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ipaddress, port);
            tcpListener.Start();

            MessageBox.Show("esperando al cliente");
            socketForClient = tcpListener.AcceptTcpClient();

            if (socketForClient.Connected)
            {
                MessageBox.Show("Cliente conectado.");

                /*string mensaje;
                while (true)
                {
                    mensaje = Console.ReadLine();
                    enviar(mensaje);
                }*/
            }
            else
            { MessageBox.Show("error"); }
        }

        static public void conectar_con(String server_ip, int port)
        {


            try
            {
                socketForServer = new TcpClient(server_ip, port);
                //recibir
                while (true)
               {
                 Thread escucha = new Thread(recibir);
                  escucha.Start();
                    

                }
            }

            catch
            {
                MessageBox.Show("No se pudo conectar a {0}:1234", server_ip);
                return;
            }

        }

        static public void recibir()
        {
            NetworkStream networkStream = socketForServer.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);

            String texto_recibido = streamReader.ReadLine();
            t= texto_recibido;
            
            MessageBox.Show(texto_recibido);


        }


        static String enviar(String mensaje)
        {

            NetworkStream networkStream = socketForClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);

            streamWriter.WriteLine(mensaje);
            streamWriter.Flush();
            return mensaje;

        }
    }
}
