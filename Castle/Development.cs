using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Castle
{
    internal class Development
    {
        public enum DevelopmentType
        {
            Baker,
            Smith,
            Mill,
            Well,
            DoveCot,
            Tanner,
            Treasury,
            Tailor,
            Garden,
            Stables,
            WatchTower,
            Scriptorium,
            Library,
            Butcher,
            GrainField,
            Orchard,
            CowPen,
            SheepPen,
            GoatPen,
            ChickenCoop,
            PigPen,
            Quarry,
            Mine,
            Smelter,
            Weaver,
            VegetableField
        }

        private DevelopmentType type;
        private string name;
        private bool multipleAllowed;
        private int wealthUpkeep;
        private int wealthIncome;
        private Dictionary<ResourceType, int> resourceUpkeep;
        private Dictionary<ResourceType, int> resourceIncome;

        internal DevelopmentType Type { get => type; }
        public bool MultipleAllowed { get => multipleAllowed; }

        public Development()
        {
            resourceUpkeep = new Dictionary<ResourceType, int>();
            resourceIncome = new Dictionary<ResourceType, int>();
        }

        public string getName()
        {
            return name;
        }

        public void setType(DevelopmentType type)
        {
            this.type = type;

            switch (type)
            {
                case DevelopmentType.Baker:
                    name = "Baker";
                    wealthUpkeep = 12;
                    wealthIncome = 15;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Flour, 8);
                    resourceIncome.Add(ResourceType.Bread, 4);
                    break;
                case DevelopmentType.Butcher:
                    name = "Butcher";
                    wealthUpkeep = 8;
                    wealthIncome = 10;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Carcass, 3);
                    resourceIncome.Add(ResourceType.Meat, 5);
                    resourceIncome.Add(ResourceType.Hides, 2);
                    break;
                case DevelopmentType.ChickenCoop:
                    name = "Chicken Coop";
                    wealthUpkeep = 0;
                    wealthIncome = 0;

                    resourceUpkeep.Add(ResourceType.Grain, 2);
                    resourceIncome.Add(ResourceType.Carcass, 1);
                    multipleAllowed = true;
                    break;
                case DevelopmentType.CowPen:
                    name = "Cow Pen";
                    wealthUpkeep = 1;
                    wealthIncome = 0;

                    resourceUpkeep.Add(ResourceType.Grain, 6);
                    resourceIncome.Add(ResourceType.Carcass, 4);
                    multipleAllowed = true;
                    break;
                case DevelopmentType.DoveCot:
                    name = "Dove Cot";
                    wealthUpkeep = 2;
                    wealthIncome = 5;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Grain, 1);
                    break;
                case DevelopmentType.Tailor:
                    name = "Tailor";
                    wealthUpkeep = 16;
                    wealthIncome = 28;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Cloth, 6);
                    resourceIncome.Add(ResourceType.Clothes, 3);
                    break;
                case DevelopmentType.GrainField:
                    name = "Grain Field";
                    wealthUpkeep = 0;
                    wealthIncome = 0;
                    multipleAllowed = true;

                    resourceIncome.Add(ResourceType.Grain, 7);
                    break;
                case DevelopmentType.Garden:
                    name = "Herb Garden";
                    wealthUpkeep = 7;
                    wealthIncome = 14;
                    multipleAllowed = false;
                    break;
                case DevelopmentType.GoatPen:
                    name = "Goat Pen";
                    wealthUpkeep = 1;
                    wealthIncome = 0;
                    multipleAllowed = true;

                    resourceUpkeep.Add(ResourceType.Grain, 2);
                    resourceIncome.Add(ResourceType.Carcass, 2);
                    break;
                case DevelopmentType.Library:
                    name = "Library";
                    wealthUpkeep = 20;
                    wealthIncome = 27;
                    multipleAllowed = false;
                    break;
                case DevelopmentType.Mill:
                    name = "Grain Mill";
                    wealthUpkeep = 7;
                    wealthIncome = 10;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Grain, 12);
                    resourceIncome.Add(ResourceType.Flour, 8);
                    break;
                case DevelopmentType.Orchard:
                    name = "Fruit Orchard";
                    wealthUpkeep = 2;
                    wealthIncome = 0;
                    multipleAllowed = true;

                    resourceIncome.Add(ResourceType.Fruit, 5);
                    break;
                case DevelopmentType.PigPen:
                    name = "Pig Pen";
                    wealthUpkeep = 0;
                    wealthIncome = 0;
                    multipleAllowed = true;

                    resourceUpkeep.Add(ResourceType.Grain, 4);
                    resourceIncome.Add(ResourceType.Carcass, 3);
                    break;
                case DevelopmentType.Scriptorium:
                    name = "Scriptorium";
                    wealthUpkeep = 30;
                    wealthIncome = 46;
                    multipleAllowed = false;
                    break;
                case DevelopmentType.SheepPen:
                    name = "Sheep Pen";
                    wealthUpkeep = 4;
                    wealthIncome = 4;
                    multipleAllowed = true;

                    resourceUpkeep.Add(ResourceType.Grain, 4);
                    resourceUpkeep.Add(ResourceType.Vegetables, 2);
                    resourceIncome.Add(ResourceType.Wool, 8);
                    break;
                case DevelopmentType.Smith:
                    name = "Smith";
                    wealthUpkeep = 16;
                    wealthIncome = 38;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Iron, 2);
                    break;
                case DevelopmentType.Stables:
                    name = "Stable";
                    wealthUpkeep = 10;
                    wealthIncome = 22;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Grain, 2);
                    break;
                case DevelopmentType.Tanner:
                    name = "Tanner";
                    wealthUpkeep = 6;
                    wealthIncome = 11;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Hides, 4);
                    resourceIncome.Add(ResourceType.Leather, 7);
                    break;
                case DevelopmentType.Treasury:
                    name = "Treasury";
                    wealthUpkeep = 10;
                    wealthIncome = 0;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Iron, 1);
                    resourceUpkeep.Add(ResourceType.Stone, 1);
                    break;
                case DevelopmentType.WatchTower:
                    name = "Watch Tower";
                    wealthUpkeep = 4;
                    wealthIncome = 0;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Wood, 2);
                    break;
                case DevelopmentType.Well:
                    name = "Well";
                    wealthUpkeep = 0;
                    wealthIncome = 1;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Wood, 1);
                    break;
                case DevelopmentType.Quarry:
                    name = "Quarry";
                    wealthUpkeep = 3;
                    wealthIncome= 2;
                    multipleAllowed = true;

                    resourceUpkeep.Add(ResourceType.Wood, 4);
                    resourceIncome.Add(ResourceType.Stone, 9);
                    break;
                case DevelopmentType.Weaver:
                    name = "Weaver";
                    wealthUpkeep = 10;
                    wealthIncome = 14;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Wool, 14);
                    resourceIncome.Add(ResourceType.Cloth, 7);
                    break;
                case DevelopmentType.Mine:
                    name = "Mine";
                    wealthUpkeep = 4;
                    wealthIncome = 0;
                    multipleAllowed = true;

                    resourceUpkeep.Add(ResourceType.Wood, 4);
                    resourceIncome.Add(ResourceType.Ore, 7);
                    break;
                case DevelopmentType.Smelter:
                    name = "Smelter";
                    wealthUpkeep = 9;
                    wealthIncome = 15;
                    multipleAllowed = false;

                    resourceUpkeep.Add(ResourceType.Ore, 9);
                    resourceIncome.Add(ResourceType.Leather, 3);
                    break;
                case DevelopmentType.VegetableField:
                    name = "Vegetable Field";
                    wealthUpkeep = 1;
                    wealthIncome = 0;
                    multipleAllowed = true;

                    resourceIncome.Add(ResourceType.Vegetables, 4);
                    break;
                default:
                    name = "Error";
                    multipleAllowed = false;
                    wealthUpkeep = 0;
                    wealthIncome = 0;
                    break;
            }
        }

        internal int GetWealthIncome()
        {
            return wealthIncome;
        }

        internal int GetWealthUpkeep()
        {
            return wealthUpkeep;
        }

        internal Dictionary<ResourceType, int> GetResourceUpkeep()
        {
            return resourceUpkeep;
        }

        internal Dictionary<ResourceType, int> GetResourceIncome()
        {
            return resourceIncome;
        }
    }
}