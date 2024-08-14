namespace TestForTutorial
{
    partial class MakeDiscountForm
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
            this.resellerNameTextBox = new System.Windows.Forms.TextBox();
            this.durationOfDiscountHackTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateDiscountButton = new System.Windows.Forms.Button();
            this.deviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.hackTypeComboBox = new System.Windows.Forms.ComboBox();
            this.deleteDiscountButton = new System.Windows.Forms.Button();
            this.newPricetextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resellerNameTextBox
            // 
            this.resellerNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.resellerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resellerNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resellerNameTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.resellerNameTextBox.Location = new System.Drawing.Point(267, 52);
            this.resellerNameTextBox.Multiline = true;
            this.resellerNameTextBox.Name = "resellerNameTextBox";
            this.resellerNameTextBox.Size = new System.Drawing.Size(297, 36);
            this.resellerNameTextBox.TabIndex = 13;
            this.resellerNameTextBox.Text = "Введите имя ресселера";
            // 
            // durationOfDiscountHackTextBox
            // 
            this.durationOfDiscountHackTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.durationOfDiscountHackTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.durationOfDiscountHackTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.durationOfDiscountHackTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.durationOfDiscountHackTextBox.Location = new System.Drawing.Point(267, 115);
            this.durationOfDiscountHackTextBox.Multiline = true;
            this.durationOfDiscountHackTextBox.Name = "durationOfDiscountHackTextBox";
            this.durationOfDiscountHackTextBox.Size = new System.Drawing.Size(297, 36);
            this.durationOfDiscountHackTextBox.TabIndex = 14;
            this.durationOfDiscountHackTextBox.Text = "Введите длительность чита";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(570, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "$";
            // 
            // CreateDiscountButton
            // 
            this.CreateDiscountButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CreateDiscountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.CreateDiscountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CreateDiscountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateDiscountButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CreateDiscountButton.ForeColor = System.Drawing.Color.Fuchsia;
            this.CreateDiscountButton.Location = new System.Drawing.Point(563, 457);
            this.CreateDiscountButton.Name = "CreateDiscountButton";
            this.CreateDiscountButton.Size = new System.Drawing.Size(158, 54);
            this.CreateDiscountButton.TabIndex = 26;
            this.CreateDiscountButton.Text = "Сделать скидку";
            this.CreateDiscountButton.UseVisualStyleBackColor = false;
            this.CreateDiscountButton.Click += new System.EventHandler(this.CreateDiscountButton_Click);
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
            this.deviceTypeComboBox.Location = new System.Drawing.Point(267, 244);
            this.deviceTypeComboBox.Name = "deviceTypeComboBox";
            this.deviceTypeComboBox.Size = new System.Drawing.Size(297, 36);
            this.deviceTypeComboBox.TabIndex = 27;
            this.deviceTypeComboBox.Text = " Тип девайса";
            // 
            // hackTypeComboBox
            // 
            this.hackTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.hackTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hackTypeComboBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.hackTypeComboBox.FormattingEnabled = true;
            this.hackTypeComboBox.Items.AddRange(new object[] {
            "Сначала заполни \"тип дивайса\""});
            this.hackTypeComboBox.Location = new System.Drawing.Point(267, 310);
            this.hackTypeComboBox.Name = "hackTypeComboBox";
            this.hackTypeComboBox.Size = new System.Drawing.Size(297, 36);
            this.hackTypeComboBox.TabIndex = 28;
            this.hackTypeComboBox.Text = " Тип чита";
            this.hackTypeComboBox.Click += new System.EventHandler(this.hackTypeComboBox_Click);
            // 
            // deleteDiscountButton
            // 
            this.deleteDiscountButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteDiscountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.deleteDiscountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deleteDiscountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteDiscountButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteDiscountButton.ForeColor = System.Drawing.Color.Red;
            this.deleteDiscountButton.Location = new System.Drawing.Point(94, 457);
            this.deleteDiscountButton.Name = "deleteDiscountButton";
            this.deleteDiscountButton.Size = new System.Drawing.Size(158, 54);
            this.deleteDiscountButton.TabIndex = 29;
            this.deleteDiscountButton.Text = "Удалить скидку";
            this.deleteDiscountButton.UseVisualStyleBackColor = false;
            this.deleteDiscountButton.Click += new System.EventHandler(this.deleteDiscountButton_Click);
            // 
            // newPricetextBox
            // 
            this.newPricetextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.newPricetextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newPricetextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newPricetextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.newPricetextBox.Location = new System.Drawing.Point(267, 177);
            this.newPricetextBox.Multiline = true;
            this.newPricetextBox.Name = "newPricetextBox";
            this.newPricetextBox.Size = new System.Drawing.Size(297, 36);
            this.newPricetextBox.TabIndex = 30;
            this.newPricetextBox.Text = "Введите сумму";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(570, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "дн";
            // 
            // MakeDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(56)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newPricetextBox);
            this.Controls.Add(this.deleteDiscountButton);
            this.Controls.Add(this.hackTypeComboBox);
            this.Controls.Add(this.deviceTypeComboBox);
            this.Controls.Add(this.CreateDiscountButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.durationOfDiscountHackTextBox);
            this.Controls.Add(this.resellerNameTextBox);
            this.Name = "MakeDiscountForm";
            this.Text = "MakeDiscountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox resellerNameTextBox;
        private TextBox durationOfDiscountHackTextBox;
        private Label label1;
        private Button CreateDiscountButton;
        private ComboBox deviceTypeComboBox;
        private ComboBox hackTypeComboBox;
        private Button deleteDiscountButton;
        private TextBox newPricetextBox;
        private Label label2;
    }
}