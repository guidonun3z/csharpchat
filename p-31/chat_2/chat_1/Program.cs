using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace chat_1
{//chat 2
    class chat
    {
        static TcpClient socketForClient;
        static TcpClient socketForServer;

        

        static void Main(string[] args)
        {
            Thread servidor = new Thread(StarService);
            Thread cliente = new Thread(StarClient);

            cliente.Start();
           // cliente.Join();
            servidor.Start();

            //StarClient();
            //StarService();

        }

        /**Funciones**/
        static public void StarService()
        {
            TcpClient socketcliente;


            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            TcpListener socket = new TcpListener(ipaddress, 13000);
            socket.Start();

            Console.WriteLine("esperando al cliente");
            socketcliente = socket.AcceptTcpClient();

            if (socketcliente.Connected)
                Console.WriteLine("cliente conectado");


            NetworkStream networkStream = socketcliente.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);

            string mensaje;
            do
            {

                mensaje = Console.ReadLine();
                streamWriter.WriteLine(mensaje);
                streamWriter.Flush();

            } while (socketcliente.Connected);


        }
        static public void StarClient() {
            TcpClient socketservidor;

            socketservidor = new TcpClient("127.0.0.1", 12000);
            if (socketservidor.Connected)
                Console.WriteLine("listo");

            NetworkStream networkStream = socketservidor.GetStream();
            StreamReader streamReader = new StreamReader(networkStream);
            string mensaje;
            do
            {
                //new Thread(() =>
                //{
                    mensaje = streamReader.ReadLine();
                    Console.WriteLine("pc1 :" + mensaje);
                //}).Start();


            } while (socketservidor.Connected);
        }






       /* funcines antiguas*/
       static public void Start(int port)
        {
            Thread.Sleep(2000);

            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ipaddress, port);
            tcpListener.Start();

            Console.WriteLine("esperando al cliente");
            socketForClient = tcpListener.AcceptTcpClient();

            if (socketForClient.Connected)
            {   
              Console.WriteLine("Cliente conectado.");
              
                string mensaje;
                while (true)
                {
                    mensaje = Console.ReadLine();
                    enviar(mensaje);
                }
            }
            else
            { Console.WriteLine("error"); }
        }
       static  public void conectar_con(String server_ip, int port)
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
                Console.WriteLine("No se pudo conectar a {0}:1234", server_ip);
                return;
            }

        }
       static  public void recibir()
        {       
            NetworkStream networkStream = socketForServer.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);
 
                String texto_recibido = streamReader.ReadLine();
                Console.WriteLine("pc1 :"+texto_recibido);
                //Console.ReadLine();         
        }
       static void enviar(String mensaje)
        {
           
            NetworkStream networkStream = socketForClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);

                streamWriter.WriteLine(mensaje);
                streamWriter.Flush();
         
        }
    }
}
