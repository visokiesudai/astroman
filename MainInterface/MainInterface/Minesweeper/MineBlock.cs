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
        public int width_position { get; set; }
        public int height_position { get; set; }

        public MineBlock(int w, int h)
        {
            this.width_position = w;
            this.height_position = h;
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
