namespace Strike_Rich
{
    partial class frmStrikeRich
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
            txtInstructions = new TextBox();
            pbMain = new PictureBox();
            btnDoor = new Button();
            tblMain = new TableLayoutPanel();
            pbIsland12 = new PictureBox();
            btnStartGo = new Button();
            pbIsland2 = new PictureBox();
            pbIsland3 = new PictureBox();
            pbIsland1 = new PictureBox();
            pbIsland9 = new PictureBox();
            pbIsland10 = new PictureBox();
            pbIsland8 = new PictureBox();
            pbIsland5 = new PictureBox();
            pbIsland6 = new PictureBox();
            pbIsland7 = new PictureBox();
            pbIslandStart = new PictureBox();
            pbIsland4 = new PictureBox();
            pbIsland11 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbIsland12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIslandStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland11).BeginInit();
            SuspendLayout();
            // 
            // txtInstructions
            // 
            txtInstructions.BackColor = Color.FromArgb(90, 62, 32);
            txtInstructions.Dock = DockStyle.Top;
            txtInstructions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtInstructions.ForeColor = Color.White;
            txtInstructions.Location = new Point(0, 0);
            txtInstructions.Multiline = true;
            txtInstructions.Name = "txtInstructions";
            txtInstructions.ReadOnly = true;
            txtInstructions.ScrollBars = ScrollBars.Vertical;
            txtInstructions.Size = new Size(1576, 92);
            txtInstructions.TabIndex = 33;
            txtInstructions.Text = "PRESS DOORKNOB TO START GAME";
            txtInstructions.TextAlign = HorizontalAlignment.Center;
            txtInstructions.TextChanged += txtInstructions_TextChanged;
            // 
            // pbMain
            // 
            pbMain.BackColor = Color.Blue;
            pbMain.Dock = DockStyle.Fill;
            pbMain.Location = new Point(0, 92);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(1576, 0);
            pbMain.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMain.TabIndex = 34;
            pbMain.TabStop = false;
            // 
            // btnDoor
            // 
            btnDoor.Anchor = AnchorStyles.None;
            btnDoor.AutoSize = true;
            btnDoor.BackColor = Color.FromArgb(90, 62, 32);
            btnDoor.BackgroundImageLayout = ImageLayout.None;
            btnDoor.Location = new Point(730, 321);
            btnDoor.Name = "btnDoor";
            btnDoor.Size = new Size(18, 17);
            btnDoor.TabIndex = 35;
            btnDoor.TextAlign = ContentAlignment.BottomRight;
            btnDoor.UseVisualStyleBackColor = false;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 7;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.489346F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.5499144F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.8023415F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2896F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2896F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2896F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2896F));
            tblMain.Controls.Add(pbIsland12, 0, 3);
            tblMain.Controls.Add(btnStartGo, 0, 1);
            tblMain.Controls.Add(pbIsland2, 3, 1);
            tblMain.Controls.Add(pbIsland3, 4, 2);
            tblMain.Controls.Add(pbIsland1, 2, 2);
            tblMain.Controls.Add(pbIsland9, 4, 5);
            tblMain.Controls.Add(pbIsland10, 3, 6);
            tblMain.Controls.Add(pbIsland8, 2, 5);
            tblMain.Controls.Add(pbIsland5, 5, 2);
            tblMain.Controls.Add(pbIsland6, 6, 3);
            tblMain.Controls.Add(pbIsland7, 5, 4);
            tblMain.Controls.Add(pbIslandStart, 3, 4);
            tblMain.Controls.Add(pbIsland4, 1, 2);
            tblMain.Controls.Add(pbIsland11, 1, 4);
            tblMain.Dock = DockStyle.Bottom;
            tblMain.Location = new Point(0, 92);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 8;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.5830116F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.741313F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.9677792F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6939011F));
            tblMain.Size = new Size(1576, 777);
            tblMain.TabIndex = 38;
            tblMain.Paint += tblMain_Paint;
            // 
            // pbIsland12
            // 
            pbIsland12.BackColor = Color.Magenta;
            pbIsland12.Dock = DockStyle.Fill;
            pbIsland12.Location = new Point(3, 289);
            pbIsland12.Name = "pbIsland12";
            pbIsland12.Size = new Size(112, 91);
            pbIsland12.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland12.TabIndex = 10;
            pbIsland12.TabStop = false;
            // 
            // btnStartGo
            // 
            btnStartGo.BackColor = Color.AliceBlue;
            btnStartGo.Dock = DockStyle.Fill;
            btnStartGo.Location = new Point(3, 93);
            btnStartGo.Name = "btnStartGo";
            btnStartGo.Size = new Size(112, 93);
            btnStartGo.TabIndex = 27;
            btnStartGo.Text = "START";
            btnStartGo.UseVisualStyleBackColor = false;
            // 
            // pbIsland2
            // 
            pbIsland2.BackColor = Color.Magenta;
            pbIsland2.Dock = DockStyle.Fill;
            pbIsland2.Location = new Point(678, 93);
            pbIsland2.Name = "pbIsland2";
            pbIsland2.Size = new Size(219, 93);
            pbIsland2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland2.TabIndex = 13;
            pbIsland2.TabStop = false;
            // 
            // pbIsland3
            // 
            pbIsland3.BackColor = Color.Magenta;
            pbIsland3.Dock = DockStyle.Fill;
            pbIsland3.Location = new Point(903, 192);
            pbIsland3.Name = "pbIsland3";
            pbIsland3.Size = new Size(219, 91);
            pbIsland3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland3.TabIndex = 7;
            pbIsland3.TabStop = false;
            // 
            // pbIsland1
            // 
            pbIsland1.BackColor = Color.Fuchsia;
            pbIsland1.Dock = DockStyle.Fill;
            pbIsland1.ErrorImage = null;
            pbIsland1.InitialImage = null;
            pbIsland1.Location = new Point(366, 192);
            pbIsland1.Name = "pbIsland1";
            pbIsland1.Size = new Size(306, 91);
            pbIsland1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland1.TabIndex = 12;
            pbIsland1.TabStop = false;
            // 
            // pbIsland9
            // 
            pbIsland9.BackColor = Color.Magenta;
            pbIsland9.Dock = DockStyle.Fill;
            pbIsland9.Location = new Point(903, 483);
            pbIsland9.Name = "pbIsland9";
            pbIsland9.Size = new Size(219, 91);
            pbIsland9.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland9.TabIndex = 18;
            pbIsland9.TabStop = false;
            // 
            // pbIsland10
            // 
            pbIsland10.BackColor = Color.Magenta;
            pbIsland10.Dock = DockStyle.Fill;
            pbIsland10.Location = new Point(678, 580);
            pbIsland10.Name = "pbIsland10";
            pbIsland10.Size = new Size(219, 87);
            pbIsland10.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland10.TabIndex = 19;
            pbIsland10.TabStop = false;
            // 
            // pbIsland8
            // 
            pbIsland8.BackColor = Color.Magenta;
            pbIsland8.Dock = DockStyle.Fill;
            pbIsland8.Location = new Point(366, 483);
            pbIsland8.Name = "pbIsland8";
            pbIsland8.Size = new Size(306, 91);
            pbIsland8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland8.TabIndex = 2;
            pbIsland8.TabStop = false;
            // 
            // pbIsland5
            // 
            pbIsland5.BackColor = Color.Magenta;
            pbIsland5.Dock = DockStyle.Fill;
            pbIsland5.Location = new Point(1128, 192);
            pbIsland5.Name = "pbIsland5";
            pbIsland5.Size = new Size(219, 91);
            pbIsland5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland5.TabIndex = 17;
            pbIsland5.TabStop = false;
            // 
            // pbIsland6
            // 
            pbIsland6.BackColor = Color.Magenta;
            pbIsland6.Dock = DockStyle.Fill;
            pbIsland6.ErrorImage = null;
            pbIsland6.Location = new Point(1353, 289);
            pbIsland6.Name = "pbIsland6";
            pbIsland6.Size = new Size(220, 91);
            pbIsland6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland6.TabIndex = 16;
            pbIsland6.TabStop = false;
            // 
            // pbIsland7
            // 
            pbIsland7.BackColor = Color.Magenta;
            pbIsland7.Dock = DockStyle.Fill;
            pbIsland7.Location = new Point(1128, 386);
            pbIsland7.Name = "pbIsland7";
            pbIsland7.Size = new Size(219, 91);
            pbIsland7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland7.TabIndex = 4;
            pbIsland7.TabStop = false;
            // 
            // pbIslandStart
            // 
            pbIslandStart.Location = new Point(678, 386);
            pbIslandStart.Name = "pbIslandStart";
            pbIslandStart.Size = new Size(219, 1);
            pbIslandStart.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIslandStart.TabIndex = 36;
            pbIslandStart.TabStop = false;
            // 
            // pbIsland4
            // 
            pbIsland4.BackColor = Color.Magenta;
            pbIsland4.Dock = DockStyle.Fill;
            pbIsland4.Location = new Point(121, 192);
            pbIsland4.Name = "pbIsland4";
            pbIsland4.Size = new Size(239, 91);
            pbIsland4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland4.TabIndex = 6;
            pbIsland4.TabStop = false;
            // 
            // pbIsland11
            // 
            pbIsland11.BackColor = Color.Magenta;
            pbIsland11.Dock = DockStyle.Fill;
            pbIsland11.Location = new Point(121, 386);
            pbIsland11.Name = "pbIsland11";
            pbIsland11.Size = new Size(239, 91);
            pbIsland11.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIsland11.TabIndex = 11;
            pbIsland11.TabStop = false;
            // 
            // frmStrikeRich
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Crimson;
            ClientSize = new Size(1576, 869);
            Controls.Add(btnDoor);
            Controls.Add(pbMain);
            Controls.Add(txtInstructions);
            Controls.Add(tblMain);
            Location = new Point(5, 100);
            Name = "frmStrikeRich";
            Text = "Strike Rich";
            Load += frmStrikeRich_Load;
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbIsland12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIslandStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIsland11).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public TextBox txtInstructions;
        private PictureBox pbMain;
        private Button btnDoor;
        private ProgressBar progressBar1;
        private TableLayoutPanel tblMain;
        private PictureBox pbIsland12;
        private Button btnStartGo;
        private PictureBox pbIsland2;
        private PictureBox pbIsland3;
        private PictureBox pbIsland1;
        private PictureBox pbIsland9;
        private PictureBox pbIsland10;
        private PictureBox pbIsland8;
        private PictureBox pbIsland5;
        private PictureBox pbIsland6;
        private PictureBox pbIsland7;
        private PictureBox pbIslandStart;
        private PictureBox pbIsland4;
        private PictureBox pbIsland11;
    }
}
