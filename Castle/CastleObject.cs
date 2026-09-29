using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using static Castle.Development;

namespace Castle
{
    enum Background
    {
        Merchant = 0,
        Nobel,
        Elder,
        Adventurer
    }

    public class CastleObject
    {
        private int investment;
        private int holdLevel;
        private int wealth;
        private int population;
        private int guards;
        private int totalWorkerNeed;
        private Background background;
        private Dictionary<DevelopmentType, int> holdingDevelopments;
        private Dictionary<ResourceType, int> holdingResources;
        private Dictionary<DevelopmentType, Development> developments;
        private Dictionary<ResourceType, Resource> resources;
        private Dictionary<ResourceType, int> resourceFlow;
        private Random randomGenerator;
        private int seed;
        private string environmentText;

        public CastleObject(int investment, int background)
        {
            seed = (int)DateTime.UtcNow.Ticks;
            randomGenerator = new Random(seed);
            this.investment = investment;
            this.background = (Background)background;
            holdingDevelopments = new Dictionary<DevelopmentType, int>();
            holdingResources = new Dictionary<ResourceType, int>();
            resourceFlow = new Dictionary<ResourceType, int>();

            Initialize();
        }

        private void Initialize()
        {
            PopulateResources();
            PopulateDevelopments();

            if (investment == 0)
            {
                holdLevel = 1;
            }
            else if (investment == 1)
            {
                holdLevel = 2;
            }
            else if (investment == 2)
            {
                holdLevel = 3;
            }
            else if (investment == 3)
            {
                holdLevel = 4;
            }
            else
            {
                //Error something's wrong
                holdLevel = 0;
            }

            GenerateStartingWealth();
            GenerateStartingDevelopments();

            if(background  == Background.Merchant)
            {
                population = 9 * (investment + 1);
                guards = investment + 1;
            }
            else if (background == Background.Nobel)
            {
                population = 5 * (investment + 1);
                guards = investment + 3;
                holdLevel++;
            }
            else if (background == Background.Elder)
            {
                population = 13 * (investment + 1);
                guards = investment;
            }
            else if (background == Background.Adventurer)
            {
                population = 7 * (investment + 1);
                guards = investment + 1;
            }
            else
            {
                //Error something's wrong
                population = 0;
                guards = 0;

            }

            environmentText = "thick forests";
            UpdateResourceFlow();
            UpdateWorkerNeed();

            //ensure enough population for developments
            if (population < totalWorkerNeed)
            {
                population = totalWorkerNeed;
            }
        }

        private void UpdateWorkerNeed()
        {
            totalWorkerNeed = 0;

            foreach (var dev in holdingDevelopments)
            {
                totalWorkerNeed += dev.Value * developments[dev.Key].GetWorkerNeed();
            }
        }

        private void GenerateStartingWealth()
        {
            if(background == Background.Merchant)
            {
                wealth = (investment + 1) * 8000;
                holdingResources[ResourceType.Wood] = 10 * (investment + 1);
                holdingResources[ResourceType.Stone] = 10 * (investment + 1);
                holdingResources[ResourceType.Cloth] = 5 * (investment + 1);
                holdingResources[ResourceType.Bread] = 8 * (investment + 1);
                holdingResources[ResourceType.Vegetables] = 12 * (investment + 1);
                holdingResources[ResourceType.Fruit] = 4 * (investment + 1);

                if (investment == 0)
                {
                }
                else if (investment == 1)
                {
                }
                else if (investment == 2)
                {
                }
                else if (investment == 3)
                {
                }
            }
            else if(background == Background.Nobel)
            {
                wealth = (investment + 1) * 4000;
                holdingResources[ResourceType.Wood] = 4 * (investment + 1);
                holdingResources[ResourceType.Stone] = 2 * (investment + 1);
                holdingResources[ResourceType.Iron] = 1 * (investment + 1);
                holdingResources[ResourceType.Bread] = 10 * (investment + 1);
                holdingResources[ResourceType.Vegetables] = 8 * (investment + 1);
                holdingResources[ResourceType.Meat] = 2 * (investment + 1);

                if (investment == 0)
                {
                }
                else if (investment == 1)
                {
                }
                else if (investment == 2)
                {
                }
                else if (investment == 3)
                {
                }
            }
            else if (background == Background.Elder)
            {
                wealth = (investment + 1) * 2500;
                holdingResources[ResourceType.Wood] = 15 * (investment + 1);
                holdingResources[ResourceType.Stone] = 15 * (investment + 1);
                holdingResources[ResourceType.Meat] = 2 * (investment + 1);
                holdingResources[ResourceType.Bread] = 8 * (investment + 1);
                holdingResources[ResourceType.Vegetables] = 8 * (investment + 1);
                holdingResources[ResourceType.Fruit] = 8 * (investment + 1);

                if (investment == 0)
                {
                }
                else if (investment == 1)
                {
                }
                else if (investment == 2)
                {
                }
                else if (investment == 3)
                {
                }
            }
            else if (background == Background.Adventurer)
            {
                wealth = (investment + 1) * 6000;
                holdingResources[ResourceType.Wood] = 10 * (investment + 1);
                holdingResources[ResourceType.Stone] = 10 * (investment + 1);
                holdingResources[ResourceType.Iron] = 1 * (investment + 1);
                holdingResources[ResourceType.Leather] = 1 * (investment + 1);
                holdingResources[ResourceType.Meat] = 3 * (investment + 1);
                holdingResources[ResourceType.Bread] = 6 * (investment + 1);
                holdingResources[ResourceType.Vegetables] = 8 * (investment + 1);
                holdingResources[ResourceType.Fruit] = 4 * (investment + 1);

                if (investment == 0)
                {
                }
                else if (investment == 1)
                {
                }
                else if (investment == 2)
                {
                }
                else if (investment == 3)
                {
                }
            }
        }

