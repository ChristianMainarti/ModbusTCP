using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ModbusTCP.Requisitions
{
    class RequestStandardModbus
    {
        private static int countAttempts;
        private TCPConnection tcpConnection;


        public RequestStandardModbus(TCPConnection _tcpConnection)
        {
            countAttempts = 5;
            tcpConnection = _tcpConnection;
        }

        public byte[] SendGenericRequestModbus(byte[] buffer, int sizeBufferExpected)
        {
            try
            {
                if (tcpConnection.StatusConnection())
                {
                    byte[] response = new byte[] { };


                    Console.WriteLine($"Request sended: {String.Join(", ", buffer.ToList())}");
                    for (int i = 0; i < countAttempts; i++)
                    {
                        response = tcpConnection.WriteByte(buffer, sizeBufferExpected);

                        if (response == null)
                            continue;

                        if (CheckSum.CheckDataIntegrity(buffer, response))
                        {
                            Console.WriteLine($"Request received: {String.Join(", ", response.ToList())}");
                            return response;
                        }
                        else
                        {
                            response = null;
                        }
                    }
                }
                else
                {
                    tcpConnection.StartConnection();

                    if (!tcpConnection.StatusConnection())
                        throw new Exception("ConnectionNoStartedOrLostedException");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
