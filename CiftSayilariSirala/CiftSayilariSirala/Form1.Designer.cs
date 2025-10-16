namespace CiftSayilariSirala
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnBasla = new System.Windows.Forms.Button();
            this.grpOyunAlani = new System.Windows.Forms.GroupBox();
            this.lstDogruSiralar = new System.Windows.Forms.ListBox();
            this.btnBitir = new System.Windows.Forms.Button();
            this.lblSure = new System.Windows.Forms.Label();
            this.lblZaman = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnBasla
            // 
            this.btnBasla.Location = new System.Drawing.Point(52, 183);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(75, 23);
            this.btnBasla.TabIndex = 0;
            this.btnBasla.Text = "BAŞLA";
            this.btnBasla.UseVisualStyleBackColor = true;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // grpOyunAlani
            // 
            this.grpOyunAlani.Location = new System.Drawing.Point(169, 64);
            this.grpOyunAlani.Name = "grpOyunAlani";
            this.grpOyunAlani.Size = new System.Drawing.Size(264, 308);
            this.grpOyunAlani.TabIndex = 1;
            this.grpOyunAlani.TabStop = false;
            this.grpOyunAlani.Text = "Oyun Alanı";
            // 
            // lstDogruSiralar
            // 
            this.lstDogruSiralar.FormattingEnabled = true;
            this.lstDogruSiralar.ItemHeight = 15;
            this.lstDogruSiralar.Location = new System.Drawing.Point(475, 68);
            this.lstDogruSiralar.Name = "lstDogruSiralar";
            this.lstDogruSiralar.Size = new System.Drawing.Size(120, 304);
            this.lstDogruSiralar.TabIndex = 2;
            this.lstDogruSiralar.SelectedIndexChanged += new System.EventHandler(this.lstDogruSiralar_SelectedIndexChanged);
            // 
            // btnBitir
            // 
            this.btnBitir.Location = new System.Drawing.Point(630, 183);
            this.btnBitir.Name = "btnBitir";
            this.btnBitir.Size = new System.Drawing.Size(75, 23);
            this.btnBitir.TabIndex = 3;
            this.btnBitir.Text = "BİTİR";
            this.btnBitir.UseVisualStyleBackColor = true;
            this.btnBitir.Click += new System.EventHandler(this.btnBitir_Click);
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.Location = new System.Drawing.Point(633, 220);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(34, 15);
            this.lblSure.TabIndex = 4;
            this.lblSure.Text = "SÜRE";
            // 
            // lblZaman
            // 
            this.lblZaman.AutoSize = true;
            this.lblZaman.Location = new System.Drawing.Point(633, 255);
            this.lblZaman.Name = "lblZaman";
            this.lblZaman.Size = new System.Drawing.Size(34, 15);
            this.lblZaman.TabIndex = 5;
            this.lblZaman.Text = "60 sn";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblZaman);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.btnBitir);
            this.Controls.Add(this.lstDogruSiralar);
            this.Controls.Add(this.grpOyunAlani);
            this.Controls.Add(this.btnBasla);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnBasla;
        private GroupBox grpOyunAlani;
        private ListBox lstDogruSiralar;
        private Button btnBitir;
        private Label lblSure;
        private Label lblZaman;
        private System.Windows.Forms.Timer timer1;
    }
}