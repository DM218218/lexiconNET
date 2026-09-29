namespace Castle
{
    partial class BuildDialog
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
            allowedDevelopmentsListBox = new ListBox();
            buildButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            wealthCostLabel = new Label();
            resourceCostBox = new TextBox();
            SuspendLayout();
            // 
            // allowedDevelopmentsListBox
            // 
            allowedDevelopmentsListBox.FormattingEnabled = true;
            allowedDevelopmentsListBox.Location = new Point(43, 47);
            allowedDevelopmentsListBox.Name = "allowedDevelopmentsListBox";
            allowedDevelopmentsListBox.Size = new Size(204, 289);
            allowedDevelopmentsListBox.TabIndex = 0;
            // 
            // buildButton
            // 
            buildButton.DialogResult = DialogResult.OK;
            buildButton.Location = new Point(43, 374);
            buildButton.Name = "buildButton";
            buildButton.Size = new Size(100, 33);
            buildButton.TabIndex = 1;
            buildButton.Text = "Build";
            buildButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(149, 374);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(98, 33);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 47);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Costs";
            // 
            // wealthCostLabel
            // 
            wealthCostLabel.AutoSize = true;
            wealthCostLabel.Location = new Point(286, 76);
            wealthCostLabel.Name = "wealthCostLabel";
            wealthCostLabel.Size = new Size(68, 15);
            wealthCostLabel.TabIndex = 4;
            wealthCostLabel.Text = "WealthCost";
            // 
            // resourceCostBox
            // 
            resourceCostBox.BorderStyle = BorderStyle.None;
            resourceCostBox.Location = new Point(286, 145);
            resourceCostBox.Multiline = true;
            resourceCostBox.Name = "resourceCostBox";
            resourceCostBox.Size = new Size(153, 191);
            resourceCostBox.TabIndex = 5;
            resourceCostBox.Text = "ResourceCost";
            // 
            // BuildDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 438);
            Controls.Add(resourceCostBox);
            Controls.Add(wealthCostLabel);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(buildButton);
            Controls.Add(allowedDevelopmentsListBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BuildDialog";
            Text = "BuildDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox allowedDevelopmentsListBox;
        private Button buildButton;
        private Button cancelButton;
        private Label label1;
        private Label wealthCostLabel;
        private TextBox resourceCostBox;
    }
}