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
        public int healFactor;

        public Monster(string name, int maxHp, int damage, int healFactor = 0)
        {
            this.name = name;
            this.maxHp = maxHp;
            curHp = maxHp;
            this.damage = damage;
            this.healFactor = healFactor;
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

        public void heal(Monster target)
        {
            if (healFactor == 0)
            {
                Console.WriteLine("Non hai il potere di curare nessuno");
                return;
            }
            if (curHp <= 0)
            {
                Console.WriteLine("Non puoi curare nessuno da morto");
                return;
            }

            if (target.curHp <= 0)
            {
                Console.WriteLine(target.name + " è esausto e non puoi resuscitarlo con la cura");
                return;
            }

            target.curHp += healFactor;

            if (target.curHp > target.maxHp)
            {
                target.curHp = target.maxHp;
            }

            Console.WriteLine(name + "usa cura su " + target.name);
            Console.WriteLine(target.name + " è stato curato e ora ha " + target.curHp + "/" + target.maxHp + "HP");
        }

        public void heal()
        {
            heal(this);
        }

        public void attack(Monster target)
        {
            if (curHp <= 0)
            {
                Console.WriteLine("Non puoi attaccare nessuno da morto");
                return;
            }

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
