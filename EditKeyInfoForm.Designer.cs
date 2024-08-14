namespace TestForTutorial
{
    partial class EditKeyInfoForm
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
            this.editPriceTextBox = new System.Windows.Forms.TextBox();
            this.editHackTypeComboBox = new System.Windows.Forms.ComboBox();
            this.editDeviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.editKeyDurationTextBox = new System.Windows.Forms.TextBox();
            this.editKeyStringTextBox = new System.Windows.Forms.TextBox();
            this.editKeyInfoButton = new System.Windows.Forms.Button();
            this.keyCantBeFoundLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editPriceTextBox
            // 
            this.editPriceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.editPriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editPriceTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.editPriceTextBox.Location = new System.Drawing.Point(67, 187);
            this.editPriceTextBox.Multiline = true;
            this.editPriceTextBox.Name = "editPriceTextBox";
            this.editPriceTextBox.Size = new System.Drawing.Size(297, 36);
            this.editPriceTextBox.TabIndex = 15;
            this.editPriceTextBox.Text = "Цена";
            this.editPriceTextBox.Visible = false;
            // 
            // editHackTypeComboBox
            // 
            this.editHackTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.editHackTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editHackTypeComboBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.editHackTypeComboBox.FormattingEnabled = true;
            this.editHackTypeComboBox.Location = new System.Drawing.Point(67, 326);
            this.editHackTypeComboBox.Name = "editHackTypeComboBox";
            this.editHackTypeComboBox.Size = new System.Drawing.Size(297, 36);
            this.editHackTypeComboBox.TabIndex = 14;
            this.editHackTypeComboBox.Visible = false;
            // 
            // editDeviceTypeComboBox
            // 
            this.editDeviceTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.editDeviceTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editDeviceTypeComboBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.editDeviceTypeComboBox.FormattingEnabled = true;
            this.editDeviceTypeComboBox.Items.AddRange(new object[] {
            "AndroidNoRoot",
            "AndroidRoot",
            "IOS",
            "For PC"});
            this.editDeviceTypeComboBox.Location = new System.Drawing.Point(67, 257);
            this.editDeviceTypeComboBox.Name = "editDeviceTypeComboBox";
            this.editDeviceTypeComboBox.Size = new System.Drawing.Size(297, 36);
            this.editDeviceTypeComboBox.TabIndex = 13;
            this.editDeviceTypeComboBox.Visible = false;
            this.editDeviceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.editDeviceTypeComboBox_SelectedIndexChanged);
            // 
            // editKeyDurationTextBox
            // 
            this.editKeyDurationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.editKeyDurationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editKeyDurationTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editKeyDurationTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.editKeyDurationTextBox.Location = new System.Drawing.Point(67, 118);
            this.editKeyDurationTextBox.Multiline = true;
            this.editKeyDurationTextBox.Name = "editKeyDurationTextBox";
            this.editKeyDurationTextBox.Size = new System.Drawing.Size(297, 36);
            this.editKeyDurationTextBox.TabIndex = 12;
            this.editKeyDurationTextBox.Text = "Длительность(кол-во дней)";
            this.editKeyDurationTextBox.Visible = false;
            // 
            // editKeyStringTextBox
            // 
            this.editKeyStringTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.editKeyStringTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editKeyStringTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editKeyStringTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.editKeyStringTextBox.Location = new System.Drawing.Point(67, 48);
            this.editKeyStringTextBox.Multiline = true;
            this.editKeyStringTextBox.Name = "editKeyStringTextBox";
            this.editKeyStringTextBox.Size = new System.Drawing.Size(297, 36);
            this.editKeyStringTextBox.TabIndex = 11;
            this.editKeyStringTextBox.Text = "Ключ";
            this.editKeyStringTextBox.TextChanged += new System.EventHandler(this.editKeyStringTextBox_TextChanged);
            // 
            // editKeyInfoButton
            // 
            this.editKeyInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editKeyInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.editKeyInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editKeyInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editKeyInfoButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.editKeyInfoButton.ForeColor = System.Drawing.Color.White;
            this.editKeyInfoButton.Location = new System.Drawing.Point(549, 423);
            this.editKeyInfoButton.Name = "editKeyInfoButton";
            this.editKeyInfoButton.Size = new System.Drawing.Size(158, 54);
            this.editKeyInfoButton.TabIndex = 16;
            this.editKeyInfoButton.Text = "Подтвердить";
            this.editKeyInfoButton.UseVisualStyleBackColor = false;
            this.editKeyInfoButton.Click += new System.EventHandler(this.editKeyInfoButton_Click);
            // 
            // keyCantBeFoundLabel
            // 
            this.keyCantBeFoundLabel.AutoSize = true;
            this.keyCantBeFoundLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keyCantBeFoundLabel.ForeColor = System.Drawing.Color.White;
            this.keyCantBeFoundLabel.Location = new System.Drawing.Point(475, 51);
            this.keyCantBeFoundLabel.Name = "keyCantBeFoundLabel";
            this.keyCantBeFoundLabel.Size = new System.Drawing.Size(210, 25);
            this.keyCantBeFoundLabel.TabIndex = 18;
            this.keyCantBeFoundLabel.Text = "Сначала введите ключ";
            // 
            // EditKeyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(56)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(746, 514);
            this.Controls.Add(this.keyCantBeFoundLabel);
            this.Controls.Add(this.editKeyInfoButton);
            this.Controls.Add(this.editPriceTextBox);
            this.Controls.Add(this.editHackTypeComboBox);
            this.Controls.Add(this.editDeviceTypeComboBox);
            this.Controls.Add(this.editKeyDurationTextBox);
            this.Controls.Add(this.editKeyStringTextBox);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EditKeyInfoForm";
            this.Text = "EditKeyInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox editPriceTextBox;
        private ComboBox editHackTypeComboBox;
        private ComboBox editDeviceTypeComboBox;
        private TextBox editKeyDurationTextBox;
        private TextBox editKeyStringTextBox;
        private Button editKeyInfoButton;
        private Label keyCantBeFoundLabel;
    }
}