        private void PopulateResources()
        {
            resources = new Dictionary<ResourceType, Resource>();

            foreach (var resType in Enum.GetValues(typeof(ResourceType)))
            {
                Resource res = new Resource((ResourceType)resType);
                resources.Add((ResourceType)resType, res);
                holdingResources.Add((ResourceType)resType, 0);
                resourceFlow.Add((ResourceType)resType, 0);
            }
        }

        private void PopulateDevelopments()
        {
            developments = new Dictionary<DevelopmentType, Development>();

            foreach(var devType in Enum.GetValues(typeof(DevelopmentType)))
            {
                Development dev = new Development();
                dev.setType((DevelopmentType)devType);
                developments.Add((DevelopmentType)devType, dev);
                holdingDevelopments.Add((DevelopmentType)devType, 0);
            }
        }

        public int GetWealthIncome()
        {
            int income = 0;

            foreach(var dev in holdingDevelopments)
            {
                income += developments[dev.Key].GetWealthIncome() * dev.Value;
            }

            return income;
        }

        public int GetWealthUpkeep()
        {
            int upkeep = 0;

            foreach (var dev in holdingDevelopments)
            {
                upkeep += developments[dev.Key].GetWealthUpkeep() * dev.Value;
            }

            return upkeep;
        }

        private void GenerateStartingDevelopments()
        {
            for(int i = 0; i < investment + 1; i++)
            {
                DevelopmentType dev = GetRandomAllowedDevelopment();

                if (!holdingDevelopments.TryAdd(dev, 1))
                {
                    holdingDevelopments[dev]++;
                }
            }
        }

        public string getHoldLevelAsText()
        {
            switch (holdLevel)
            {
                case 0:
                    return "Ruins";
                case 1:
                    return "Fortified Camp";
                case 2:
                    return "Sturdy House";
                case 3:
                    return "Fortified House";
                case 4:
                    return "Tower";
                case 5:
                    return "Fortified Tower";
                case 6:
                    return "Keep";
                case 7:
                    return "Fortified Keep";
                default:
                    return "An Undefined Structure";

            }
        }

        public DevelopmentType GetRandomAllowedDevelopment()
        {
            List<DevelopmentType> allowedDevelopments = GetAllowedDevelopments(false);

            return allowedDevelopments[randomGenerator.Next(allowedDevelopments.Count)];
        }

        internal string GetEnvironmentDescriptor()
        {
            return environmentText;
        }

        public List<Development> GetConstructedDevelopments()
        {
            List<Development> returnDevs = new();

            foreach(var dev in holdingDevelopments)
            {
                for (int i = 0; i < dev.Value; i++)
                {
                    returnDevs.Add(developments[dev.Key]);
                }
            }

            return returnDevs;
        }

