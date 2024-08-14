namespace TestForTutorial
{
    partial class DeleteDiscountForm
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
            this.isResellerLabel = new System.Windows.Forms.Label();
            this.discountIdTextBox = new System.Windows.Forms.TextBox();
            this.removeResellerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resellerNameTextBox
            // 
            this.resellerNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.resellerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resellerNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resellerNameTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.resellerNameTextBox.Location = new System.Drawing.Point(173, 72);
            this.resellerNameTextBox.Multiline = true;
            this.resellerNameTextBox.Name = "resellerNameTextBox";
            this.resellerNameTextBox.Size = new System.Drawing.Size(297, 36);
            this.resellerNameTextBox.TabIndex = 14;
            this.resellerNameTextBox.Text = "Введите имя ресселера";
            this.resellerNameTextBox.TextChanged += new System.EventHandler(this.resellerNameTextBox_TextChanged);
            // 
            // isResellerLabel
            // 
            this.isResellerLabel.AutoSize = true;
            this.isResellerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.isResellerLabel.ForeColor = System.Drawing.Color.Lime;
            this.isResellerLabel.Location = new System.Drawing.Point(495, 77);
            this.isResellerLabel.Name = "isResellerLabel";
            this.isResellerLabel.Size = new System.Drawing.Size(150, 23);
            this.isResellerLabel.TabIndex = 16;
            this.isResellerLabel.Text = "Реселлер найден!";
            this.isResellerLabel.Visible = false;
            // 
            // discountIdTextBox
            // 
            this.discountIdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.discountIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.discountIdTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.discountIdTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.discountIdTextBox.Location = new System.Drawing.Point(173, 146);
            this.discountIdTextBox.Multiline = true;
            this.discountIdTextBox.Name = "discountIdTextBox";
            this.discountIdTextBox.Size = new System.Drawing.Size(297, 36);
            this.discountIdTextBox.TabIndex = 17;
            this.discountIdTextBox.Text = "Введите ID скидки";
            // 
            // removeResellerButton
            // 
            this.removeResellerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeResellerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.removeResellerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.removeResellerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeResellerButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeResellerButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.removeResellerButton.Location = new System.Drawing.Point(12, 473);
            this.removeResellerButton.Name = "removeResellerButton";
            this.removeResellerButton.Size = new System.Drawing.Size(158, 54);
            this.removeResellerButton.TabIndex = 19;
            this.removeResellerButton.Text = "Удалить скидку";
            this.removeResellerButton.UseVisualStyleBackColor = false;
            this.removeResellerButton.Click += new System.EventHandler(this.removeResellerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Данные о скидках:";
            // 
            // DeleteDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(56)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(835, 539);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.removeResellerButton);
            this.Controls.Add(this.discountIdTextBox);
            this.Controls.Add(this.isResellerLabel);
            this.Controls.Add(this.resellerNameTextBox);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "DeleteDiscountForm";
            this.Text = "DeleteDiscountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox resellerNameTextBox;
        private Label isResellerLabel;
        private TextBox discountIdTextBox;
        private Button removeResellerButton;
        private Label label2;
    }
}