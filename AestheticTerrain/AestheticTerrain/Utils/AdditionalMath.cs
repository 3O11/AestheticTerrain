using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class AdditionalMath {
        public static Vector3 Lerp(Vector3 u, Vector3 v, float blend) {
            return new Vector3(blend * u + (1 - blend) * v);
        }
    }
}
