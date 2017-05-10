namespace ServerMess
{
    partial class ServerMess
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
            this.rtbContext = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbSendBroadCast = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSendBC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbContext
            // 
            this.rtbContext.Location = new System.Drawing.Point(297, 43);
            this.rtbContext.Name = "rtbContext";
            this.rtbContext.Size = new System.Drawing.Size(266, 370);
            this.rtbContext.TabIndex = 0;
            this.rtbContext.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(246, 425);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start service";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(".VnTime", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "List client connecting";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(".VnTime", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chat log";
            // 
            // rtbSendBroadCast
            // 
            this.rtbSendBroadCast.Location = new System.Drawing.Point(579, 44);
            this.rtbSendBroadCast.Name = "rtbSendBroadCast";
            this.rtbSendBroadCast.Size = new System.Drawing.Size(189, 70);
            this.rtbSendBroadCast.TabIndex = 0;
            this.rtbSendBroadCast.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font(".VnTime", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(576, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Send broadcast";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1019, -261);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(189, 70);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnSendBC
            // 
            this.btnSendBC.Location = new System.Drawing.Point(693, 120);
            this.btnSendBC.Name = "btnSendBC";
            this.btnSendBC.Size = new System.Drawing.Size(75, 35);
            this.btnSendBC.TabIndex = 4;
            this.btnSendBC.Text = "Send";
            this.btnSendBC.UseVisualStyleBackColor = true;
            this.btnSendBC.Click += new System.EventHandler(this.btnSendBC_Click);
            // 
            // ServerMess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 466);
            this.Controls.Add(this.btnSendBC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.rtbSendBroadCast);
            this.Controls.Add(this.rtbContext);
            this.Name = "ServerMess";
            this.Text = "ServerMess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContext;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbSendBroadCast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSendBC;
    }
}

