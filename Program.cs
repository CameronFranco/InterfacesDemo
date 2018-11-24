using System;

namespace InterfacesDemo
{

    interface IAttacker<T>
    {
        double Attack(double attackdamage);
        void TakeDamage(double damage);
    }
    public class Elf : Monster, IAttacker<Elf>
    {
        public Elf(string name, double level): base(name, level)
        {          
            this.Health = 8 * level;
            this.Armor = 80;
            this.attackDamage = 10;
        }
        public double Attack(double enemyArmor)
        {
            //.WriteLine("Elf " + (this.attackDamage * base.Level / enemyArmor).ToString());
            return this.attackDamage * base.Level / enemyArmor;
        }
        public void TakeDamage( double damage)
        {
            this.Health = this.Health -  damage;
        }
    }

    public class Orc : Monster, IAttacker<Orc>
    {
        public Orc(string name, double level) : base(name, level)
        {
            this.Health = 40 * level;
            this.Armor = 40;
            this.attackDamage = 4;
        }
        public double Attack(double enemyArmor)
        {
            //Console.WriteLine("Orc " + (this.attackDamage * base.Level / enemyArmor).ToString());
            return this.attackDamage * base.Level / enemyArmor;
        }
        public void TakeDamage(double damage)
        {
            this.Health = this.Health - damage;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Elf Glorfindel = new Elf("Glorfindel", 20);
            Orc Captain = new Orc("Orc Captain", 10);
            Console.WriteLine(Captain.Name + "'s Health:" + Captain.Health.ToString());
            Console.WriteLine(Glorfindel.Name + "'s Health:" + Glorfindel.Health.ToString());

            while (Glorfindel.Health > 0 && Captain.Health > 0)
            {
                double scoutDamage = Glorfindel.Attack(Captain.Armor);
                double GlorfindelDamage = Captain.Attack(Glorfindel.Armor);
                Glorfindel.TakeDamage(GlorfindelDamage);
                Captain.TakeDamage(scoutDamage);
                Console.WriteLine(Captain.Name + "'s Health:" + Captain.Health.ToString());
                Console.WriteLine(Glorfindel.Name + "'s Health:" + Glorfindel.Health.ToString());
            }

            if ((Captain.Health <= 0) && (Glorfindel.Health <= 0))
            {
                Console.WriteLine("Both creatures tragically perished from their wounds.");
            }

            else if (Captain.Health <= 0)
            {
                Console.WriteLine(Glorfindel.Name + " wins!");
            }

            else if (Glorfindel.Health <= 0)
            {
                Console.WriteLine(Captain.Name + " wins!");
            }


        }
    }


}
