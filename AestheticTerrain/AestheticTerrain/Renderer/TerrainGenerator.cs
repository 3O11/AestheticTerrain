using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class TerrainGenerator {
        public static Mesh GeneratePlane(int radius) {
            List<Vector3> vertices = new List<Vector3>();
            List<int> indices = new List<int>();

            for (int i = 0; i < (radius * 2) + 1; i++) {
                for (int j = 0; j < (radius * 2) + 1; j++) {
                    vertices.Add(new Vector3(i - radius, 0, j - radius));

                    if (i > 0 && j > 0) {
                        int currentPoint = i * (radius * 2 + 1) + j;
                        int prevPoint = currentPoint - 1;
                        int prevRowPoint = (i - 1) * (radius * 2 + 1) + j;
                        int prevRowPrevPoint = prevRowPoint - 1;

                        // Adding a new square.
                        indices.Add(currentPoint);
                        indices.Add(prevPoint);
                        indices.Add(prevRowPoint);

                        indices.Add(prevRowPoint);
                        indices.Add(prevPoint);
                        indices.Add(prevRowPrevPoint);
                    }
                }
            }

            return new Mesh(vertices.ToArray(), indices.ToArray());
        }

        public static Mesh GenerateTerrain(int radius, int seed) {
            PerlinNoise noise = new PerlinNoise(seed);
            List<Vector3> vertices = new List<Vector3>();
            List<int> indices = new List<int>();

            for (int i = 0; i < (radius * 2) + 1; i++) {
                for (int j = 0; j < (radius * 2) + 1; j++) {
                    vertices.Add(new Vector3(i - radius, 20 * noise.Noise(i, j, radius * 2 + 1, radius * 2 + 1, 60), j - radius));

                    if (i > 0 && j > 0) {
                        int currentPoint = i * (radius * 2 + 1) + j;
                        int prevPoint = currentPoint - 1;
                        int prevRowPoint = (i - 1) * (radius * 2 + 1) + j;
                        int prevRowPrevPoint = prevRowPoint - 1;

                        // Adding a new square.
                        indices.Add(currentPoint);
                        indices.Add(prevPoint);
                        indices.Add(prevRowPoint);

                        indices.Add(prevRowPoint);
                        indices.Add(prevPoint);
                        indices.Add(prevRowPrevPoint);
                    }
                }
            }

            return new Mesh(vertices.ToArray(), indices.ToArray());
        }
    }
}
