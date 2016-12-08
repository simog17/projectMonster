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
        private string _name;
        public string name { get { return _name; } }

        private int _maxHp;
        public int maxHp
        {
            get
            {
                return _maxHp;
            }
        }

        private int _curHp;
        public int curHp
        {
            set
            {
                if (value < 0) value = 0;
                else if (value > _maxHp) value = _maxHp;
                _curHp = value;
            }

            get
            {
                return _curHp;
            }
        }

        private int _damage;
        public int damage
        {
            get
            {
                return _damage;
            }
        }

        private int _healFactor;
        public int healFactor
        {
            get
            {
                return _healFactor;
            }
        }

        public Monster(string name, int maxHp, int damage, int healFactor = 0)
        {
            _name = name;

            if (maxHp < 1) maxHp = 1;
            _maxHp = maxHp;

            curHp = maxHp;

            _damage = damage;

            _healFactor = healFactor;
            describe();
        }

        public string describe()
        {
            string output = "questo è " + _name + "\r\n";
            output += "HP: " + _curHp + "\r\n";
            output += "DAMAGE: " + _damage + "\r\n";

            return output;          
        }

        public void describe(TextBox t)
        {
            t.Text = describe();
        }

        public void heal(Monster target)
        {
            if (_healFactor == 0)
            {
                Console.WriteLine("Non hai il potere di curare nessuno");
                return;
            }
            if ( _curHp <= 0)
            {
                Console.WriteLine("Non puoi curare nessuno da morto");
                return;
            }

            if (target._curHp <= 0)
            {
                Console.WriteLine(target.name + " è esausto e non puoi resuscitarlo con la cura");
                return;
            }

            target._curHp += _healFactor;

            if (target._curHp > target._maxHp)
            {
                target._curHp = target._maxHp;
            }

            Console.WriteLine(name + " usa cura su " + target.name);
            Console.WriteLine(target.name + " è stato curato e ora ha " + target._curHp + "/" + target._maxHp + "HP");
        }

        public void heal()
        {
            heal(this);
        }

        public void attack(Monster target)
        {
            if (_curHp <= 0)
            {
                Console.WriteLine("Non puoi attaccare nessuno da morto");
                return;
            }

            if (target._curHp <= 0)
            {
                Console.WriteLine(target.name + " è già esausto, non infierire.");
                return;
            }

            Console.WriteLine(name + " attacca " + target.name);
            Console.WriteLine(name + " fa " + _damage + " danni a " + target.name);
            target._curHp -= _damage;

            if (target._curHp <= 0)
            {
                target._curHp = 0;
                Console.WriteLine(target.name + " è esausto.");
            }
            else
            {
                Console.WriteLine("a " + target.name + " rimangono " + target._curHp + " hp");
            }
        }
    }
}
