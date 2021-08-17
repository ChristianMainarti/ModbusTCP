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
        }


        public bool StartConnection()
        {
            try
            {
                if (tcpClient.Connected)
                {
                    networkStream = null;
                    tcpClient.Close();
                }

                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddressServer, portNumber);

                tcpClient.ReceiveTimeout = 2500;
                tcpClient.SendTimeout = 1000;

                if (tcpClient.Connected)
                {
                    networkStream = tcpClient.GetStream();
                    //Velocidade de transferência de dados = 9600 bits/s
                    //Considere a requisição exemplificada = 8 bytes
                    // Tempo = 1*8/(9600/8) => 6,66ms
                    //Para 30 bytes (pior caso) => 25ms * 3,5 => 87,5ms
                    //Tempo de leitura = 3,5 * 87,5 => 306,5ms 

                    networkStream.WriteTimeout = 1000;
                    networkStream.ReadTimeout = 2500;

                    return tcpClient.Connected;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Erro no Inicia Conexão", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }


        public bool StatusConnection()
        {
            if (tcpClient != null)
            {
                return tcpClient.Connected;
            }

            return false;
        }


        public void CloseConnection()
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                networkStream.Close();
                tcpClient.Close();
            }
        }


        public byte[] WriteByte(byte[] dataToSend, int sizeBufferExpected)
        {
            byte[] buffer = new byte[sizeBufferExpected];

            try
            {
                if (tcpClient == null)
                    StartConnection();

                if (StatusConnection())
                {
                    if (networkStream.CanWrite)
                    {
                        networkStream.Write(buffer, 0, sizeBufferExpected);
                        return ReadByte(sizeBufferExpected);
                    }
                    else
                    {
                        networkStream.Close();
                        tcpClient.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        // tem algo errado no read bytes ainda
        public byte[] ReadByte(int sizeBufferExpected)
        {
            byte[] buffer = new byte[sizeBufferExpected];
            // o erro deve estar aqui
            try
            {
                if (networkStream.CanRead)
                {
                    // buffer recebendo 0
                    //System.IO.IOException
                    if (networkStream.Read(buffer, 0, sizeBufferExpected) == sizeBufferExpected)
                        return buffer;
                    else
                        buffer = null;
                }
                else
                {
                    networkStream.Close();
                    tcpClient.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Readbyte com problema " + e.Message);
            }

            return buffer;
        }
    }
}