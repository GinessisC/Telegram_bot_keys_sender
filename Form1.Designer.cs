namespace TestForTutorial
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
            System.Windows.Forms.PictureBox createChitKeypictureBox;
            System.Windows.Forms.PictureBox addResellerPictureBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.messageInfoLabel = new System.Windows.Forms.Label();
            this.usersLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentUsersIdLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.collectUsersInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.copyWholeInfoButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            createChitKeypictureBox = new System.Windows.Forms.PictureBox();
            addResellerPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(createChitKeypictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(addResellerPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createChitKeypictureBox
            // 
            createChitKeypictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            createChitKeypictureBox.Image = global::TestForTutorial.Properties.Resources.Pen;
            createChitKeypictureBox.Location = new System.Drawing.Point(895, 12);
            createChitKeypictureBox.Name = "createChitKeypictureBox";
            createChitKeypictureBox.Size = new System.Drawing.Size(62, 62);
            createChitKeypictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            createChitKeypictureBox.TabIndex = 3;
            createChitKeypictureBox.TabStop = false;
            createChitKeypictureBox.Click += new System.EventHandler(this.createChitKeypictureBox_Click);
            // 
            // addResellerPictureBox
            // 
            addResellerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            addResellerPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("addResellerPictureBox.Image")));
            addResellerPictureBox.Location = new System.Drawing.Point(801, 12);
            addResellerPictureBox.Name = "addResellerPictureBox";
            addResellerPictureBox.Size = new System.Drawing.Size(62, 62);
            addResellerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            addResellerPictureBox.TabIndex = 11;
            addResellerPictureBox.TabStop = false;
            addResellerPictureBox.Click += new System.EventHandler(this.addResellerPictureBox_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(818, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start bot";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(260, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "User`s current callback";
            // 
            // messageInfoLabel
            // 
            this.messageInfoLabel.AutoSize = true;
            this.messageInfoLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageInfoLabel.ForeColor = System.Drawing.Color.White;
            this.messageInfoLabel.Location = new System.Drawing.Point(260, 108);
            this.messageInfoLabel.Name = "messageInfoLabel";
            this.messageInfoLabel.Size = new System.Drawing.Size(97, 25);
            this.messageInfoLabel.TabIndex = 2;
            this.messageInfoLabel.Text = "Username";
            this.messageInfoLabel.Click += new System.EventHandler(this.messageInfoLabel_Click);
            // 
            // usersLabel
            // 
            this.usersLabel.AutoSize = true;
            this.usersLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usersLabel.ForeColor = System.Drawing.Color.White;
            this.usersLabel.Location = new System.Drawing.Point(20, 108);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(220, 25);
            this.usersLabel.TabIndex = 4;
            this.usersLabel.Text = "Ник активного юзера:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(236, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "@";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Id пользователя:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currentUsersIdLabel
            // 
            this.currentUsersIdLabel.AutoSize = true;
            this.currentUsersIdLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentUsersIdLabel.ForeColor = System.Drawing.Color.White;
            this.currentUsersIdLabel.Location = new System.Drawing.Point(267, 163);
            this.currentUsersIdLabel.Name = "currentUsersIdLabel";
            this.currentUsersIdLabel.Size = new System.Drawing.Size(28, 25);
            this.currentUsersIdLabel.TabIndex = 6;
            this.currentUsersIdLabel.Text = "Id";
            this.currentUsersIdLabel.Click += new System.EventHandler(this.currentUsersIdLabel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(56)))), ((int)(((byte)(67)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.collectUsersInfoCheckBox);
            this.panel1.Controls.Add(this.copyWholeInfoButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 439);
            this.panel1.TabIndex = 8;
            // 
            // collectUsersInfoCheckBox
            // 
            this.collectUsersInfoCheckBox.AutoSize = true;
            this.collectUsersInfoCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.collectUsersInfoCheckBox.ForeColor = System.Drawing.Color.White;
            this.collectUsersInfoCheckBox.Location = new System.Drawing.Point(14, 393);
            this.collectUsersInfoCheckBox.Name = "collectUsersInfoCheckBox";
            this.collectUsersInfoCheckBox.Size = new System.Drawing.Size(153, 27);
            this.collectUsersInfoCheckBox.TabIndex = 10;
            this.collectUsersInfoCheckBox.Text = "Собирать инфу";
            this.collectUsersInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyWholeInfoButton
            // 
            this.copyWholeInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyWholeInfoButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copyWholeInfoButton.Location = new System.Drawing.Point(282, 387);
            this.copyWholeInfoButton.Name = "copyWholeInfoButton";
            this.copyWholeInfoButton.Size = new System.Drawing.Size(149, 35);
            this.copyWholeInfoButton.TabIndex = 9;
            this.copyWholeInfoButton.Text = "Копировать всё";
            this.copyWholeInfoButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(417, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "Информация об активном пользователе";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(20, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Колбек:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(56)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(969, 549);
            this.Controls.Add(addResellerPictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentUsersIdLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usersLabel);
            this.Controls.Add(createChitKeypictureBox);
            this.Controls.Add(this.messageInfoLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(createChitKeypictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(addResellerPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        public Label label1;
        private Label messageInfoLabel;
        private Label usersLabel;
        private Label label2;
        private Label label4;
        private Label currentUsersIdLabel;
        private Panel panel1;
        private Button copyWholeInfoButton;
        private Label label3;
        private Label label5;
        private CheckBox collectUsersInfoCheckBox;
    }
}