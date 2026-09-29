using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Castle
{
    public partial class BuildDialog : Form
    {
        private CastleObject castle;
        List<DevelopmentType> allowedDevelopments;

        private BuildDialog()
        {
            InitializeComponent();
        }

        public BuildDialog(CastleObject castle)
        {
            InitializeComponent();

            this.castle = castle;
        }

        public void PopulateDevelopmentList()
        {
            allowedDevelopments = castle.GetAllowedDevelopments();

            foreach (DevelopmentType type in allowedDevelopments)
            {
                this.allowedDevelopmentsListBox.Items.Add(castle.GetDevelopment(type));
            }
        }

        public void ClearDevelopmentList()
        {  
            allowedDevelopmentsListBox.Items.Clear(); 
        }
    }
}
