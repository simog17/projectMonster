using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progettoMonster
{
    class Monster
    {
        public string name;
        public int maxHp;
        public int curHp;
        public int damage;

        public Monster(string name, int maxHp, int damage)
        {
            this.name = name;
            this.maxHp = maxHp;
            curHp = maxHp;
            this.damage = damage;
            describe();
        }

        public string describe()
        {
            string output = "questo è " + name + "\r\n";
            output += "HP: " + curHp + "\r\n";
            output += "DAMAGE: " + damage + "\r\n";

            return output;
        }

        public void describe(TextBox t)
        {
            t.Text = describe();
        }

        public void attack(Monster target)
        {
            if (target.curHp <= 0)
            {
                Console.WriteLine(target.name + " è già esausto, non infierire.");
                return;
            }

            Console.WriteLine(name + " attacca " + target.name);
            Console.WriteLine(name + " fa " + damage + " danni a " + target.name);
            target.curHp -= damage;

            if (target.curHp <= 0)
            {
                target.curHp = 0;
                Console.WriteLine(target.name + " è esausto.");
            }
            else
            {
                Console.WriteLine("a " + target.name + " rimangono " + target.curHp + " hp");
            }
        }
    }
}
