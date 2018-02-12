using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainInterface.Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        private int width = 20;
        private int height = 20;
        private int mines = 50;
        

        public MinesweeperForm()
        {
            InitializeComponent();
        }

        private void MinesweeperForm_Load(object sender, EventArgs e)
        {

        }
    }
}
