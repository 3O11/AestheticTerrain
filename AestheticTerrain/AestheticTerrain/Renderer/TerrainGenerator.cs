using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    enum TerrainLerpDirection {
        FrontBack,
        TopDown
    }

    class TerrainGenerator {
        public TerrainGenerator() {
            Radius = 30;
            FuncMultiplier = new Quadratic2D();
        }

        public Mesh GenerateTerrain() {
            PerlinNoise noise = new PerlinNoise(Seed);
            List<Vertex> vertices = new List<Vertex>();
            List<int> indices = new List<int>();

            for (int i = 0; i < (Radius * 2) + 1; i++) {
                for (int j = 0; j < (Radius * 2) + 1; j++) {
                    float vertexY = Multiplier * noise.Noise(i, j, Radius * 2 + 1, Radius * 2 + 1, Frequency);
                    vertexY = Math.Clamp(vertexY, LowerCutoff, UpperCutoff) * FuncMultiplier.GetValue(i - Radius, j - Radius);
                    vertices.Add(new Vertex {
                        Position = new Vector3(i - Radius, vertexY, j - Radius),
                        Colour = Vector3.Lerp(FrontColour, BackColour, (float)i / Radius)
                    });

                    if (i > 0 && j > 0) {
                        int currentPoint = i * (Radius * 2 + 1) + j;
                        int prevPoint = currentPoint - 1;
                        int prevRowPoint = (i - 1) * (Radius * 2 + 1) + j;
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

            return new Mesh(vertices.ToArray(), indices.ToArray(), Matrix4.CreateScale(Scale, 1, Scale));
        }

        public int Radius { get; set; }
        public int Seed { get; set; }
        public int Multiplier { get; set; }
        public int Frequency { get; set; }
        public float Scale { get; set; }
        public Vector3 FrontColour { get; set; }
        public Vector3 BackColour { get; set; }
        public float LowerCutoff { get; set; }
        public float UpperCutoff { get; set; }
        public Quadratic2D FuncMultiplier { get; set; }
    }
}
