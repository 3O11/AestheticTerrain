using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class DrawHelper {
        public static void DrawCircle(Graphics g, Color colour, Vector2 center, float radius) {
            using (Brush b = new SolidBrush(colour)) {
                g.FillEllipse(b, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
        }

        public static void DrawGlow(Graphics g, Color colour, Color bgColour, Vector2 center, float radius) {
            Rectangle gradientRect = new Rectangle((int)center.X, (int)center.Y, (int)(center.X + radius * 2), (int)(center.Y + radius * 2));
            using (Brush b = new LinearGradientBrush(gradientRect, colour, bgColour, LinearGradientMode.Vertical)) {
                
            }
        }

        public static void DrawGradientRectangle(Graphics g, Vector2 start, Vector2 size, Color topColour, Color bottomColour) {
            Rectangle gradientRect = new Rectangle((int)start.X, (int)start.Y, (int)size.X, (int)size.Y);
            using (var gradient = new LinearGradientBrush(gradientRect, bottomColour, topColour, LinearGradientMode.Vertical)) {
                g.FillRectangle(gradient, start.X, start.Y, size.X, size.Y);
            }
        }
    }
}
