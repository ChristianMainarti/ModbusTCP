using ModbusTCP.Requisitions;
using System;
using System.Windows.Forms;
using System.Net.Sockets;

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
        private RequestStandardModbus requestsStandardModbus;
        private TCPConnection tcpConnection;
        public FormLeitorModbus()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (tcpConnection == null)
            {
                btnFC01.Enabled = false;
                btnFC02.Enabled = false;
                btnFC03.Enabled = false;
                btnFC04.Enabled = false;
                btnFC05.Enabled = false;
                btnFC06.Enabled = false;
                btnFC15.Enabled = false;
                btnFC16.Enabled = false;
            }
        }

        private void btnIniciaConexao_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnIniciaConexao.Text == "Fecha Conexão")
                {
                    txtIP.Enabled = true;
                    txtPort.Enabled = true;
                    btnIniciaConexao.Text = "Inicia Conexão";
                }
                else
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


                        if (!tcpConnection.StatusConnection())
                            throw new Exception();

                        requestsStandardModbus = new RequestStandardModbus(tcpConnection);
                        btnFC01.Enabled = true;
                        btnFC02.Enabled = true;
                        btnFC03.Enabled = true;
                        btnFC04.Enabled = true;
                        btnFC05.Enabled = true;
                        btnFC06.Enabled = true;
                        btnFC15.Enabled = true;
                        btnFC16.Enabled = true;
                        txtIP.Enabled = false;
                        txtPort.Enabled = false;
                        btnIniciaConexao.Text = "Fecha Conexão";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no Inicia Conexão", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Erro na chamada do form");
            }

        }
        private void btnFC01_Click(object sender, EventArgs e)
        {
            if (tcpConnection.StatusConnection())
            {
                string _ipAddressServer = txtIP.Text;
                int _portNumber = Convert.ToInt32(txtPort.Text);


                (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ReadCoilStatus(addressSlave, firstRegister, quantityRegister);

                byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);

                if (response != null)
                {
                    Console.WriteLine(String.Join(",", response));
                }
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
            requestsStandardModbus = new RequestStandardModbus(tcpConnection);
            byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);

            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }
        }
        private void btnFC03_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tcpConnection.StatusConnection())
                {
                    string _ipAddressServer = txtIP.Text;
                    int _portNumber = Convert.ToInt32(txtPort.Text);
                    tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
                }

                (byte[] buffer, int sizeBufferExpected) = FunctionCodes.ReadHoldingRegisters(addressSlave, firstRegister, quantityRegister);
                requestsStandardModbus = new RequestStandardModbus(tcpConnection);
                byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);

                if (response != null)
                {
                    Console.WriteLine(String.Join(", ", response));
                    txtbLeituras.Text = String.Join(", ", response);
                }
                else
                {
                    MessageBox.Show("A leitura não pode ser realizada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
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
            requestsStandardModbus = new RequestStandardModbus(tcpConnection);
            byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);
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
            requestsStandardModbus = new RequestStandardModbus(tcpConnection);
            byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);

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
            requestsStandardModbus = new RequestStandardModbus(tcpConnection);
            byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);

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
            requestsStandardModbus = new RequestStandardModbus(tcpConnection);
            byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);

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
            requestsStandardModbus = new RequestStandardModbus(tcpConnection);
            byte[] response = requestsStandardModbus.SendGenericRequestModbus(buffer, sizeBufferExpected);

            if (response != null)
            {
                Console.WriteLine(String.Join(",", response));
            }
        }
    }
}