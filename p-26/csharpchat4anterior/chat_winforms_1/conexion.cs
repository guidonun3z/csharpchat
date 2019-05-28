using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;


namespace chat_winforms_1
{
    class conexion
    {
        TcpClient socketForClient;
        TcpClient socketForServer;

        //Thread t = new Thread(recibir);

        public void Start(int port)
        {
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");

            TcpListener  tcpListener = new TcpListener(ipaddress,port);
            tcpListener.Start();
            MessageBox.Show("esperando al cliente");

            socketForClient = tcpListener.AcceptTcpClient();
            
            if (socketForClient.Connected)
            {//this.recibir();
               // t.Start();
                // Si se conecta
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
                //return texto_recibido;
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
