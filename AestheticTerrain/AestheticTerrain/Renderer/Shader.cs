using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace AestheticTerrain {
    class Shader {
        public Shader(string vertFilepath, string fragFilepath) {
            _shaderID = createShader(getShaderSource(vertFilepath), getShaderSource(fragFilepath));
            _uniformLocationCache = new Dictionary<string, int>();
        }

        public void SetUniformMat4f(string name, Matrix4 matrix) {
            GL.UniformMatrix4(getUniformLocation(name), false, ref matrix);
        }

        public void SetUniform1i(string name, int i) {
            GL.Uniform1(getUniformLocation(name), i);
        }

        public void Bind() {
            GL.UseProgram(_shaderID);
        }

        public void Destroy() {
            GL.DeleteProgram(_shaderID);
        }

        int getUniformLocation(string name) {
            if (_uniformLocationCache.ContainsKey(name)) {
                return _uniformLocationCache[name];
            }

            int location = GL.GetUniformLocation(_shaderID, name);
            _uniformLocationCache[name] = location;

            return location;
        }

        int createShader(string vertShaderSource, string fragShaderSource) {
            int program = GL.CreateProgram();
            int vertShader = compileShader(ShaderType.VertexShader, vertShaderSource);
            int fragShader = compileShader(ShaderType.FragmentShader, fragShaderSource);

            GL.AttachShader(program, vertShader);
            GL.AttachShader(program, fragShader);
            GL.LinkProgram(program);
            GL.ValidateProgram(program);

            GL.DeleteShader(vertShader);
            GL.DeleteShader(fragShader);

            return program;
        }

        int compileShader(ShaderType shaderType, string shaderSource) {
            int id = GL.CreateShader(shaderType);

            GL.ShaderSource(id, shaderSource);
            GL.CompileShader(id);

            Console.WriteLine(GL.GetShaderInfoLog(id));

            return id;
        }

        string getShaderSource(string filepath) {
            StreamReader reader = new StreamReader(filepath);
            string source = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            return source;
        }

        int _shaderID;
        Dictionary<string, int> _uniformLocationCache;
    }
}
