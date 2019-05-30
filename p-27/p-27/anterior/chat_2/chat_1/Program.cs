﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace chat_1
{
    class chat
    {
        static TcpClient socketForClient;
        static TcpClient socketForServer;
       

        static void Main(string[] args)
        { 
           
            Thread cli = new Thread(() => conectar_con("127.0.0.1", 1234));
            Thread serv = new Thread(() => Start(4321));
            
            cli.Start();
          
            serv.Start();
            





        }

        /**Funciones**/

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