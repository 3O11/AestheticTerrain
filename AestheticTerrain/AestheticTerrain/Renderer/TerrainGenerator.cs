using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class TerrainGenerator {
        public TerrainGenerator() {
            TerrainRadius = 30;
            FuncMultiplier = new Quadratic2D();
        }

        public Mesh GenerateTerrain() {
            PerlinNoise noise = new PerlinNoise(NoiseSeed);
            List<Vertex> vertices = new List<Vertex>();
            List<int> indices = new List<int>();

            for (int i = 0; i < (TerrainRadius * 2) + 1; i++) {
                for (int j = 0; j < (TerrainRadius * 2) + 1; j++) {
                    float vertexY = Multiplier * noise.Noise(i, j, TerrainRadius * 2 + 1, TerrainRadius * 2 + 1, Frequency);
                    vertexY = Math.Clamp(vertexY, LowerCutoff, UpperCutoff) * FuncMultiplier.GetValue(i - TerrainRadius, j - TerrainRadius);
                    vertices.Add(new Vertex {
                        Position = new Vector3(i - TerrainRadius, vertexY, j - TerrainRadius),
                        Colour = Vector3.Lerp(FrontColour.ToVector(), BackColour.ToVector(), (float)i / TerrainRadius)
                    });

                    if (i > 0 && j > 0) {
                        int currentPoint = i * (TerrainRadius * 2 + 1) + j;
                        int prevPoint = currentPoint - 1;
                        int prevRowPoint = (i - 1) * (TerrainRadius * 2 + 1) + j;
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

        public int TerrainRadius { get; set; }
        public int NoiseSeed { get; set; }
        public int Multiplier { get; set; }
        public int Frequency { get; set; }
        public float Scale { get; set; }
        public Color FrontColour { get; set; }
        public Color BackColour { get; set; }
        public float LowerCutoff { get; set; }
        public float UpperCutoff { get; set; }
        public Quadratic2D FuncMultiplier { get; set; }
    }
}
