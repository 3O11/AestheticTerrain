using System;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class PerlinNoise {
        public PerlinNoise(int seed) {
            Reseed(seed);
        }

        public void Reseed(int newSeed) {
            _random = new Random(newSeed);
            generatePermutation();
            generateGradients();
        }

        public float Noise(float x, float y) {
            Vector2 cell = new Vector2((float)Math.Floor(x), (float)Math.Floor(y));
            float total = 0;
            Vector2[] corners = new Vector2[] {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(1, 0),
                new Vector2(1, 1),
            };

            foreach (Vector2 n in corners) {
                Vector2 ij = cell + n;
                Vector2 uv = new Vector2(x - ij.X, y - ij.Y);
                var index = _permutation[(int)ij.X % _permutation.Length];
                index = _permutation[(index + (int)ij.Y) % _permutation.Length];

                var grad = _gradients[index % _gradients.Length];
                total += Q(uv.X, uv.Y) * Vector2.Dot(grad, uv);
            }

            return Math.Max(Math.Min(total, 1), -1);
        }

        public float Noise(int x, int y, int width, int height, float freq) {
            return Noise((x * freq) / width, (y * freq) / height);
        }

        void generatePermutation() {
            for (int i = 0; i < 256; i++) _permutation[i] = _random.Next(256);
        }

        void generateGradients() {
            for (int i = 0; i < 256; i++) {
                Vector2 gradient;

                do {
                    gradient = new Vector2((float)_random.NextDouble() * 2 - 1, (float)_random.NextDouble() * 2 - 1);
                } while (gradient.LengthSquared >= 1);

                gradient.Normalize();

                _gradients[i] = gradient;
            }
        }

        float drop(float t) {
            t = Math.Abs(t);
            return 1 - t * t * t * (t * (t * 6 - 15) + 10);
        }

        float Q(float u, float v) {
            return drop(u) * drop(v);
        }

        Random _random;
        int[] _permutation = new int[256];
        Vector2[] _gradients = new Vector2[256];
    }
}
