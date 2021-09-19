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
            StarCount = 100;
            MinStarDistance = 50;
            StarRadius = 5;
            StarColour = Color.LightGoldenrodYellow;
            SunRadius = 100;
            SunColour = Color.Crimson;
            TopColour = Color.FromArgb(45, 0, 240);
            BottomColour = Color.FromArgb(150, 0, 150);
            SunPosition = new Vector2(200, 200);
        }

        public Bitmap GenerateBackground() {
            Bitmap background = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(background)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Drawing background
                DrawHelper.DrawGradientRectangle(g, new Vector2(0, 0), new Vector2(Width, Height), TopColour, BottomColour);

                // Drawing stars
                RejectionSampler sampler = new RejectionSampler(Width, Height, MinStarDistance, 1000, Seed);
                for (int i = 0; i < StarCount; i++) {
                    Vector2 sample;
                    if (!sampler.TrySample(out sample)) break;

                    DrawHelper.DrawGlow(g, StarGlowColour, sample, StarRadius);
                    DrawHelper.DrawCircle(g, StarColour, sample, StarRadius);
                }

                // Drawing sun
                Vector2 sunPosAdjusted = SunPosition * new Vector2(Width, Height);
                sunPosAdjusted.Y = Height - sunPosAdjusted.Y;
                DrawHelper.DrawGlow(g, SunGlowColour, sunPosAdjusted, SunGlowRadius);
                DrawHelper.DrawCircle(g, SunColour, sunPosAdjusted, SunRadius);
            }

            return background;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Seed { get; set; }
        public Color TopColour { get; set; }
        public Color BottomColour { get; set; }
        public Color StarColour { get; set; }
        public Color StarGlowColour { get; set; }
        public Color SunColour { get; set; }
        public Color SunGlowColour { get; set; }
        public int SunRadius { get; set; }
        public int SunGlowRadius { get; set; }
        public Vector2 SunPosition { get; set; }
        public int StarCount { get; set; }
        public int StarRadius { get; set; }
        public int StarGlowRadius { get; set; }
        public float MinStarDistance { get; set; }
        public float GlowMultiplier { get; set; }
    }
}
