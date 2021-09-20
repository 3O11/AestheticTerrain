using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AestheticTerrain {
    public class Quadratic2D {
        public Quadratic2D() {
            Clamp = false;
            TopClamp = 100;
            BottomClamp = -100;
        }

        public Quadratic2D(float quadraticParameter, float linearParameter, float constantParameter) : this() {
            xQuad = yQuad = quadraticParameter;
            xLin  = yLin  = linearParameter;
            Const = constantParameter;
        }

        public float GetValue(float x, float y) {
            if (Clamp) return Math.Clamp(funcVal(x, y), BottomClamp, TopClamp);
            return funcVal(x, y);
        }

        float funcVal(float x, float y) {
            return (xQuad * x * x) + (yQuad * y * y) + (xyLin * x * y) + (xLin * x) + (yLin * y) + Const;
        }

        public bool Clamp { get; set; }
        public float TopClamp { get; set; }
        public float BottomClamp { get; set; }
        public float xQuad { get; set; }
        public float yQuad { get; set; }
        public float xyLin { get; set; }
        public float xLin { get; set; }
        public float yLin { get; set; }
        public float Const { get; set; }
    }
}
