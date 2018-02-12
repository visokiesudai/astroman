using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainInterface.Minesweeper
{
    class MineBlock : Button
    {
        public bool has_mine { get; set; }
        public int hidden_value { get; set; }
        private MineBlock[,] map;

        public MineBlock(MineBlock[,] map)
        {
            this.map = map;
        }

        public bool IsEnabled()
        {
            return this.Enabled;
        }

        public void Reset()
        {
            has_mine = false;
            hidden_value = 0;
            Enabled = true;
            Visible = true;
        }


    }
}
