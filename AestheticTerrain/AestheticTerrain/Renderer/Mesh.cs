using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace AestheticTerrain {
    class Mesh {
        public Mesh(Vector3[] vertices, int[] indices) : this(vertices, indices, Matrix4.Identity) {

        }

        public Mesh(Vector3[] vertices, int[] indices, Matrix4 transform) {
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

            Transform = transform;
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

        public Matrix4 Transform { get; private set; }

        int _VAO;
        int _VBO;
        int _IBO;

        int _indexCount;
    }
}
