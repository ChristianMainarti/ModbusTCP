
namespace ModbusTCP
{
    partial class FormLeitorModbus
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnIniciaConexao = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFC16 = new System.Windows.Forms.Button();
            this.btnFC15 = new System.Windows.Forms.Button();
            this.btnFC06 = new System.Windows.Forms.Button();
            this.btnFC05 = new System.Windows.Forms.Button();
            this.btnFC04 = new System.Windows.Forms.Button();
            this.btnFC03 = new System.Windows.Forms.Button();
            this.btnFC02 = new System.Windows.Forms.Button();
            this.btnFC01 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.btnIniciaConexao);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(800, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Iniciar Comunicação";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(94, 54);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(132, 23);
            this.txtPort.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Porta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Endereço IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(94, 20);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(132, 23);
            this.txtIP.TabIndex = 1;
            // 
            // btnIniciaConexao
            // 
            this.btnIniciaConexao.Location = new System.Drawing.Point(363, 23);
            this.btnIniciaConexao.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnIniciaConexao.Name = "btnIniciaConexao";
            this.btnIniciaConexao.Size = new System.Drawing.Size(104, 45);
            this.btnIniciaConexao.TabIndex = 0;
            this.btnIniciaConexao.Text = "Iniciar Conexão";
            this.btnIniciaConexao.UseVisualStyleBackColor = true;
            this.btnIniciaConexao.Click += new System.EventHandler(this.btnIniciaConexao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFC16);
            this.groupBox2.Controls.Add(this.btnFC15);
            this.groupBox2.Controls.Add(this.btnFC06);
            this.groupBox2.Controls.Add(this.btnFC05);
            this.groupBox2.Controls.Add(this.btnFC04);
            this.groupBox2.Controls.Add(this.btnFC03);
            this.groupBox2.Controls.Add(this.btnFC02);
            this.groupBox2.Controls.Add(this.btnFC01);
            this.groupBox2.Location = new System.Drawing.Point(0, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Size = new System.Drawing.Size(800, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "I/O Dados";
            // 
            // btnFC16
            // 
            this.btnFC16.Location = new System.Drawing.Point(635, 109);
            this.btnFC16.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC16.Name = "btnFC16";
            this.btnFC16.Size = new System.Drawing.Size(104, 45);
            this.btnFC16.TabIndex = 8;
            this.btnFC16.Text = "Preset Multiple Registers";
            this.btnFC16.UseVisualStyleBackColor = true;
            this.btnFC16.Click += new System.EventHandler(this.btnFC16_Click);
            // 
            // btnFC15
            // 
            this.btnFC15.Location = new System.Drawing.Point(495, 109);
            this.btnFC15.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC15.Name = "btnFC15";
            this.btnFC15.Size = new System.Drawing.Size(104, 45);
            this.btnFC15.TabIndex = 7;
            this.btnFC15.Text = "Force Multiple Coils";
            this.btnFC15.UseVisualStyleBackColor = true;
            this.btnFC15.Click += new System.EventHandler(this.btnFC15_Click);
            // 
            // btnFC06
            // 
            this.btnFC06.Location = new System.Drawing.Point(363, 109);
            this.btnFC06.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC06.Name = "btnFC06";
            this.btnFC06.Size = new System.Drawing.Size(104, 45);
            this.btnFC06.TabIndex = 6;
            this.btnFC06.Text = "Preset Single Register";
            this.btnFC06.UseVisualStyleBackColor = true;
            this.btnFC06.Click += new System.EventHandler(this.btnFC06_Click);
            // 
            // btnFC05
            // 
            this.btnFC05.Location = new System.Drawing.Point(225, 109);
            this.btnFC05.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC05.Name = "btnFC05";
            this.btnFC05.Size = new System.Drawing.Size(104, 45);
            this.btnFC05.TabIndex = 5;
            this.btnFC05.Text = "Force Single Coil";
            this.btnFC05.UseVisualStyleBackColor = true;
            this.btnFC05.Click += new System.EventHandler(this.btnFC05_Click);
            // 
            // btnFC04
            // 
            this.btnFC04.Location = new System.Drawing.Point(635, 36);
            this.btnFC04.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC04.Name = "btnFC04";
            this.btnFC04.Size = new System.Drawing.Size(104, 45);
            this.btnFC04.TabIndex = 4;
            this.btnFC04.Text = "Read Input Registers";
            this.btnFC04.UseVisualStyleBackColor = true;
            this.btnFC04.Click += new System.EventHandler(this.btnFC04_Click);
            // 
            // btnFC03
            // 
            this.btnFC03.Location = new System.Drawing.Point(495, 36);
            this.btnFC03.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC03.Name = "btnFC03";
            this.btnFC03.Size = new System.Drawing.Size(104, 45);
            this.btnFC03.TabIndex = 3;
            this.btnFC03.Text = "Read Input Status ";
            this.btnFC03.UseVisualStyleBackColor = true;
            this.btnFC03.Click += new System.EventHandler(this.btnFC03_Click);
            // 
            // btnFC02
            // 
            this.btnFC02.Location = new System.Drawing.Point(363, 36);
            this.btnFC02.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC02.Name = "btnFC02";
            this.btnFC02.Size = new System.Drawing.Size(104, 45);
            this.btnFC02.TabIndex = 2;
            this.btnFC02.Text = "Read Input Status";
            this.btnFC02.UseVisualStyleBackColor = true;
            this.btnFC02.Click += new System.EventHandler(this.btnFC02_Click);
            // 
            // btnFC01
            // 
            this.btnFC01.Location = new System.Drawing.Point(225, 36);
            this.btnFC01.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFC01.Name = "btnFC01";
            this.btnFC01.Size = new System.Drawing.Size(104, 45);
            this.btnFC01.TabIndex = 1;
            this.btnFC01.Text = "Read Coil Status";
            this.btnFC01.UseVisualStyleBackColor = true;
            this.btnFC01.Click += new System.EventHandler(this.btnFC01_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 279);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox3.Size = new System.Drawing.Size(800, 306);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Leituras";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 597);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIniciaConexao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnFC05;
        private System.Windows.Forms.Button btnFC04;
        private System.Windows.Forms.Button btnFC03;
        private System.Windows.Forms.Button btnFC02;
        private System.Windows.Forms.Button btnFC01;
        private System.Windows.Forms.Button btnFC16;
        private System.Windows.Forms.Button btnFC15;
        private System.Windows.Forms.Button btnFC06;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
    }
}

