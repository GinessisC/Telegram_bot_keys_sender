namespace TestForTutorial
{
    partial class AddReselerForm
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
            this.addResellerButton = new System.Windows.Forms.Button();
            this.removeResellerButton = new System.Windows.Forms.Button();
            this.isResellerFoundLabel = new System.Windows.Forms.Label();
            this.resellerFoundLabel = new System.Windows.Forms.Label();
            this.userIsNotFoundLabel = new System.Windows.Forms.Label();
            this.userIsFoundLabel = new System.Windows.Forms.Label();
            this.resellerBalanceTextBox = new System.Windows.Forms.TextBox();
            this.changeBalanceButton = new System.Windows.Forms.Button();
            this.MakeDiscountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resellerNameTextBox
            // 
            this.resellerNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.resellerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resellerNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resellerNameTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.resellerNameTextBox.Location = new System.Drawing.Point(181, 158);
            this.resellerNameTextBox.Multiline = true;
            this.resellerNameTextBox.Name = "resellerNameTextBox";
            this.resellerNameTextBox.Size = new System.Drawing.Size(297, 36);
            this.resellerNameTextBox.TabIndex = 12;
            this.resellerNameTextBox.Text = "Введите имя ресселера";
            this.resellerNameTextBox.TextChanged += new System.EventHandler(this.resellerNameTextBox_TextChanged);
            // 
            // addResellerButton
            // 
            this.addResellerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addResellerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.addResellerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addResellerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addResellerButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addResellerButton.ForeColor = System.Drawing.Color.Chartreuse;
            this.addResellerButton.Location = new System.Drawing.Point(472, 334);
            this.addResellerButton.Name = "addResellerButton";
            this.addResellerButton.Size = new System.Drawing.Size(158, 54);
            this.addResellerButton.TabIndex = 17;
            this.addResellerButton.Text = "Добавить";
            this.addResellerButton.UseVisualStyleBackColor = false;
            this.addResellerButton.Click += new System.EventHandler(this.addResellerButton_Click);
            // 
            // removeResellerButton
            // 
            this.removeResellerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeResellerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.removeResellerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.removeResellerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeResellerButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeResellerButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.removeResellerButton.Location = new System.Drawing.Point(39, 334);
            this.removeResellerButton.Name = "removeResellerButton";
            this.removeResellerButton.Size = new System.Drawing.Size(158, 54);
            this.removeResellerButton.TabIndex = 18;
            this.removeResellerButton.Text = "Удалить";
            this.removeResellerButton.UseVisualStyleBackColor = false;
            this.removeResellerButton.Click += new System.EventHandler(this.removeResellerButton_Click);
            // 
            // isResellerFoundLabel
            // 
            this.isResellerFoundLabel.AutoSize = true;
            this.isResellerFoundLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.isResellerFoundLabel.Location = new System.Drawing.Point(181, 216);
            this.isResellerFoundLabel.Name = "isResellerFoundLabel";
            this.isResellerFoundLabel.Size = new System.Drawing.Size(168, 23);
            this.isResellerFoundLabel.TabIndex = 19;
            this.isResellerFoundLabel.Text = "Ресселер не найден";
            // 
            // resellerFoundLabel
            // 
            this.resellerFoundLabel.AutoSize = true;
            this.resellerFoundLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resellerFoundLabel.ForeColor = System.Drawing.Color.Chartreuse;
            this.resellerFoundLabel.Location = new System.Drawing.Point(181, 216);
            this.resellerFoundLabel.Name = "resellerFoundLabel";
            this.resellerFoundLabel.Size = new System.Drawing.Size(144, 23);
            this.resellerFoundLabel.TabIndex = 20;
            this.resellerFoundLabel.Text = "Ресселер найден";
            this.resellerFoundLabel.Visible = false;
            // 
            // userIsNotFoundLabel
            // 
            this.userIsNotFoundLabel.AutoSize = true;
            this.userIsNotFoundLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userIsNotFoundLabel.ForeColor = System.Drawing.Color.White;
            this.userIsNotFoundLabel.Location = new System.Drawing.Point(181, 253);
            this.userIsNotFoundLabel.Name = "userIsNotFoundLabel";
            this.userIsNotFoundLabel.Size = new System.Drawing.Size(214, 23);
            this.userIsNotFoundLabel.TabIndex = 21;
            this.userIsNotFoundLabel.Text = "Пользователя нету в боте";
            // 
            // userIsFoundLabel
            // 
            this.userIsFoundLabel.AutoSize = true;
            this.userIsFoundLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userIsFoundLabel.ForeColor = System.Drawing.Color.Chartreuse;
            this.userIsFoundLabel.Location = new System.Drawing.Point(181, 253);
            this.userIsFoundLabel.Name = "userIsFoundLabel";
            this.userIsFoundLabel.Size = new System.Drawing.Size(213, 23);
            this.userIsFoundLabel.TabIndex = 22;
            this.userIsFoundLabel.Text = "Пользователь есть в боте";
            this.userIsFoundLabel.Visible = false;
            // 
            // resellerBalanceTextBox
            // 
            this.resellerBalanceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.resellerBalanceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resellerBalanceTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resellerBalanceTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.resellerBalanceTextBox.Location = new System.Drawing.Point(181, 88);
            this.resellerBalanceTextBox.Multiline = true;
            this.resellerBalanceTextBox.Name = "resellerBalanceTextBox";
            this.resellerBalanceTextBox.Size = new System.Drawing.Size(297, 36);
            this.resellerBalanceTextBox.TabIndex = 23;
            this.resellerBalanceTextBox.Text = "Баланс";
            // 
            // changeBalanceButton
            // 
            this.changeBalanceButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.changeBalanceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.changeBalanceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.changeBalanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeBalanceButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.changeBalanceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.changeBalanceButton.Location = new System.Drawing.Point(242, 334);
            this.changeBalanceButton.Name = "changeBalanceButton";
            this.changeBalanceButton.Size = new System.Drawing.Size(187, 54);
            this.changeBalanceButton.TabIndex = 24;
            this.changeBalanceButton.Text = "Изменить баланс";
            this.changeBalanceButton.UseVisualStyleBackColor = false;
            this.changeBalanceButton.Click += new System.EventHandler(this.changeBalanceButton_Click);
            // 
            // MakeDiscountButton
            // 
            this.MakeDiscountButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MakeDiscountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.MakeDiscountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MakeDiscountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MakeDiscountButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MakeDiscountButton.ForeColor = System.Drawing.Color.Fuchsia;
            this.MakeDiscountButton.Location = new System.Drawing.Point(255, 425);
            this.MakeDiscountButton.Name = "MakeDiscountButton";
            this.MakeDiscountButton.Size = new System.Drawing.Size(158, 54);
            this.MakeDiscountButton.TabIndex = 25;
            this.MakeDiscountButton.Text = "Сделать скидку";
            this.MakeDiscountButton.UseVisualStyleBackColor = false;
            this.MakeDiscountButton.Click += new System.EventHandler(this.MakeDiscountButton_Click);
            // 
            // AddReselerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(56)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(662, 511);
            this.Controls.Add(this.MakeDiscountButton);
            this.Controls.Add(this.changeBalanceButton);
            this.Controls.Add(this.resellerBalanceTextBox);
            this.Controls.Add(this.userIsFoundLabel);
            this.Controls.Add(this.userIsNotFoundLabel);
            this.Controls.Add(this.resellerFoundLabel);
            this.Controls.Add(this.isResellerFoundLabel);
            this.Controls.Add(this.removeResellerButton);
            this.Controls.Add(this.addResellerButton);
            this.Controls.Add(this.resellerNameTextBox);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "AddReselerForm";
            this.Text = "AddReselerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox resellerNameTextBox;
        private Button addResellerButton;
        private Button removeResellerButton;
        private Label isResellerFoundLabel;
        private Label resellerFoundLabel;
        private Label userIsNotFoundLabel;
        private Label userIsFoundLabel;
        private TextBox resellerBalanceTextBox;
        private Button changeBalanceButton;
        private Button MakeDiscountButton;
    }
}