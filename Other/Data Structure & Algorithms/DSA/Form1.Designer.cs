namespace DSA_CTDLGT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Pbackground = new System.Windows.Forms.PictureBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttim = new System.Windows.Forms.Button();
            this.btquaylai = new System.Windows.Forms.Button();
            this.fpnlichsutimkiem = new System.Windows.Forms.FlowLayoutPanel();
            this.History_list = new System.Windows.Forms.ListBox();
            this.bttienlen = new System.Windows.Forms.Button();
            this.Search_list = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Pbackground)).BeginInit();
            this.fpnlichsutimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pbackground
            // 
            this.Pbackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pbackground.Image = ((System.Drawing.Image)(resources.GetObject("Pbackground.Image")));
            this.Pbackground.Location = new System.Drawing.Point(0, 0);
            this.Pbackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pbackground.Name = "Pbackground";
            this.Pbackground.Size = new System.Drawing.Size(1491, 1055);
            this.Pbackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pbackground.TabIndex = 9;
            this.Pbackground.TabStop = false;
            this.Pbackground.Click += new System.EventHandler(this.Pbackground_Click);
            // 
            // txttimkiem
            // 
            this.txttimkiem.AcceptsReturn = true;
            this.txttimkiem.AllowDrop = true;
            this.txttimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttimkiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttimkiem.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimkiem.Location = new System.Drawing.Point(87, 814);
            this.txttimkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txttimkiem.ShortcutsEnabled = false;
            this.txttimkiem.Size = new System.Drawing.Size(938, 44);
            this.txttimkiem.TabIndex = 0;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            this.txttimkiem.Enter += new System.EventHandler(this.bttim_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1101, 672);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 26);
            this.label2.TabIndex = 5;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttim
            // 
            this.bttim.BackColor = System.Drawing.Color.PapayaWhip;
            this.bttim.FlatAppearance.BorderColor = System.Drawing.Color.Cornsilk;
            this.bttim.FlatAppearance.BorderSize = 0;
            this.bttim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bttim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.bttim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bttim.Location = new System.Drawing.Point(1153, 760);
            this.bttim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttim.Name = "bttim";
            this.bttim.Size = new System.Drawing.Size(213, 58);
            this.bttim.TabIndex = 16;
            this.bttim.Text = "SEARCH";
            this.bttim.UseVisualStyleBackColor = false;
            this.bttim.Click += new System.EventHandler(this.bttim_Click);
            this.bttim.Enter += new System.EventHandler(this.bttim_Click);
            // 
            // btquaylai
            // 
            this.btquaylai.BackColor = System.Drawing.Color.PapayaWhip;
            this.btquaylai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btquaylai.BackgroundImage")));
            this.btquaylai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btquaylai.FlatAppearance.BorderSize = 0;
            this.btquaylai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btquaylai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.btquaylai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btquaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btquaylai.Location = new System.Drawing.Point(1144, 835);
            this.btquaylai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btquaylai.Name = "btquaylai";
            this.btquaylai.Size = new System.Drawing.Size(111, 62);
            this.btquaylai.TabIndex = 2;
            this.btquaylai.UseVisualStyleBackColor = false;
            this.btquaylai.Click += new System.EventHandler(this.btquaylai_Click);
            // 
            // fpnlichsutimkiem
            // 
            this.fpnlichsutimkiem.Controls.Add(this.History_list);
            this.fpnlichsutimkiem.Location = new System.Drawing.Point(87, 182);
            this.fpnlichsutimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fpnlichsutimkiem.Name = "fpnlichsutimkiem";
            this.fpnlichsutimkiem.Size = new System.Drawing.Size(266, 389);
            this.fpnlichsutimkiem.TabIndex = 5;
            // 
            // History_list
            // 
            this.History_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.History_list.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.History_list.FormattingEnabled = true;
            this.History_list.HorizontalScrollbar = true;
            this.History_list.ItemHeight = 32;
            this.History_list.Location = new System.Drawing.Point(3, 4);
            this.History_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.History_list.Name = "History_list";
            this.History_list.Size = new System.Drawing.Size(262, 384);
            this.History_list.TabIndex = 0;
            this.History_list.SelectedIndexChanged += new System.EventHandler(this.History_list_SelectedIndexChanged);
            // 
            // bttienlen
            // 
            this.bttienlen.BackColor = System.Drawing.Color.PapayaWhip;
            this.bttienlen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttienlen.BackgroundImage")));
            this.bttienlen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bttienlen.FlatAppearance.BorderSize = 0;
            this.bttienlen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bttienlen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.bttienlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttienlen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttienlen.Location = new System.Drawing.Point(1262, 836);
            this.bttienlen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttienlen.Name = "bttienlen";
            this.bttienlen.Size = new System.Drawing.Size(111, 62);
            this.bttienlen.TabIndex = 13;
            this.bttienlen.UseVisualStyleBackColor = false;
            this.bttienlen.Click += new System.EventHandler(this.bttienlen_Click);
            // 
            // Search_list
            // 
            this.Search_list.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.Search_list.AllowDrop = true;
            this.Search_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Search_list.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_list.FormattingEnabled = true;
            this.Search_list.HorizontalScrollbar = true;
            this.Search_list.ItemHeight = 29;
            this.Search_list.Location = new System.Drawing.Point(469, 195);
            this.Search_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Search_list.Name = "Search_list";
            this.Search_list.Size = new System.Drawing.Size(918, 406);
            this.Search_list.TabIndex = 15;
            this.Search_list.SelectedIndexChanged += new System.EventHandler(this.Search_list_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PapayaWhip;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Cornsilk;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1153, 920);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 55);
            this.button1.TabIndex = 16;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.bttim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1491, 1055);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Search_list);
            this.Controls.Add(this.bttienlen);
            this.Controls.Add(this.fpnlichsutimkiem);
            this.Controls.Add(this.btquaylai);
            this.Controls.Add(this.bttim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.Pbackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pbackground)).EndInit();
            this.fpnlichsutimkiem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pbackground;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttim;
        private System.Windows.Forms.Button btquaylai;
        private System.Windows.Forms.FlowLayoutPanel fpnlichsutimkiem;
        public System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button bttienlen;
        private System.Windows.Forms.ListBox Search_list;
        private System.Windows.Forms.ListBox History_list;
        private System.Windows.Forms.Button button1;
    }
}

