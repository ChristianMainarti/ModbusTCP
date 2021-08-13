using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusTCP.Requisitions
{
    class RequestStandardModbus
    {
        private static int countAttempts;
        private TCPConnection tcpConnection;


        public RequestStandardModbus(TCPConnection _tcpConnection)
        {
            countAttempts = 30;
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
                        if(CheckSum.CheckDataIntegrity(buffer,response))
                        {
                            Console.WriteLine($"Request received: {String.Join(", ", response.ToList())}");
                            return response;
                        }
                        else
                        {
                            response = null;
                        }
                        if(response == null)
                            continue;
                    }                    
                }
                else
                {
                    throw new Exception("ConnectionNoStartedOrLostedException");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
