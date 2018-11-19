using System;

namespace InterfacesDemo
{
    public class Monster : IEquatable<Monster>
    {
        public double Health;
        public double Armor;
        public int Level;
        public string Name;
        public float attackDamage;
        public Monster(string name, double level)
        {
            this.Name = name;
            this.Level = level;
        }

        public bool Equals(Monster other)
        {
            return this.Level == other.Level;
        }

        override public string ToString()
        {
            return this.Name;
        }
    }

    interface IAttacker<T>
    {
        public int Attack(double attackdamage)
        {
        }

        public void TakeDamage(double damage)
        {
        }
      /*  public void Battle(obj Attacker, obj Defender)
        {
            int damageDealt = Attack(Attacker);
            TakeDamage(damageDealt, Defender);
            damageDealt = Attack(Defender);
            TakeDamage(damageDealt, Attacker);
        }*/
    }
    public class Elf : Monster, IAttacker<Elf>, IEquatable<Elf>
    {
        public Elf(string name, double level)
        {          
            this.Health = 0.8 * level;
            this.Armor = 3;
            this.attackDamage = 10;
        }
        public double Attack(double enemyarmor)
        {
            return this.attackDamage * this.level / enemyarmor;
        }
        public void TakeDamage( double damage)
        {
            this.Health = this.Health -  damage / this.Armor;
        }
    }

    public class Orc : Monster, IAttacker<Orc>, IEquatable<Orc>
    {
        public Orc(string name, double level)
        {
            this.Health = 1.5 * level;
            this.Armor = 7;
            this.attackDamage = 5;
        }
        public double Attack(double enemyArmor)
        {
            return this.attackDamage * this.level / enemyArmor;
        }
        public void TakeDamage(double damage)
        {
            this.Health = this.Health - damage / this.Armor;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Elf Glorfindel = new Elf("Glorfindel", 500 );
            Orc Scout = new Orc("Orc Scout", 100 );
            Console.WriteLine("The Orc's Health:" + Orc.Health.ToString());
            Console.WriteLine("The Elf's Health:" + Elf.Health.ToString());

            while( Glorfindel.Health && Scout.Health > 0)
            {
                double scoutDamage = Glorfindel.Attack(Scout.Armor);
                double GlorfindelDamage = Scout.Attack(Glorfindel.Armor);
                Glorfindel.TakeDamage(GlorfindelDamage);
                Scout.TakeDamage(scoutDamage);
                Console.WriteLine("The Orc's Health:" + Orc.Health.ToString());
                Console.WriteLine("The Elf's Health:" + Elf.Health.ToString());
            }

            if (Orc.Health < 0)
            {
                Console.WriteLine("The Elf wins!");
            }

            else if (Elf.Health < 0)
            {
                Console.WriteLine("The Orc wins!");
            }
            else
            {
                Console.WriteLine("error");
            }
        }

    }


}
