using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace AestheticTerrain {
    class Mesh {
        public Mesh(Vector3[] vertices, int[] indices) {
            // Generate Vertex Array
            _VAO = GL.GenVertexArray();
            GL.BindVertexArray(_VAO);

            // Generate Vertex Buffer, fill it with data and declare interleaved layout
            _VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _VBO);
            int vertexSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector3));
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * vertexSize, vertices, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, vertexSize, 0);

            // Generate Index Buffer and fill it with data
            _IBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _IBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
            _indexCount = indices.Length;
        }

        public static Mesh GeneratePlane(int radius) {
            List<Vector3> vertices = new List<Vector3>();
            List<int> indices = new List<int>();

            for (int i = 0; i < (radius * 2) + 1; i++) {
                for (int j = 0; j < (radius * 2) + 1; j++) {
                    vertices.Add( new Vector3(i - radius, 0, j - radius) );

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

        public void Bind() {
            GL.BindVertexArray(_VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _VBO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _IBO);
        }

        public int GetIndexCount() {
            return _indexCount;
        }

        public void Destroy() {
            GL.DeleteBuffer(_VBO);
            GL.DeleteBuffer(_IBO);
            GL.DeleteVertexArray(_VAO);
        }

        int _VAO;
        int _VBO;
        int _IBO;

        int _indexCount;
    }
}
