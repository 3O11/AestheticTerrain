using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace AestheticTerrain {
    struct Vertex {
        public Vector3 Position { get; set; }
        public Vector2 TexCoords { get; set; }
    }

    class Mesh {
        public Mesh(Vertex[] vertices, int[] indices) {
            // Generate Vertex Array
            _VAO = GL.GenVertexArray();
            GL.BindVertexArray(_VAO);

            // Generate Vertex Buffer, fill it with data and declare interleaved layout
            _VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _VBO);
            int vertexSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vertex));
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * vertexSize, vertices, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, vertexSize, 0);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, vertexSize, 3 * sizeof(float));

            // Generate Index Buffer and fill it with data
            _IBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _IBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
            _indexCount = indices.Length;
        }

        public static Mesh GeneratePlane(int radius) {
            List<Vertex> vertices = new List<Vertex>();
            List<int> indices = new List<int>();

            for (int i = 0; i < (radius * 2) + 1; i++) {
                for (int j = 0; j < (radius * 2) + 1; j++) {
                    vertices.Add( new Vertex() { Position = new Vector3(i, 0, j), TexCoords = new Vector2(i, j) } );

                    if (i > 0 && j > 0) {
                        int currentPoint = i * (radius * 2 + 1) + j;
                        int prevPoint = currentPoint - 1;
                        int prevRowPoint = (i - 1) * (radius * 2 + 1) + j;
                        int prevRowPrevPoint = prevRowPoint - 1;

                        // Adding a new square.
                        indices.Add(currentPoint);
                        indices.Add(prevRowPoint);
                        indices.Add(prevPoint);

                        indices.Add(prevRowPoint);
                        indices.Add(prevRowPrevPoint);
                        indices.Add(prevPoint);
                    }
                }
            }

            return new Mesh(vertices.ToArray(), indices.ToArray());
        }

        public static Mesh GenerateTerrain(int radius, int seed) {
            return GeneratePlane(radius);
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
