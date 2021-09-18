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
            Radius = 100;
        }

        public Mesh GenerateTerrain() {
            PerlinNoise noise = new PerlinNoise(Seed);
            List<Vertex> vertices = new List<Vertex>();
            List<int> indices = new List<int>();

            for (int i = 0; i < (Radius * 2) + 1; i++) {
                for (int j = 0; j < (Radius * 2) + 1; j++) {
                    float vertexY = Multiplier * noise.Noise(i, j, Radius * 2 + 1, Radius * 2 + 1, Frequency);
                    float flatteningMultiplier = FlattenCenterMult == 0 ? 1 : paraboloid(i - Radius, j - Radius);
                    vertexY = Math.Clamp(vertexY, LowerCutoff, UpperCutoff) * flatteningMultiplier;
                    vertices.Add(new Vertex {
                        Position = new Vector3(i - Radius, vertexY, j - Radius),
                        Colour = AdditionalMath.Lerp(FrontColour, BackColour, i / Radius)
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

        float paraboloid(float x, float y) {
            return Math.Clamp((x * x + y * y) / (FlattenCenterMult), 0, 1);
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
        public float FlattenCenterMult { get; set; }
    }
}
