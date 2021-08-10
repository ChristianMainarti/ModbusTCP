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
                    TCPConnection tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
                    tcpConnection.StartConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no Inicia Conexão","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Erro na chamada do form");
            }
            
        }
        private void btnFC01_Click(object sender, EventArgs e)
        {
            var tcpConn = new TCPConnection(ipAddressServer, portNumber);
            tcpConn.ReadByte(sizeBufferExpected);
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.ReadCoilStatus(addressSlave, firstRegister, quantityRegister);
        }
        private void btnFC02_Click(object sender, EventArgs e)
        {
            var tcpConn = new TCPConnection(ipAddressServer, portNumber);
            tcpConn.ReadByte(sizeBufferExpected);
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.ReadInputStatus(addressSlave, firstRegister, quantityRegister);
        }
        private void btnFC03_Click(object sender, EventArgs e)
        {
            var tcpConn = new TCPConnection(ipAddressServer, portNumber);
            tcpConn.ReadByte(sizeBufferExpected);
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.ReadHoldingRegisters(addressSlave, firstRegister, quantityRegister);
        }
        private void btnFC04_Click(object sender, EventArgs e)
        {
            var tcpConn = new TCPConnection(ipAddressServer, portNumber);
            tcpConn.ReadByte(sizeBufferExpected);
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.ReadInputRegisters(addressSlave, firstRegister, quantityRegister);
        }
        private void btnFC05_Click(object sender, EventArgs e)
        {
            var tcpConn = new TCPConnection(ipAddressServer, portNumber);
            tcpConn.WriteByte(buffer, sizeBufferExpected);
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.ForceSingleCoil(addressSlave, firstRegister, quantityRegister);
        }
        private void btnFC06_Click(object sender, EventArgs e)
        {
            var tcpConn = new TCPConnection(ipAddressServer, portNumber);
            tcpConn.WriteByte(buffer, sizeBufferExpected);
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.PresetSingleRegister(addressSlave, firstRegister, quantityRegister);
        }
        private void btnFC15_Click(object sender, EventArgs e)
        {
            var tcpConn = new TCPConnection(ipAddressServer, portNumber);
            tcpConn.WriteByte(buffer, sizeBufferExpected);
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.ForceMultipleCoils(addressSlave, firstRegister, quantityRegister);

        }
        private void btnFC16_Click(object sender, EventArgs e)
        {
            int sizeBufferExpected;
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            var functionCode = new FunctionCodes();
            functionCode.PresetMultipleRegisters(addressSlave, firstRegister, quantityRegister);
        }
    }
}
