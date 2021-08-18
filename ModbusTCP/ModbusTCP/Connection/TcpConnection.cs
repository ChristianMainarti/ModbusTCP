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
                if (tcpClient == null)
                {
                    networkStream = null;
                }

                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddressServer, portNumber);

                if (tcpClient.Connected)
                {
                    networkStream = tcpClient.GetStream();


                    /**
                     * Suponhamos uma transmissão de um vetor máximo de 60 bytes
                     * Velocidade de transmissão em bytes => (9600 / 8) => 1200 bytes/s
                     * Tempo para envio de 30 bytes => 60/1200 => 50ms
                     * Tempo de transmissão entre um quadro e outro = 3,5x
                     * Tempo da requisição => 3*25 => 175ms
                     **/
                    networkStream.WriteTimeout = 2500;

                    //2x o valor do tempo de escrita (Recomendado é que seja de 3,5x)
                    networkStream.ReadTimeout = 6000;


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
            if (tcpClient == null)
                return false;

            if (tcpClient.Connected)
            {
                if (networkStream == null)
                    networkStream = tcpClient.GetStream();
            }
            return tcpClient.Connected;
        }


        public void CloseConnection()
        {
            if (tcpClient.Connected)
            {
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
                        networkStream.Flush();
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