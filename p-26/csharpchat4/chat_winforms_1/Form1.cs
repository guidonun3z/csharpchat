﻿using System;
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

        TcpClient socketForClient;
        TcpClient socketForServer;
     

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {

            Connect_to(txt_ip.Text, int.Parse(txt_puerto.Text));
          

        }

        private void btn_listener_Click(object sender, EventArgs e)
        {
            Start(int.Parse(txt_lis_port.Text));
            /*Thread t = new Thread(()=> Start(int.Parse(txt_lis_port.Text)));
            t.Start();*/

       
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
           string sms_actual= enviar(txt_mensaje.Text) + Environment.NewLine;
            txt_ml_mensajes.Text = txt_ml_mensajes.Text + sms_actual;
            
        }

        /**Funciones**/

        public void Start(int port)
        {

            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ipaddress, port);
            tcpListener.Start();
            MessageBox.Show("esperando al cliente");
            socketForClient = tcpListener.AcceptTcpClient();


            if (socketForClient.Connected)
            {   // Si se conecta
               // r.Start();
                MessageBox.Show("Cliente conectado.");
            }
            else
            { MessageBox.Show("error"); }
        }

        public void Connect_to(String server_ip, int port)
        {
            try
            {
                socketForServer = new TcpClient(server_ip, port);
            }

            catch
            {
                MessageBox.Show("No se pudo conectar a {0}:1234", server_ip);
                return;
            }

        }

        public void recibir()
        {
            //Creamos el networkSream, el Reader y el writer
            NetworkStream networkStream = socketForClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);

            try
            {
                String texto_recibido = streamReader.ReadLine();
                MessageBox.Show(texto_recibido);
            }

            finally
            {
                /* //Cerramos las conexiones
                 streamReader.Close();
                 streamWriter.Close();
                 networkStream.Close();
                 socketForClient.Close();*/

            }
        }


        public string enviar(String mensaje)
        {
            //Creamos el networkSream, el Reader y el writer
            NetworkStream networkStream = socketForClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);
            

            try
            {
                streamWriter.WriteLine(mensaje);
                streamWriter.Flush();
                return mensaje;
            }

            finally
            {
                //Cerramos las conexiones
                /* streamReader.Close();
                 streamWriter.Close();
                 networkStream.Close();
                 socketForClient.Close();*/

            }
        }
    }
}