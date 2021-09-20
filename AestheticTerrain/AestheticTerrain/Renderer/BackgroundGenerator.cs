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
            Bitmap background = new Bitmap(BackgroundWidth, BackgroundHeight);

            using (Graphics g = Graphics.FromImage(background)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Drawing background
                Utils.DrawGradientRectangle(g, new Vector2(0, 0), new Vector2(BackgroundWidth, BackgroundHeight), TopColour, BottomColour);

                // Drawing stars
                RejectionSampler sampler = new RejectionSampler(BackgroundWidth, BackgroundHeight, MinStarDistance, 1000, StarSeed);
                for (int i = 0; i < StarCount; i++) {
                    Vector2 sample;
                    if (!sampler.TrySample(out sample)) break;

                    Utils.DrawGlow(g, StarGlowColour, sample, StarGlowRadius);
                    Utils.DrawCircle(g, StarColour, sample, StarRadius);
                }

                // Drawing sun
                Vector2 sunPosAdjusted = SunPosition * new Vector2(BackgroundWidth, BackgroundHeight);
                sunPosAdjusted.Y = BackgroundHeight - sunPosAdjusted.Y;
                Utils.DrawGlow(g, SunGlowColour, sunPosAdjusted, SunGlowRadius);
                Utils.DrawCircle(g, SunColour, sunPosAdjusted, SunRadius);
            }

            return background;
        }

        public int BackgroundWidth { get; set; }
        public int BackgroundHeight { get; set; }
        public int StarSeed { get; set; }
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
