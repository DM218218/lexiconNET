namespace Castle
{
    partial class SetupWindow
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
            startInvestmentGroupBox = new GroupBox();
            extravagantRadioButton = new RadioButton();
            greatRadioButton = new RadioButton();
            bigRadioButton = new RadioButton();
            modestRadioButton = new RadioButton();
            backgroundGroupBox = new GroupBox();
            adventurerRadioButton = new RadioButton();
            elderRadioButton = new RadioButton();
            nobleRadioButton = new RadioButton();
            merchantRadioButton = new RadioButton();
            startButton = new Button();
            startInvestmentGroupBox.SuspendLayout();
            backgroundGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // startInvestmentGroupBox
            // 
            startInvestmentGroupBox.Controls.Add(extravagantRadioButton);
            startInvestmentGroupBox.Controls.Add(greatRadioButton);
            startInvestmentGroupBox.Controls.Add(bigRadioButton);
            startInvestmentGroupBox.Controls.Add(modestRadioButton);
            startInvestmentGroupBox.Location = new Point(83, 88);
            startInvestmentGroupBox.Name = "startInvestmentGroupBox";
            startInvestmentGroupBox.Size = new Size(171, 153);
            startInvestmentGroupBox.TabIndex = 0;
            startInvestmentGroupBox.TabStop = false;
            startInvestmentGroupBox.Text = "How great an investment will you do?";
            // 
            // extravagantRadioButton
            // 
            extravagantRadioButton.AutoSize = true;
            extravagantRadioButton.Location = new Point(25, 119);
            extravagantRadioButton.Name = "extravagantRadioButton";
            extravagantRadioButton.Size = new Size(87, 19);
            extravagantRadioButton.TabIndex = 3;
            extravagantRadioButton.Text = "Extravagant";
            extravagantRadioButton.UseVisualStyleBackColor = true;
            // 
            // greatRadioButton
            // 
            greatRadioButton.AutoSize = true;
            greatRadioButton.Location = new Point(25, 94);
            greatRadioButton.Name = "greatRadioButton";
            greatRadioButton.Size = new Size(53, 19);
            greatRadioButton.TabIndex = 2;
            greatRadioButton.Text = "Great";
            greatRadioButton.UseVisualStyleBackColor = true;
            // 
            // bigRadioButton
            // 
            bigRadioButton.AutoSize = true;
            bigRadioButton.Location = new Point(25, 69);
            bigRadioButton.Name = "bigRadioButton";
            bigRadioButton.Size = new Size(42, 19);
            bigRadioButton.TabIndex = 1;
            bigRadioButton.Text = "Big";
            bigRadioButton.UseVisualStyleBackColor = true;
            // 
            // modestRadioButton
            // 
            modestRadioButton.AutoSize = true;
            modestRadioButton.Checked = true;
            modestRadioButton.Location = new Point(25, 44);
            modestRadioButton.Name = "modestRadioButton";
            modestRadioButton.Size = new Size(65, 19);
            modestRadioButton.TabIndex = 0;
            modestRadioButton.TabStop = true;
            modestRadioButton.Text = "Modest";
            modestRadioButton.UseVisualStyleBackColor = true;
            // 
            // backgroundGroupBox
            // 
            backgroundGroupBox.Controls.Add(adventurerRadioButton);
            backgroundGroupBox.Controls.Add(elderRadioButton);
            backgroundGroupBox.Controls.Add(nobleRadioButton);
            backgroundGroupBox.Controls.Add(merchantRadioButton);
            backgroundGroupBox.Location = new Point(260, 88);
            backgroundGroupBox.Name = "backgroundGroupBox";
            backgroundGroupBox.Size = new Size(200, 194);
            backgroundGroupBox.TabIndex = 1;
            backgroundGroupBox.TabStop = false;
            backgroundGroupBox.Text = "Who are you?";
            // 
            // adventurerRadioButton
            // 
            adventurerRadioButton.AutoSize = true;
            adventurerRadioButton.Location = new Point(16, 134);
            adventurerRadioButton.Name = "adventurerRadioButton";
            adventurerRadioButton.Size = new Size(136, 19);
            adventurerRadioButton.TabIndex = 3;
            adventurerRadioButton.Text = "A famous adventurer";
            adventurerRadioButton.UseVisualStyleBackColor = true;
            // 
            // elderRadioButton
            // 
            elderRadioButton.AutoSize = true;
            elderRadioButton.Location = new Point(16, 109);
            elderRadioButton.Name = "elderRadioButton";
            elderRadioButton.Size = new Size(99, 19);
            elderRadioButton.TabIndex = 2;
            elderRadioButton.Text = "A village elder";
            elderRadioButton.UseVisualStyleBackColor = true;
            // 
            // nobleRadioButton
            // 
            nobleRadioButton.AutoSize = true;
            nobleRadioButton.Location = new Point(16, 69);
            nobleRadioButton.Name = "nobleRadioButton";
            nobleRadioButton.Size = new Size(142, 34);
            nobleRadioButton.TabIndex = 1;
            nobleRadioButton.Text = "A nobleman assigned \r\nby the king";
            nobleRadioButton.UseVisualStyleBackColor = true;
            // 
            // merchantRadioButton
            // 
            merchantRadioButton.AutoSize = true;
            merchantRadioButton.Checked = true;
            merchantRadioButton.Location = new Point(16, 44);
            merchantRadioButton.Name = "merchantRadioButton";
            merchantRadioButton.Size = new Size(131, 19);
            merchantRadioButton.TabIndex = 0;
            merchantRadioButton.TabStop = true;
            merchantRadioButton.Text = "A wealthy merchant";
            merchantRadioButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            startButton.Location = new Point(83, 259);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 2;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // SetupWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 352);
            Controls.Add(startButton);
            Controls.Add(backgroundGroupBox);
            Controls.Add(startInvestmentGroupBox);
            Name = "SetupWindow";
            Text = "SetupWindow";
            startInvestmentGroupBox.ResumeLayout(false);
            startInvestmentGroupBox.PerformLayout();
            backgroundGroupBox.ResumeLayout(false);
            backgroundGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox startInvestmentGroupBox;
        private RadioButton extravagantRadioButton;
        private RadioButton greatRadioButton;
        private RadioButton bigRadioButton;
        private RadioButton modestRadioButton;
        private GroupBox backgroundGroupBox;
        private RadioButton nobleRadioButton;
        private RadioButton merchantRadioButton;
        private Button startButton;
        private RadioButton adventurerRadioButton;
        private RadioButton elderRadioButton;
    }
}