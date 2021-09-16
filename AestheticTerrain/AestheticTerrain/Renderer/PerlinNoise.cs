using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class PerlinNoise {
        public PerlinNoise(int seed) {
            Reseed(seed);
            generateGradients();
        }

        public void Reseed(int newSeed) {
            _random = new Random(newSeed);
            generatePermutation();
        }

        void generatePermutation() {
            for (int i = 0; i < 256; i++) _permutation[i] = _random.Next(256);
        }

        void generateGradients() {
            for (int i = 0; i < 256; i++) {
                Vector2 gradient = new Vector2(0, 0);

                

                _gradients[i] = gradient;
            }
        }

        Random _random;
        int[] _permutation = new int[256];
        Vector2[] _gradients = new Vector2[256];
    }
}
