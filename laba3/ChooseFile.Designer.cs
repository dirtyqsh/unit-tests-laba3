
namespace laba3
{
    partial class AddFileForm
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
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.FileLabel = new System.Windows.Forms.Label();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.FileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(13, 9);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(201, 20);
            this.ErrorLabel.TabIndex = 0;
            this.ErrorLabel.Text = "Неверное имя директории.";
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Location = new System.Drawing.Point(13, 40);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(45, 20);
            this.FileLabel.TabIndex = 1;
            this.FileLabel.Text = "Файл";
            // 
            // FileTextBox
            // 
            this.FileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTextBox.Location = new System.Drawing.Point(64, 37);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.Size = new System.Drawing.Size(425, 27);
            this.FileTextBox.TabIndex = 2;
            // 
            // FileButton
            // 
            this.FileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileButton.Location = new System.Drawing.Point(64, 70);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(425, 29);
            this.FileButton.TabIndex = 3;
            this.FileButton.Text = "Выбрать файл";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // AddFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 186);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.FileTextBox);
            this.Controls.Add(this.FileLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Name = "AddFileForm";
            this.Text = "Выбор файла";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.Button FileButton;
    }
}