        internal int GetWealth()
        {
            return wealth;
        }

        internal int GetAmountOfHoldingResource(ResourceType type)
        {
            return holdingResources[type];
        }

        internal int GetPopulation()
        {
            return population;
        }

        public Dictionary<ResourceType, int> GetResourceFlow()
        {
            return resourceFlow;
        }

        internal void NewTurn()
        {
            //this order is important
            UpdateResourceFlow();
            wealth += GetWealthIncome();
            wealth -= (GetWealthUpkeep() + GetResourceDeficitInWealth()); //resource deficit is negative
            UpdateResources();
            BuyDeficitResources();

            //25% chance
            if(randomGenerator.Next(100) < 25)
            {
                //get hold level plus 0 to 3 plus 1 for every 10 gold wealth (100000 copper)
                population += holdLevel + randomGenerator.Next(3 + (wealth / 100000));
            }

            UpdateWorkerNeed();
        }

        private void UpdateResourceFlow()
        {
            foreach (var resource in resourceFlow)
            {
                resourceFlow[resource.Key] = 0;
            }

            foreach (var dev in holdingDevelopments)
            {
                foreach (var resource in developments[dev.Key].GetResourceUpkeep())
                {
                    resourceFlow[resource.Key] -= dev.Value * resource.Value;
                }

                foreach (var resource in developments[dev.Key].GetResourceIncome())
                {
                    resourceFlow[resource.Key] += dev.Value * resource.Value;
                }
            }

            RunFoodCycle();
        }

        private void RunFoodCycle()
        {
            //first eat bread for 35%, then eat vegetables for 25%, then eat fruit for 25% and meat for 15%
            //any leftovers eat anything left and then eat vegetables (cheapest to buy and foodvalue 1) 
            int foodDemand = GetFoodDemand();
            int breadFoodPortion = (int)Math.Ceiling(foodDemand * 0.35);
            int vegFoodPortion = (int)Math.Ceiling(foodDemand * 0.25);
            int fruitFoodPortion = (int)Math.Ceiling(foodDemand * 0.25);
            int meatFoodPortion = (int)Math.Ceiling(foodDemand * 0.15);
            int deficitFoodNeed = breadFoodPortion % 3 + fruitFoodPortion % 2 + meatFoodPortion % 4; //rounding fractions

            if (holdingResources[ResourceType.Bread] > 0)
            {
                //do we have enough bread
                if (holdingResources[ResourceType.Bread] >= breadFoodPortion / 3)
                {
                    //eat bread
                    resourceFlow[ResourceType.Bread] -= breadFoodPortion / 3;
                }
                else
                {
                    //eat all bread, overflow to deficit
                    deficitFoodNeed += (breadFoodPortion) - holdingResources[ResourceType.Bread] * 3;
                    resourceFlow[ResourceType.Bread] -= holdingResources[ResourceType.Bread];
                }
            }
            else
            {
                deficitFoodNeed += breadFoodPortion;
            }

            if (holdingResources[ResourceType.Vegetables] > 0)
            {
                //do we have enough vegetables
                if (holdingResources[ResourceType.Vegetables] >= vegFoodPortion)
                {
                    //eat vegetables
                    resourceFlow[ResourceType.Vegetables] -= vegFoodPortion;
                }
                else
                {
                    //eat all vegetables, overflow to deficit
                    deficitFoodNeed += (vegFoodPortion) - holdingResources[ResourceType.Vegetables];
                    resourceFlow[ResourceType.Vegetables] -= holdingResources[ResourceType.Vegetables];
                }
            }
            else
            {
                deficitFoodNeed += vegFoodPortion;
            }

            if (holdingResources[ResourceType.Fruit] > 0)
            {
                //do we have enough fruit
                if (holdingResources[ResourceType.Fruit] >= fruitFoodPortion / 2)
                {
                    //eat fruit
                    resourceFlow[ResourceType.Fruit] -= fruitFoodPortion / 2;
                }
                else
                {
                    //eat all fruit, overflow to deficit
                    deficitFoodNeed += (fruitFoodPortion) - holdingResources[ResourceType.Fruit] * 2;
                    resourceFlow[ResourceType.Fruit] -= holdingResources[ResourceType.Fruit];
                }
            }
            else
            {
                deficitFoodNeed += fruitFoodPortion;
            }

            if (holdingResources[ResourceType.Meat] > 0)
            {
                //do we have enough meat
                if (holdingResources[ResourceType.Meat] >= meatFoodPortion / 4)
                {
                    //eat meat
                    resourceFlow[ResourceType.Meat] -= meatFoodPortion / 4;
                }
                else
                {
                    //eat all meat, overflow to deficit
                    deficitFoodNeed += (meatFoodPortion) - holdingResources[ResourceType.Meat] * 4;
                    resourceFlow[ResourceType.Meat] -= holdingResources[ResourceType.Meat];
                }
            }
            else
            {
                deficitFoodNeed += meatFoodPortion;
            }

            while (deficitFoodNeed > 0)
            {
                if (holdingResources[ResourceType.Bread] > resourceFlow[ResourceType.Bread] && deficitFoodNeed % 3 > 0)
                {
                    deficitFoodNeed -= 3;
                    resourceFlow[ResourceType.Bread]--;
                }
                if (holdingResources[ResourceType.Fruit] > resourceFlow[ResourceType.Fruit] && deficitFoodNeed % 2 > 0)
                {
                    deficitFoodNeed -= 2;
                    resourceFlow[ResourceType.Fruit]--;
                }
                if (holdingResources[ResourceType.Vegetables] > resourceFlow[ResourceType.Vegetables] && deficitFoodNeed > 0)
                {
                    deficitFoodNeed -= 1;
                    resourceFlow[ResourceType.Vegetables]--;
                }
                if (holdingResources[ResourceType.Meat] > resourceFlow[ResourceType.Meat] && deficitFoodNeed % 4 > 0)
                {
                    deficitFoodNeed -= 4;
                    resourceFlow[ResourceType.Meat]--;
                }
            }

            //keep eating vegetables even if we have non, forcing vegetables to be bought
            while (deficitFoodNeed > 0)
            {
                deficitFoodNeed -= 1;
                resourceFlow[ResourceType.Vegetables]--;
            }
        }

