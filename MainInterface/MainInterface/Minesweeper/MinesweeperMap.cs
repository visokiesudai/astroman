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
        public int mines = 20;

        private Random rng = new Random();

        private MineBlock[,] map;

        public MinesweeperMap(Control ctrl)
        {
            CreateMap(ctrl);
            LoadMines();
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

                    map[w, h] = new MineBlock(w, h);
                    map[w, h].Location = new Point(x, y);
                    map[w, h].Width = block_width;
                    map[w, h].Height = block_height;
                    ctrl.Controls.Add(map[w, h]);

                    map[w, h].MouseUp += new MouseEventHandler(delegate(Object o, MouseEventArgs me)
                    {
                        MineBlock block = o as MineBlock;

                        if (me.Button == MouseButtons.Right)
                        {
                            if (block.BackColor == Color.Red)
                            {
                                block.HideMine();
                            }
                            else
                            {
                                block.ShowMine();
                            }
                            
                            return;
                        }

                        if (me.Button == MouseButtons.Left && block.BackColor != Color.Red)
                        {
                            block.Disable();

                            if (block.has_mine)
                            {
                                MessageBox.Show("You lose.");
                                RevealMap();
                            }

                            ShowFields(block);
                        }
                    });
                }
            }
        }

        public void Reset(Control ctrl)
        {
            CreateMap(ctrl);
            LoadMines();
        }

        public void RevealMap() 
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    if (map[w, h].IsEnabled())
                    {
                        ShowFields(map[w, h]);    
                    }
                }
            }
        }

        public void ShowFields(MineBlock block)
        {
            if (block.has_mine)
            {
                block.ShowMine();
                return;
            }

            var neighbours = GetNeighbours(block);
            int neighbouring_mines = neighbours.Where(p => p.has_mine).Count();

            block.Disable();
            if (neighbouring_mines == 0)
            {
                block.SetText("");
                foreach (var neighbour in neighbours)
                {
                    ShowFields(neighbour);
                }
            }
            else
            {
                block.SetText(neighbouring_mines.ToString());
            }
        }

        private bool HasBlockToLeft(MineBlock block)
        {
            return block.width_position > 0;
        }

        private List<MineBlock> GetNeighbours(MineBlock block)
        {
            var neighbours = new List<MineBlock>();

            int w = block.width_position;
            int h = block.height_position;

            // LEFT
            if (w > 0)
            {
                if (map[w - 1, h].IsEnabled())
                {
                    neighbours.Add(map[w - 1, h]);    
                }
            }

            // LEFT UP
            if (w > 0 && h > 0)
            {
                if (map[w - 1, h - 1].IsEnabled())
                {
                    neighbours.Add(map[w - 1, h - 1]);    
                }
            }

            // LEFT DOWN
            if (w > 0 && h < height - 1)
            {
                if (map[w - 1, h + 1].IsEnabled())
                {
                    neighbours.Add(map[w - 1, h + 1]);    
                }
            }

            // RIGHT
            if (w < width - 1)
            {
                if (map[w + 1, h].IsEnabled())
                {
                    neighbours.Add(map[w + 1, h]);
                }
            }

            // RIGHT UP
            if (w < width - 1 && h > 0)
            {
                if (map[w + 1, h - 1].IsEnabled())
                {
                    neighbours.Add(map[w + 1, h - 1]);    
                }
            }

            // RIGHT DOWN
            if (w < width - 1 && h < height - 1)
            {
                if (map[w + 1, h + 1].IsEnabled())
                {
                    neighbours.Add(map[w + 1, h + 1]);    
                }
            }

            // DOWN
            if (h < height - 1)
            {
                if (map[w, h + 1].IsEnabled())
                {
                    neighbours.Add(map[w, h + 1]);    
                }
            }

            // UP
            if (h > 0)
            {
                if (map[w, h - 1].IsEnabled())
                {
                    neighbours.Add(map[w, h - 1]);    
                }
            }

            return neighbours;
        }

        public void LoadMines()
        {
            int mines_in_map = 0;
            while (mines_in_map != mines)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        if (rng.Next(0, 10) == 1)
                        {
                            map[w, h].AddMine();
                            mines_in_map++;
                        }

                        if (mines_in_map == mines)
                        {
                            break;
                        }
                    }

                    if (mines_in_map == mines)
                    {
                        break;  
                    }
                }
            }
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
