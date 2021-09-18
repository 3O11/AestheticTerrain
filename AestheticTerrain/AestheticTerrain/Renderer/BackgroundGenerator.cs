using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using OpenTK.Mathematics;


namespace AestheticTerrain {
    class BackgroundGenerator {
        public BackgroundGenerator() {

        }

        public Bitmap GenerateBackground() {
            Bitmap background = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(background)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush b = Brushes.Crimson) {
                    g.FillEllipse(b, Width / 2, Height / 2, 100, 100);
                }
            }

            return background;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public Color TopColour { get; set; }
        public Color BottomColour { get; set; }
        public Color StarColour { get; set; }
        public Color SunColour { get; set; }
        public float SunRadius { get; set; }
        public int StarCount { get; set; }
        public float StarRadius { get; set; }
        public float MinStarDistance { get; set; }
        public float GlowMultiplier { get; set; }
    }
}
