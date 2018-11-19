namespace InterfacesDemo
{
    public class Monster : IEquatable<Monster>
    {
        private int Level;
        public string Name;
        public Monster(string name, int level){
            this.Name = name;
            this.Level = level;
        }

        public bool Equals(Monster other){
            return this.Level == other.Level;
        }

        override public string ToString(){
            return this.Name;
        }
    }
    interface IAttacker<Monster>
    {
        public int Attack(Monster obj)
        {
            int damage = obj.Strength;
            return damage;
        }

        public void TakeDamage(int damage, Monster obj)
        {
            int damageDealt = damage - obj.armor;
            obj.Health = obj.Health - damageDealt;
        }
    }
    public class Elf : Monster, IAttacker
    {
        public Elf()
        {
            this.Health = 0.8 * Level;
            this.Armor = 3;
            this.Strength = 10;
            this.Level = 3;
        }
    }

    public class Orc : Monster, IAttacker
    {
        public Orc()
        {
            this.Health = 1.5 * Level;
            this.Armor = 7;
            this.Strength = 5;
            this.Level = 2;
        }
    }
}

}
