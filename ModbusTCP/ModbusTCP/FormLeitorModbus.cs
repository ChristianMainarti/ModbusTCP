using System;
using System.Windows.Forms;

namespace ModbusTCP
{
    
    public partial class FormLeitorModbus : Form
    {

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
            int sizeBufferExpected;
            string _ipAddressServer = txtIP.Text;
            int _portNumber = Convert.ToInt32(txtPort.Text);
            TCPConnection tcpConnection = new TCPConnection(_ipAddressServer, _portNumber);
           // tcpConnection.ReadByte();

        }
        private void btnFC02_Click(object sender, EventArgs e)
        {

        }
        private void btnFC03_Click(object sender, EventArgs e)
        {

        }
        private void btnFC04_Click(object sender, EventArgs e)
        {

        }
        private void btnFC05_Click(object sender, EventArgs e)
        {

        }
        private void btnFC06_Click(object sender, EventArgs e)
        {

        }
        private void btnFC15_Click(object sender, EventArgs e)
        {

        }
        private void btnFC16_Click(object sender, EventArgs e)
        {

        }
    }
}
