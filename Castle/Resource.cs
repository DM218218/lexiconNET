namespace Castle
{
    public enum ResourceType
    {
        Wood,
        Stone,
        Ore,
        Iron,
        Wool,
        Cloth,
        Leather,
        Grain,
        Vegetables,
        Meat,
        Flour,
        Bread,
        Fruit,
        Clothes,
        Carcass,
        Hides
    }

    internal class Resource
    {

        private string name;
        private int value;
        private ResourceType type;

        public int Value { get => value; set => this.value = value; }
        public string Name { get => name; set => name = value; }
        private ResourceType Type { get => type; }

        private Resource()
        {
            Initialize();
        }

        public Resource(ResourceType type) : this()
        {
            this.type = type;
        }

        private void Initialize()
        {
            switch(type)
            {
                case ResourceType.Wood:
                    name = "Wood";
                    value = 2;
                    break;
                case ResourceType.Stone:
                    name = "Stone";
                    value = 2;
                    break;
                case ResourceType.Ore:
                    name = "Iron Ore";
                    value = 8;
                    break;
                case ResourceType.Iron:
                    name = "Iron";
                    value = 15;
                    break;
                case ResourceType.Wool:
                    name = "Wool";
                    value = 4;
                    break;
                case ResourceType.Cloth:
                    name = "Cloth";
                    value = 8;
                    break;
                case ResourceType.Leather:
                    name = "Leather";
                    value = 7;
                    break;
                case ResourceType.Grain:
                    name = "Grain";
                    value = 1;
                    break;
                case ResourceType.Vegetables:
                    name = "Vegetables";
                    value = 3;
                    break;
                case ResourceType.Meat:
                    name = "Meat";
                    value = 9;
                    break;
                case ResourceType.Flour:
                    name = "Flour";
                    value = 4;
                    break;
                case ResourceType.Bread:
                    name = "Bread";
                    value = 6;
                    break;
                case ResourceType.Fruit:
                    name = "Fruit";
                    value = 3;
                    break;
                case ResourceType.Clothes:
                    name = "Clothes";
                    value = 12;
                    break;
                case ResourceType.Carcass:
                    name = "Animal Carcass";
                    value = 1;
                    break;
                case ResourceType.Hides:
                    name = "Hides";
                    value = 2;
                    break;
                default:
                    name = "Error";
                    value = 0;
                    break;

            }
        }
    }
}