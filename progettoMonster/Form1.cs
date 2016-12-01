using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progettoMonster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Monster strongbonna = new Monster("Stongbonna", 10, 50);
            Monster charmender = new Monster("charmender", 56, 10);

            strongbonna.attack(charmender);
            strongbonna.attack(charmender);
            strongbonna.attack(charmender);
        }
    }
}
