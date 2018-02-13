using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void ShowMine()
        {
            this.BackColor = Color.Red;
        }

        public void HideMine()
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        public void SetText(string text)
        {
            Text = text;
            LoadTextColor(Text);
            this.Focus();
        }

        public void AddMine()
        {
            has_mine = true;
        }

        public bool IsEnabled()
        {
            return this.Enabled;
        }

        public void Disable()
        {
            this.Enabled = false;
        }

        public void Reset()
        {
            has_mine = false;
            hidden_value = 0;
            Enabled = true;
            Visible = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            StringFormat formatText = new StringFormat(StringFormatFlags.NoClip);
            formatText.LineAlignment = StringAlignment.Center;
            formatText.Alignment = StringAlignment.Center;
            pe.Graphics.DrawString(base.Text, base.Font, new SolidBrush(ForeColor),
            new RectangleF(0F, 0F, base.Width, base.Height), formatText);

            // To-do render flag if is mine
        }

        private void LoadTextColor(string text)
        {
            switch (text)
            {
                case "":
                    break;
                case "1":
                    ForeColor = Color.Blue; break;
                case "2":
                    ForeColor = Color.Green; break;
                case "3":
                    ForeColor = Color.Red; break;
                case "4":
                    ForeColor = Color.Purple; break;
                case "5":
                    ForeColor = Color.Black; break;
                case "6":
                    ForeColor = Color.Maroon; break;
                case "7":
                    ForeColor = Color.Gray; break;
                case "8":
                    ForeColor = Color.Turquoise; break;
                default:
                    break;
            }
        }

    }
}
