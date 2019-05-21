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

namespace chat_winforms_1
{
    class conexion
    {
        TcpClient socketForClient;
        //public  void Start(String server_ip, int port)
        public void Start()

        {
            // Creamos un TcpListener y le indicamos que
            //puerto va a poner en escucha.
            //IPAddress ipaddress = IPAddress.Parse(server_ip);

            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");

            TcpListener tcpListener = new TcpListener(ipaddress,4321);


            //Iniciamos la esucha

            tcpListener.Start();

            //Este método queda bloqueado hasta que
            //se conecte un cliente
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
        public string msg_writer(String mensaje)
        {
            //Creamos el networkSream, el Reader y el writer
            NetworkStream networkStream = socketForClient.GetStream();//new NetworkStream(socketForClient);
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);


            try
            {
                /*while (socketForClient.Connected)
                {*/

                //Esta es la data a enviar.

                //Escribimos la data en el stream
                streamWriter.WriteLine(mensaje);
                //Ahora le decimos que la mande.
                streamWriter.Flush();

                //Esperamos data del cliente
                //Y la escribimos por consola.
                //theString = streamReader.ReadLine();

                //Console.WriteLine("Pc2 : " + theString);
                return streamReader.ReadLine();
                /*}*/
            }

            finally
            {
                //Cerramos las conexiones
                streamReader.Close();
                streamWriter.Close();
                networkStream.Close();
                socketForClient.Close();

            }
        }
    }

    public class Client
    {

        public void Connect(String server_ip, int port)
        {
            TcpClient socketForServer;
            //string server = "localhost";
            try
            {
                //IPAddress ipaddress = IPAddress.Parse(server_ip);
                //Creamos un TcpCliente y le pasamos 
                //el server y el puerto.
                socketForServer = new TcpClient(server_ip, port);
            }

            catch
            {
                MessageBox.Show("No se pudo conectar a {0}:1234", server_ip);
                return;
            }


            //aqui es lo mismo que en el server. Usamos StreamWriter y Reader.

            NetworkStream networkStream = socketForServer.GetStream();
            StreamReader streamReader = new System.IO.StreamReader(networkStream);
            StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);

           /* try
            {
                string outputString = streamReader.ReadLine();
                Console.WriteLine(outputString);
                streamWriter.WriteLine("Mensaje desde el Cliente");
                streamWriter.Flush();
            }

            catch
            {
                Console.WriteLine("Exception reading from Server");
            }

            finally
            {
                networkStream.Close();
            }
            */
        }

    }
}
