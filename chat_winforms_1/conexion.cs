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
using System.Threading;
using System.Threading.Tasks;

namespace chat_winforms_1
{
    class conexion
    {
        TcpClient socketForClient;

        public void Start()
        {
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");

            TcpListener tcpListener = new TcpListener(ipaddress,4321);
            tcpListener.Start();
            MessageBox.Show("esperando al cliente");
            // Socket socketForClient = tcpListener.AcceptSocket();
            socketForClient = tcpListener.AcceptTcpClient();

            if (socketForClient.Connected)
            {
                // Si se conecta
                MessageBox.Show("Cliente conectado.");
                
            }
            else
            { MessageBox.Show("error"); }
        }

        public string recibir()
        {
            //Creamos el networkSream, el Reader y el writer
            NetworkStream networkStream = socketForClient.GetStream();//new NetworkStream(socketForClient);
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);


            try
            {
                String texto_recibido = streamReader.ReadLine();
                return texto_recibido;
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
            NetworkStream networkStream = socketForClient.GetStream();//new NetworkStream(socketForClient);
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);


            try
            {
                //Esta es la data a enviar.
                //Escribimos la data en el stream
                streamWriter.WriteLine(mensaje);
                //Ahora le decimos que la mande.
                streamWriter.Flush();
                string m = streamReader.ReadLine();
                MessageBox.Show(m);
                return m;
                
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

    public class Client
    {
        static TcpClient socketForServer;
        Task recibir = new Task(() => cli_recibir());

        public void Connect(String server_ip, int port)
        {
            
            //string server = "localhost";
            try
            {
                //IPAddress ipaddress = IPAddress.Parse(server_ip);
                //Creamos un TcpCliente y le pasamos 
                //el server y el puerto.
                socketForServer = new TcpClient(server_ip, port);

                recibir.Start();
                //MessageBox.Show(cli_recibir());

            }

            catch
            {
                MessageBox.Show("No se pudo conectar a {0}:1234", server_ip);
                return;
            }
  
        }
        static public string cli_recibir()
        {
            //Creamos el networkSream, el Reader y el writer
            NetworkStream networkStream = socketForServer.GetStream();//new NetworkStream(socketForClient);
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);


            try
            {
                String texto_recibido = streamReader.ReadLine();
                MessageBox.Show(texto_recibido);
                return texto_recibido;

            }

            finally
            {
                 //Cerramos las conexiones
               /*  streamReader.Close();
                 streamWriter.Close();
                 networkStream.Close();
                socketForServer.Close();*/

            }
        }


        public string enviar(String mensaje)
        {
            //Creamos el networkSream, el Reader y el writer
            NetworkStream networkStream = socketForServer.GetStream();//new NetworkStream(socketForClient);
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);


            try
            {
                //Esta es la data a enviar.
                //Escribimos la data en el stream
                streamWriter.WriteLine(mensaje);
                //Ahora le decimos que la mande.
                streamWriter.Flush();
                string m = streamReader.ReadLine();
                MessageBox.Show(m);
                return m;

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
