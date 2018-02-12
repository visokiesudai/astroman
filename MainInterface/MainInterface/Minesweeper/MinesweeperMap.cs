using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainInterface.Minesweeper
{
    class MinesweeperMap
    {
        public int header_height = 80;
        public int block_width = 20;
        public int block_height = 20;
        public int width = 20;
        public int height = 20;
        public int mines = 50;

        private Random rng = new Random();

        private MineBlock[,] map;

        public MinesweeperMap(Control ctrl)
        {
            CreateMap(ctrl);
        }

        private void CreateMap(Control ctrl)
        {
            map = new MineBlock[width, height];

            // Create empty map!
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    int x = w * block_width;
                    int y = header_height + h * block_height;

                    map[w, h] = new MineBlock(x, y);
                    map[w, h].Location = new Point(x, y);
                    map[w, h].Width = block_width;
                    map[w, h].Height = block_height;
                    ctrl.Controls.Add(map[w, h]);

                    map[w, h].Click += new EventHandler(delegate(Object o, EventArgs a)
                    {
                        


                    });
                }
            }
        }

        public void LoadMines()
        {
            //int mines_in_map = 0;
            //while (mines_in_map != mines)
            //{
            //    for (int w = 0; w < width; w++)
            //    {
            //        for (int h = 0; h < height; h++)
            //        {
            //            mines_in_map++;
            //        }
            //    }
            //}
        }

        public void Clear()
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    map[w, h].Reset();
                }
            }
        }

    }
}
