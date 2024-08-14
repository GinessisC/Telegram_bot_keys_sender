namespace TestForTutorial
{
    partial class CreateKeyForm
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
            this.addKeyButton = new System.Windows.Forms.Button();
            this.keyStringTextBox = new System.Windows.Forms.TextBox();
            this.keyDurationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.hackTypeComboBox = new System.Windows.Forms.ComboBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.editKeyInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addKeyButton
            // 
            this.addKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addKeyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.addKeyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addKeyButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addKeyButton.ForeColor = System.Drawing.Color.White;
            this.addKeyButton.Location = new System.Drawing.Point(596, 462);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(158, 54);
            this.addKeyButton.TabIndex = 1;
            this.addKeyButton.Text = "Добавить ключ";
            this.addKeyButton.UseVisualStyleBackColor = false;
            this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
            // 
            // keyStringTextBox
            // 
            this.keyStringTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.keyStringTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keyStringTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keyStringTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.keyStringTextBox.Location = new System.Drawing.Point(94, 46);
            this.keyStringTextBox.Multiline = true;
            this.keyStringTextBox.Name = "keyStringTextBox";
            this.keyStringTextBox.Size = new System.Drawing.Size(297, 36);
            this.keyStringTextBox.TabIndex = 3;
            this.keyStringTextBox.Text = "Ключ";
            this.keyStringTextBox.Click += new System.EventHandler(this.keyStringTextBox_Click);
            // 
            // keyDurationTextBox
            // 
            this.keyDurationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.keyDurationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keyDurationTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keyDurationTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.keyDurationTextBox.Location = new System.Drawing.Point(94, 116);
            this.keyDurationTextBox.Multiline = true;
            this.keyDurationTextBox.Name = "keyDurationTextBox";
            this.keyDurationTextBox.Size = new System.Drawing.Size(297, 36);
            this.keyDurationTextBox.TabIndex = 4;
            this.keyDurationTextBox.Text = "Длительность(кол-во дней)";
            this.keyDurationTextBox.Click += new System.EventHandler(this.keyDurationTextBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(502, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Все поля обязательные!";
            // 
            // deviceTypeComboBox
            // 
            this.deviceTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.deviceTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceTypeComboBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.deviceTypeComboBox.FormattingEnabled = true;
            this.deviceTypeComboBox.Items.AddRange(new object[] {
            "AndroidNoRoot",
            "AndroidRoot",
            "IOS",
            "For PC"});
            this.deviceTypeComboBox.Location = new System.Drawing.Point(94, 255);
            this.deviceTypeComboBox.Name = "deviceTypeComboBox";
            this.deviceTypeComboBox.Size = new System.Drawing.Size(297, 36);
            this.deviceTypeComboBox.TabIndex = 8;
            this.deviceTypeComboBox.Text = " Тип девайса";
            this.deviceTypeComboBox.Click += new System.EventHandler(this.deviceTypeComboBox_Click);
            // 
            // hackTypeComboBox
            // 
            this.hackTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.hackTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hackTypeComboBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.hackTypeComboBox.FormattingEnabled = true;
            this.hackTypeComboBox.Items.AddRange(new object[] {
            "Сначала заполни \"тип дивайса\""});
            this.hackTypeComboBox.Location = new System.Drawing.Point(94, 324);
            this.hackTypeComboBox.Name = "hackTypeComboBox";
            this.hackTypeComboBox.Size = new System.Drawing.Size(297, 36);
            this.hackTypeComboBox.TabIndex = 9;
            this.hackTypeComboBox.Text = " Тип чита";
            this.hackTypeComboBox.Click += new System.EventHandler(this.hackTypeComboBox_Click);
            // 
            // priceTextBox
            // 
            this.priceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.priceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priceTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.priceTextBox.Location = new System.Drawing.Point(94, 185);
            this.priceTextBox.Multiline = true;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(297, 36);
            this.priceTextBox.TabIndex = 10;
            this.priceTextBox.Text = "Цена";
            this.priceTextBox.Click += new System.EventHandler(this.priceTextBox_Click);
            // 
            // editKeyInfoButton
            // 
            this.editKeyInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editKeyInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.editKeyInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editKeyInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editKeyInfoButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.editKeyInfoButton.ForeColor = System.Drawing.Color.White;
            this.editKeyInfoButton.Location = new System.Drawing.Point(38, 462);
            this.editKeyInfoButton.Name = "editKeyInfoButton";
            this.editKeyInfoButton.Size = new System.Drawing.Size(222, 54);
            this.editKeyInfoButton.TabIndex = 11;
            this.editKeyInfoButton.Text = "Изменить инфу ключа";
            this.editKeyInfoButton.UseVisualStyleBackColor = false;
            this.editKeyInfoButton.Click += new System.EventHandler(this.editKeyInfoButton_Click);
            // 
            // CreateKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(56)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(794, 555);
            this.Controls.Add(this.editKeyInfoButton);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.hackTypeComboBox);
            this.Controls.Add(this.deviceTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyDurationTextBox);
            this.Controls.Add(this.keyStringTextBox);
            this.Controls.Add(this.addKeyButton);
            this.Name = "CreateKeyForm";
            this.Text = "CreateKeyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addKeyButton;
        private TextBox keyStringTextBox;
        private TextBox keyDurationTextBox;
        private Label label1;
        private ComboBox deviceTypeComboBox;
        private ComboBox hackTypeComboBox;
        private TextBox priceTextBox;
        private Button editKeyInfoButton;
    }
}