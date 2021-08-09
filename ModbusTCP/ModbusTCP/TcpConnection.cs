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
        private NetworkStream networkStream;

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
                    //Velocidade de transferência de dados = 9600 bits/s
                    //Considere a requisição exemplificada = 8 bytes
                    // Tempo = 1*8/(9600/8) => 6,66ms
                    //Para 30 bytes (pior caso) => 25ms * 3,5 => 87,5ms
                    //Tempo de leitura = 3,5 * 87,5 => 306,5ms 

                    networkStream.WriteTimeout = 2500;
                    networkStream.ReadTimeout = 7000;

                    networkStream = tcpClient.GetStream();

                    return tcpClient.Connected;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro no Inicia Conexão", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }


        public byte[] WriteByte(byte[] buffer, int sizeBufferExpected)
        {
            if (networkStream.CanWrite)
            {
                networkStream.Write(buffer, 0, buffer.Length);
                return ReadByte(sizeBufferExpected);
            }

            return null;
        }


        public byte[] ReadByte(int sizeBufferExpected)
        {

            byte[] response = new byte[] { };

            if (networkStream.CanRead)
            {
                if (networkStream.Read(response, 0, sizeBufferExpected) == sizeBufferExpected)
                    return response;
            }
            return null;
        }
    }
}
