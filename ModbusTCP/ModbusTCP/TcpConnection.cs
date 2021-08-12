using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ModbusTCP
{
    public class TCPConnection
    {
        private TcpClient tcpClient;
        public NetworkStream networkStream;

        private int portNumber;
        private string ipAddressServer;


        public TCPConnection(string _ipAddressServer, int _portNumber)
        {
            portNumber = _portNumber;
            ipAddressServer = _ipAddressServer;

            tcpClient = new TcpClient();
        }


        public bool StartConnection()
        {
            try
            {
                if (tcpClient.Connected)
                {
                    tcpClient.Close();
                    networkStream = null;
                }

                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddressServer, portNumber);

                if (tcpClient.Connected)
                {
                    networkStream = tcpClient.GetStream();
                    //Velocidade de transferência de dados = 9600 bits/s
                    //Considere a requisição exemplificada = 8 bytes
                    // Tempo = 1*8/(9600/8) => 6,66ms
                    //Para 30 bytes (pior caso) => 25ms * 3,5 => 87,5ms
                    //Tempo de leitura = 3,5 * 87,5 => 306,5ms 

                    networkStream.WriteTimeout = 2500;
                    networkStream.ReadTimeout = 7000;
                    return tcpClient.Connected;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Erro no Inicia Conexão", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }


        public byte[] WriteByte(byte[] buffer, int sizeBufferExpected)
        {
            try
            {
                if (networkStream == null)
                {
                    Console.WriteLine("networkstream com problemas");
                }

                if (networkStream.CanWrite)
                {
                
                    networkStream.Write(buffer, 0, buffer.Length);
                    // ao retornar o  read byte o buffer está como null
                    return ReadByte(sizeBufferExpected);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Write byte com problema " + e.Message);
            }
            return buffer;
        }

        // tem algo errado no read bytes ainda
        public byte[] ReadByte(int sizeBufferExpected)
        {
            // o erro deve estar aqui
            byte[] buffer = new byte[sizeBufferExpected];

            try
            {
                if (networkStream == null)
                {
                    Console.WriteLine("networking com problemas");
                }
                if (networkStream.CanRead)
                {   // buffer recebendo 0
                    if (networkStream.Read(buffer, 0, sizeBufferExpected) == sizeBufferExpected)
                    {
                        return buffer;
                    }
                }         
            }
            catch (Exception e)
            {
                Console.WriteLine("Readbyte com problema " + e.Message);
                return null;
            }
            return buffer;
        }

        public bool StatusConnection() 
        {
            if (tcpClient!= null)
            {
                return tcpClient.Connected;
            }
            return false;
        }
    }
}