        private void UpdateResources()
        {
                foreach (var resource in holdingResources)
                {
                    holdingResources[resource.Key] += resourceFlow[resource.Key];
                }
        }

        public int GetResourceDeficitInWealth()
        {
            int total = 0;

            foreach(var res in resourceFlow)
            {
                if(res.Value < 0 && Math.Abs(res.Value) > holdingResources[res.Key])
                {
                    //add res.Value since it is a negative value (<0)
                    total += (holdingResources[res.Key] + res.Value) * resources[res.Key].Value;
                }
            }

            return total;
        }

        private void BuyDeficitResources()
        {
            foreach (var res in holdingResources)
            {
                //deficit will be negative zero resource
                if (res.Value < 0)
                {
                    holdingResources[res.Key] = 0;
                }
            }
        }

        internal string GetVillageLevelAsText()
        {
            return "small village";
        }

        internal int GetFoodDemand()
        {
            return population * 2 + guards * 3;
        }

        internal int GetAvailableFood()
        {
            return holdingResources[ResourceType.Vegetables] * 1 + 
                   holdingResources[ResourceType.Fruit] * 2 + 
                   holdingResources[ResourceType.Bread] * 3 + 
                   holdingResources[ResourceType.Meat] * 4;
        }

        internal int GetGuards()
        {
            return guards;
        }

        internal int GetNeededWorkers()
        {
            return totalWorkerNeed;
        }

        internal void RemoveDevelopment(DevelopmentType type)
        {
            holdingDevelopments[type]--;
            UpdateResourceFlow();
            UpdateWorkerNeed();
        }

        internal List<DevelopmentType> GetAllowedDevelopments(bool considerCost = true)
        {
            List<DevelopmentType> allowedDevelopments = new();

            foreach (var dev in developments)
            {
                if (dev.Value.MultipleAllowed || holdingDevelopments[dev.Key] == 0)
                {
                    if(considerCost && !developmentAffordable(dev.Value))
                    {
                        //To expensive
                        continue;
                    }

                    allowedDevelopments.Add(dev.Key);
                }
            }

            return allowedDevelopments;
        }

        private bool developmentAffordable(Development value)
        {
            if(wealth < value.GetWealthCost())
            {
                //check resource build cost

                return false;
            }

            return true;
        }

        internal Development GetDevelopment(DevelopmentType type)
        {
            return developments[type];
        }
    }
}
