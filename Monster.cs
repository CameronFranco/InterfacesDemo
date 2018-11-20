namespace InterfacesDemo
{

    public class Monster
    {
        public double Health;
        public double Armor;
        public double Level;
        public string Name;
        public double attackDamage;
        public Monster(string name, double level)
        {
            this.Name = name;
            this.Level = level;
        }

        override public string ToString()
        {
            return this.Name;
        }
    }
}


