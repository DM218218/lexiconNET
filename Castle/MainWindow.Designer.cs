namespace Castle
{
    partial class MainWindow
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
            StartNewButton = new Button();
            QuitButton = new Button();
            SuspendLayout();
            // 
            // StartNewButton
            // 
            StartNewButton.Location = new Point(299, 174);
            StartNewButton.Name = "StartNewButton";
            StartNewButton.Size = new Size(156, 36);
            StartNewButton.TabIndex = 0;
            StartNewButton.Text = "Start New";
            StartNewButton.UseVisualStyleBackColor = true;
            StartNewButton.Click += StartNewButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(299, 260);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(156, 36);
            QuitButton.TabIndex = 1;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 450);
            Controls.Add(QuitButton);
            Controls.Add(StartNewButton);
            Name = "MainWindow";
            Text = "Castle";
            ResumeLayout(false);
        }

        #endregion

        private Button StartNewButton;
        private Button QuitButton;
    }
}
