using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Castle
{
    public partial class GameWindow : Form
    {
        private GameMain gameMain;
        private BuildDialog buildDialog;
        private int turn = 0;

        public GameWindow()
        {
            InitializeComponent();

            this.FormClosed += GameWindow_FormClosed;
        }

        public GameWindow(int investment, int background)
        {
            InitializeComponent();

            //make game object
            gameMain = new GameMain(investment, background);
            buildDialog = new BuildDialog(gameMain.getCastle());

            UpdateWindowData();

            this.FormClosed += GameWindow_FormClosed;
        }

        private void UpdateWindowData()
        {
            CastleObject castle = gameMain.getCastle();
            UpdateResources(castle);
            int income = castle.GetWealthIncome();
            int upkeep = castle.GetWealthUpkeep();
            int resourceDeficit = castle.GetResourceDeficitInWealth();
            int balance = income - upkeep + resourceDeficit; //resource deficit is negative

            this.descriptionBox.Text = "";
            this.developmentsListBox.Items.Clear();

            this.descriptionBox.Text =
                $"A {castle.getHoldLevelAsText().ToLower()} in a clearing by a " +
                $"{castle.GetVillageLevelAsText().ToLower()} surrounded by " +
                $"{castle.GetEnvironmentDescriptor()}.";

            var constructedDevs = castle.GetConstructedDevelopments();
            foreach (var development in constructedDevs)
            {
                this.developmentsListBox.Items.Add(development);
            }

            this.populationLabel.Text = $"{castle.GetPopulation()}";
            this.guardsLabel.Text = $"{castle.GetGuards()}";
            this.neededWorkersLabel.Text = $"{castle.GetNeededWorkers()}";
            this.workersLabel.Text = $"{castle.GetPopulation() - castle.GetNeededWorkers()}";
            this.foodDemandLabel.Text = $"{castle.GetFoodDemand()}";
            this.availableFoodLabel.Text = $"{castle.GetAvailableFood()}";

            this.incomeLabel.Text = FormatCurrency(income);
            this.expenseLabel.Text = FormatCurrency(0 - upkeep + resourceDeficit); //resource deficit is negative
            this.balanceLabel.Text = FormatCurrency(balance);

            if ((income - upkeep + resourceDeficit) < 0) //resource deficit is negative
            {
                this.balanceLabel.ForeColor = Color.Red;
            }
            else
            {
                this.balanceLabel.ForeColor = Color.Black;
            }

            DisplayWealth(castle.GetWealth());
        }

        private void UpdateResources(CastleObject castle)
        {
            Dictionary<ResourceType, int> resFlow = castle.GetResourceFlow();

            foreach (var resType in Enum.GetValues(typeof(ResourceType)))
            {
                ResourceType resourceType = (ResourceType)resType;

                switch (resourceType)
                {
                    case ResourceType.Wood:
                        this.woodLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.woodFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Stone:
                        this.stoneLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.stoneFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Ore:
                        this.oreLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.oreFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Iron:
                        this.ironLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.ironFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Wool:
                        this.woolLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.woolFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Cloth:
                        this.clothLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.clothFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Leather:
                        this.leatherLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.leatherFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Grain:
                        this.grainLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.grainFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Vegetables:
                        this.vegetablesLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.vegetablesFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Meat:
                        this.meatLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.meatFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Flour:
                        this.flourLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.flourFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Bread:
                        this.breadLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.breadFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Fruit:
                        this.fruitLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.fruitFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Clothes:
                        this.clothesLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.clothesFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Carcass:
                        this.carcassLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.carcassFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    case ResourceType.Hides:
                        this.hidesLabel.Text = $"{castle.GetAmountOfHoldingResource(resourceType)}";
                        this.hidesFlowLabel.Text = $"{resFlow[resourceType]}";
                        break;
                    default:
                        break;

                }
            }
        }

        private void DisplayWealth(int wealth)
        {
            this.wealthLabel.Text = FormatCurrency(wealth); ;
        }

        private string FormatCurrency(int wealth)
        {
            string formattedWealth = "";
            int tempWealthS = 0;
            int tempWealthC = 0;

            tempWealthS = wealth % 10000;
            tempWealthC = tempWealthS % 100;
            formattedWealth += $"{wealth / 10000} gold\n{tempWealthS / 100} silver\n{tempWealthC} copper";

            return formattedWealth;
        }

        private void GameWindow_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void turnButton_Click(object sender, EventArgs e)
        {
            gameMain.NewTurn();
            UpdateWindowData();

            this.turnButton.Text = $"Next Turn\t{++turn}";

            this.Refresh();
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            DialogResult result = buildDialog.ShowDialog();

            if(result == DialogResult.OK)
            {

            }
            else if (result == DialogResult.Cancel)
            {

            }
        }

        private void demolishButton_Click(object sender, EventArgs e)
        {
            Development development = (Development)this.developmentsListBox.SelectedItem;
            gameMain.getCastle().RemoveDevelopment( development.Type );
            this.demolishButton.Enabled = false;
            this.developmentsListBox.SelectedIndex = -1;
            UpdateWindowData();
        }

        private void developmentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.developmentsListBox.SelectedItem != null)
            {
                this.demolishButton.Enabled = true;
            }
        }
    }
}
