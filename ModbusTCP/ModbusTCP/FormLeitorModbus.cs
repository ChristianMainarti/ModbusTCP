using System;
using System.Windows.Forms;

namespace ModbusTCP
{

    public partial class FormLeitorModbus : Form
    {
        private int addressSlave;
        private int firstRegister;
        private int quantityRegister;
        private int sizeBufferExpected;
        private int portNumber;
        private string ipAddressServer;
        private byte[] buffer;
        private TCPConnection tcpConnection;
        public FormLeitorModbus()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnIniciaConexao_Click(object sender, EventArgs e)
        {
            try
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);

                if (_ipAddressServer == null)
                {
                    Console.WriteLine("Entre com o IP antes de iniciar a Conexão");
                }
                else
                {
                    tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
                    tcpConnection.StartConnection();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no Inicia Conexão","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Erro na chamada do form");
            }
            
        }
        private void btnFC01_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ReadCoilStatus(addressSlave, firstRegister, quantityRegister);

            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }
        }
        private void btnFC02_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ReadInputStatus(addressSlave, firstRegister, quantityRegister);

            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }
        }
        private void btnFC03_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ReadHoldingRegisters(addressSlave, firstRegister, quantityRegister);
            // talvez o erro esteja aq
            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response!=null)
            {
                Console.WriteLine(String.Join(",", response));
            }

        }
        private void btnFC04_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ReadInputRegisters(addressSlave, firstRegister, quantityRegister);

            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }
        }
        private void btnFC05_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ForceSingleCoil(addressSlave, firstRegister, quantityRegister);

            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }       
        }
        private void btnFC06_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.PresetSingleRegister(addressSlave, firstRegister, quantityRegister);

            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }
        }
        private void btnFC15_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ForceMultipleCoils(addressSlave, firstRegister, quantityRegister);

            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }

        }
        private void btnFC16_Click(object sender, EventArgs e)
        {
            if (!tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);
                tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
            }
            (byte[] buffer, int sizeBufferExpected) = FunctionCodes.PresetMultipleRegisters(addressSlave, firstRegister, quantityRegister);

            byte[] response = tcpConnection.WriteByte(buffer, sizeBufferExpected);
            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }
        }
    }
}
