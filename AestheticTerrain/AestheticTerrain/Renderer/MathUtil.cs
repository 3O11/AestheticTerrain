using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    static class MathUtil {
        public static float Distance(Vector2 u, Vector2 v) {
            Vector2 res = (u - v);
            res = res * res;
            return (float)(Math.Sqrt((double)res.X + (double)res.Y));
        }
    }
}
