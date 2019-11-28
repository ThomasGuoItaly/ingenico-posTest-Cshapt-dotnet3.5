namespace TestPos
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTransazione = new System.Windows.Forms.Button();
            this.btnChiusura = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.Porta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(304, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Importo in cent.";
            // 
            // btnTransazione
            // 
            this.btnTransazione.Location = new System.Drawing.Point(15, 64);
            this.btnTransazione.Name = "btnTransazione";
            this.btnTransazione.Size = new System.Drawing.Size(164, 23);
            this.btnTransazione.TabIndex = 2;
            this.btnTransazione.Text = "Pagamento";
            this.btnTransazione.UseVisualStyleBackColor = true;
            this.btnTransazione.Click += new System.EventHandler(this._btnTransazione_Click);
            // 
            // btnChiusura
            // 
            this.btnChiusura.Location = new System.Drawing.Point(15, 93);
            this.btnChiusura.Name = "btnChiusura";
            this.btnChiusura.Size = new System.Drawing.Size(164, 23);
            this.btnChiusura.TabIndex = 3;
            this.btnChiusura.Text = "Chiusura";
            this.btnChiusura.UseVisualStyleBackColor = true;
            this.btnChiusura.Click += new System.EventHandler(this.btnChiusura_Click);
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(104, 12);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(75, 20);
            this.IP.TabIndex = 4;
            this.IP.Text = "10.4.17.143";
            // 
            // Porta
            // 
            this.Porta.Location = new System.Drawing.Point(185, 12);
            this.Porta.Name = "Porta";
            this.Porta.Size = new System.Drawing.Size(46, 20);
            this.Porta.TabIndex = 5;
            this.Porta.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Indirizzo IP:Porta";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Get Release";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 203);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Porta);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.btnChiusura);
            this.Controls.Add(this.btnTransazione);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTransazione;
        private System.Windows.Forms.Button btnChiusura;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.TextBox Porta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

