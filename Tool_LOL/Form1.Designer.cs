namespace Tool_LOL
{
    //PUT "SubstringExtensions" class here
    static class SubstringExtensions
    {
        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        /// <summary>
        /// Get string value after [first] a.
        /// </summary>
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
    }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxLoop = new System.Windows.Forms.TextBox();
            this.pictureBoxXeng = new System.Windows.Forms.PictureBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonTopMost = new System.Windows.Forms.Button();
            this.buttonMonitor = new System.Windows.Forms.Button();
            this.pictureBoxAbove = new System.Windows.Forms.PictureBox();
            this.pictureBoxBelow = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXeng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBelow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(955, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 12;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(945, 135);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(38, 13);
            this.labelStatus.TabIndex = 13;
            this.labelStatus.Text = "Ready";
            // 
            // textBoxLoop
            // 
            this.textBoxLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLoop.Location = new System.Drawing.Point(934, 2);
            this.textBoxLoop.Name = "textBoxLoop";
            this.textBoxLoop.Size = new System.Drawing.Size(21, 26);
            this.textBoxLoop.TabIndex = 14;
            this.textBoxLoop.Text = "8";
            // 
            // pictureBoxXeng
            // 
            this.pictureBoxXeng.Image = global::Tool_LOL.Properties.Resources.xeng;
            this.pictureBoxXeng.Location = new System.Drawing.Point(938, 900);
            this.pictureBoxXeng.Name = "pictureBoxXeng";
            this.pictureBoxXeng.Size = new System.Drawing.Size(47, 40);
            this.pictureBoxXeng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxXeng.TabIndex = 17;
            this.pictureBoxXeng.TabStop = false;
            this.pictureBoxXeng.MouseEnter += new System.EventHandler(this.pictureBoxXeng_MouseEnter);
            this.pictureBoxXeng.MouseLeave += new System.EventHandler(this.pictureBoxXeng_MouseLeave);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.White;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRefresh.Image = global::Tool_LOL.Properties.Resources.refresh;
            this.buttonRefresh.Location = new System.Drawing.Point(934, 42);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(59, 38);
            this.buttonRefresh.TabIndex = 15;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonTopMost
            // 
            this.buttonTopMost.BackColor = System.Drawing.Color.White;
            this.buttonTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTopMost.Image = global::Tool_LOL.Properties.Resources.invisible;
            this.buttonTopMost.Location = new System.Drawing.Point(959, 1);
            this.buttonTopMost.Name = "buttonTopMost";
            this.buttonTopMost.Size = new System.Drawing.Size(34, 27);
            this.buttonTopMost.TabIndex = 11;
            this.buttonTopMost.UseVisualStyleBackColor = false;
            this.buttonTopMost.Click += new System.EventHandler(this.buttonTopMost_Click);
            // 
            // buttonMonitor
            // 
            this.buttonMonitor.BackColor = System.Drawing.Color.White;
            this.buttonMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMonitor.Image = global::Tool_LOL.Properties.Resources.monitor_screen;
            this.buttonMonitor.Location = new System.Drawing.Point(934, 86);
            this.buttonMonitor.Name = "buttonMonitor";
            this.buttonMonitor.Size = new System.Drawing.Size(59, 38);
            this.buttonMonitor.TabIndex = 0;
            this.buttonMonitor.UseVisualStyleBackColor = false;
            this.buttonMonitor.Click += new System.EventHandler(this.buttonbuttonMonitor_Click);
            // 
            // pictureBoxAbove
            // 
            this.pictureBoxAbove.Location = new System.Drawing.Point(-1, -5);
            this.pictureBoxAbove.Name = "pictureBoxAbove";
            this.pictureBoxAbove.Size = new System.Drawing.Size(929, 479);
            this.pictureBoxAbove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAbove.TabIndex = 9;
            this.pictureBoxAbove.TabStop = false;
            this.pictureBoxAbove.Visible = false;
            // 
            // pictureBoxBelow
            // 
            this.pictureBoxBelow.Location = new System.Drawing.Point(-1, 471);
            this.pictureBoxBelow.Name = "pictureBoxBelow";
            this.pictureBoxBelow.Size = new System.Drawing.Size(929, 482);
            this.pictureBoxBelow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBelow.TabIndex = 10;
            this.pictureBoxBelow.TabStop = false;
            this.pictureBoxBelow.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tool_LOL.Properties.Resources.n3;
            this.pictureBox3.Location = new System.Drawing.Point(-1, 232);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(464, 243);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Tool_LOL.Properties.Resources.n4;
            this.pictureBox4.Location = new System.Drawing.Point(464, 230);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(464, 246);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Tool_LOL.Properties.Resources.n8;
            this.pictureBox8.Location = new System.Drawing.Point(464, 707);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(464, 243);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 8;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.MouseEnter += new System.EventHandler(this.pictureBox8_MouseEnter);
            this.pictureBox8.MouseLeave += new System.EventHandler(this.pictureBox8_MouseLeave);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Tool_LOL.Properties.Resources.n6;
            this.pictureBox6.Location = new System.Drawing.Point(464, 453);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(464, 275);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseEnter += new System.EventHandler(this.pictureBox6_MouseEnter);
            this.pictureBox6.MouseLeave += new System.EventHandler(this.pictureBox6_MouseLeave);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Tool_LOL.Properties.Resources.n7;
            this.pictureBox7.Location = new System.Drawing.Point(-1, 707);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(464, 243);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.MouseEnter += new System.EventHandler(this.pictureBox7_MouseEnter);
            this.pictureBox7.MouseLeave += new System.EventHandler(this.pictureBox7_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Tool_LOL.Properties.Resources.n5;
            this.pictureBox5.Location = new System.Drawing.Point(-1, 464);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(464, 252);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.MouseEnter += new System.EventHandler(this.pictureBox5_MouseEnter);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tool_LOL.Properties.Resources.n2;
            this.pictureBox2.Location = new System.Drawing.Point(464, -5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(464, 243);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tool_LOL.Properties.Resources.n1;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(997, 948);
            this.Controls.Add(this.pictureBoxXeng);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.textBoxLoop);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTopMost);
            this.Controls.Add(this.buttonMonitor);
            this.Controls.Add(this.pictureBoxAbove);
            this.Controls.Add(this.pictureBoxBelow);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Đấu Trường Chân Lí - Monitoring";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXeng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBelow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMonitor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBoxAbove;
        private System.Windows.Forms.PictureBox pictureBoxBelow;
        private System.Windows.Forms.Button buttonTopMost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxLoop;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.PictureBox pictureBoxXeng;
    }
}

