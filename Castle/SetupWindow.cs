using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Castle
{
    public partial class SetupWindow : Form
    {
        public SetupWindow()
        {
            InitializeComponent();

            this.FormClosed += SetupWindow_FormClosed;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int investment = getInvestment();
            int background = getBackground();

            GameWindow gameWindow = new GameWindow(investment, background);
            this.Hide();
            gameWindow.Show();
        }

        private int getInvestment()
        {
            int result = 0;

            foreach (RadioButton option in this.startInvestmentGroupBox.Controls)
            {
                if (option.Checked)
                {
                    if(option == this.modestRadioButton)
                    {
                        result = 0;
                    }
                    else if (option == this.bigRadioButton)
                    {
                        result = 1;
                    }
                    else if (option == this.greatRadioButton)
                    {
                        result = 2;
                    }
                    else if (option == this.extravagantRadioButton)
                    {
                        result = 3;
                    }
                    else
                    {
                        //Error
                        Console.WriteLine("Unkown investment.");
                    }
                }
            }

            return result;
        }

        private int getBackground()
        {
            int result = 0;

            foreach (RadioButton option in this.backgroundGroupBox.Controls)
            {
                if (option.Checked)
                {
                    if (option == merchantRadioButton)
                    {
                        result = 0;
                    }
                    else if (option == nobleRadioButton)
                    {
                        result = 1;
                    }
                    else if (option == elderRadioButton)
                    {
                        result = 2;
                    }
                    else if (option == adventurerRadioButton)
                    {
                        result = 3;
                    }
                }
            }

            return result;
        }

        private void SetupWindow_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
