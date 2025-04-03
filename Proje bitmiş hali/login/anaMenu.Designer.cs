namespace login
{
    partial class anaMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.calisanlarBTN = new System.Windows.Forms.Button();
            this.departmanlarBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Departmanlar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(447, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Çalışanlar";
            // 
            // calisanlarBTN
            // 
            this.calisanlarBTN.BackgroundImage = global::login.Properties.Resources.calisanlar;
            this.calisanlarBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.calisanlarBTN.Location = new System.Drawing.Point(434, 94);
            this.calisanlarBTN.Name = "calisanlarBTN";
            this.calisanlarBTN.Size = new System.Drawing.Size(143, 117);
            this.calisanlarBTN.TabIndex = 2;
            this.calisanlarBTN.UseVisualStyleBackColor = true;
            this.calisanlarBTN.Click += new System.EventHandler(this.calisanlarBTN_Click);
            // 
            // departmanlarBTN
            // 
            this.departmanlarBTN.BackgroundImage = global::login.Properties.Resources.departmanlar;
            this.departmanlarBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.departmanlarBTN.Location = new System.Drawing.Point(25, 94);
            this.departmanlarBTN.Name = "departmanlarBTN";
            this.departmanlarBTN.Size = new System.Drawing.Size(153, 120);
            this.departmanlarBTN.TabIndex = 0;
            this.departmanlarBTN.UseVisualStyleBackColor = true;
            this.departmanlarBTN.Click += new System.EventHandler(this.departmanlarBTN_Click);
            // 
            // anaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 314);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calisanlarBTN);
            this.Controls.Add(this.departmanlarBTN);
            this.MaximizeBox = false;
            this.Name = "anaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button departmanlarBTN;
        private System.Windows.Forms.Button calisanlarBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}