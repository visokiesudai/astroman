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
        private MinesweeperMap map;

        public MinesweeperForm()
        {
            InitializeComponent();
            Width = map.block_width * map.width;
            Height = map.header_height + map.block_height * map.height;
        }

        private void MinesweeperForm_Load(object sender, EventArgs e)
        {
            map = new MinesweeperMap(this);
        }

        

    }
}
