using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    public static class Utils {
        public static Color GetColourFromDialog() {
            ColorDialog colourPicker = new ColorDialog();
            colourPicker.AllowFullOpen = true;
            colourPicker.ShowHelp = true;

            // Update the text box color if the user clicks OK 
            if (colourPicker.ShowDialog() == DialogResult.OK) {
                return colourPicker.Color;
            }
            else {
                return Color.Black;
            }
        }

        public static string GetDir() {
            string path = "";

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()) {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                    path = folderBrowserDialog.SelectedPath;
                }
            }

            return path;
        }

        public static bool IsValidFilename(string filename) {
            Regex checker = new Regex(@"^[a-zA-Z0-9-_]+$");
            return checker.IsMatch(filename);
        }

        public static void DrawCircle(Graphics g, Color colour, Vector2 center, int radius) {
            using (Brush b = new SolidBrush(colour)) {
                g.FillEllipse(b, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
        }

        public static void DrawGlow(Graphics g, Color colour, Vector2 center, int radius) {
            for (int i = radius; i > 0; i--) {
                int currentAlpha = (int)((float)155 * (radius - i) / radius);
                Color currentColour = Color.FromArgb(currentAlpha, colour);
                DrawCircle(g, currentColour, center, i);
            }
        }

        public static void DrawGradientRectangle(Graphics g, Vector2 start, Vector2 size, Color topColour, Color bottomColour) {
            Rectangle gradientRect = new Rectangle((int)start.X, (int)start.Y, (int)size.X, (int)size.Y);
            using (var gradient = new LinearGradientBrush(gradientRect, bottomColour, topColour, LinearGradientMode.Vertical)) {
                g.FillRectangle(gradient, start.X, start.Y, size.X, size.Y);
            }
        }

        public static Vector3 ToVector(this Color colour) {
            return new Vector3((float)colour.R / 255, (float)colour.G / 255, (float)colour.B / 255);
        }

        public static Color FromHex(this string hex) {
            return Color.FromArgb(Convert.ToInt32(hex, 16));
        }

        static Vector2 parseVector2(string val) {
            Regex regex = new Regex(@"^\((?<x>-?[0-9.]+), (?<y>-?[0-9.]+)\)$");
            Match m = regex.Match(val);
            if (m.Success) {
                return new Vector2(float.Parse(m.Groups["x"].Value), float.Parse(m.Groups["y"].Value));
            }
            else return new Vector2();
        }

        static Vector3 parseVector3(string val) {
            Regex regex = new Regex(@"^\((?<x>-?[0-9.]+), (?<y>-?[0-9.]+), (?<z>-?[0-9.]+)\)$");
            Match m = regex.Match(val);
            if (m.Success) {
                return new Vector3(float.Parse(m.Groups["x"].Value), float.Parse(m.Groups["y"].Value), float.Parse(m.Groups["z"].Value));
            }
            else return new Vector3();
        }

        static Quadratic2D parseQuadratic2D(string val) {
            // This regex is very chonky, I'm sorry for that
            Regex regex = new Regex(@"^\((?<xQuad>-?[0-9.]+), (?<yQuad>-?[0-9.]+), (?<xyLin>-?[0-9.]+), (?<xLin>-?[0-9.]+), (?<yLin>-?[0-9.]+), (?<Const>-?[0-9.]+), (?<Clamp>True|False), (?<TopClamp>-?[0-9.]+), (?<BottomClamp>-?[0-9.]+)\)$");
            Match m = regex.Match(val);
            if (m.Success) {
                Quadratic2D func = new Quadratic2D();
                func.xQuad = float.Parse(m.Groups["xQuad"].Value);
                func.yQuad = float.Parse(m.Groups["yQuad"].Value);
                func.xyLin = float.Parse(m.Groups["xyLin"].Value);
                func.xLin = float.Parse(m.Groups["xLin"].Value);
                func.yLin = float.Parse(m.Groups["yLin"].Value);
                func.Const = float.Parse(m.Groups["Const"].Value);
                func.Clamp = bool.Parse(m.Groups["Clamp"].Value);
                func.TopClamp = float.Parse(m.Groups["TopClamp"].Value);
                func.BottomClamp = float.Parse(m.Groups["BottomClamp"].Value);

                return func;
            }
            else return new Quadratic2D();
        }

        ////////// Serialization helpers

        public static string Serialize(this object val) {
            // I like to live dangerously 
            dynamic d = val;
            return Serialize(d);
        }

        public static string Serialize(this int val) {
            return val.ToString();
        }

        public static string Serialize(this float val) {
            return val.ToString();
        }

        public static string Serialize(this bool val) {
            return val.ToString();
        }

        public static string Serialize(this string val) {
            return val;
        }

        public static string Serialize(this Vector2 val) {
            return val.ToString();
        }

        public static string Serialize(this Vector3 val) {
            return val.ToString();
        }

        public static string Serialize(this Color val) {
            return val.ToArgb().ToString("X");
        }

        public static string Serialize(this Quadratic2D val) {
            return "(" + val.xQuad + ", " + val.yQuad + ", " + val.xyLin + ", " + val.xLin + ", " + val.yLin + ", " + val.Const + "; " + val.Clamp + ", " + val.TopClamp + ", " + val.BottomClamp + ")";
        }

        public static object Deserialize(string value, Type type) {
            if (type == typeof(int)) return int.Parse(value);
            if (type == typeof(float)) return float.Parse(value);
            if (type == typeof(bool)) return bool.Parse(value);
            if (type == typeof(string)) return value;
            if (type == typeof(Vector2)) return parseVector2(value);
            if (type == typeof(Vector3)) return parseVector3(value);
            if (type == typeof(Color)) return value.FromHex();
            if (type == typeof(Quadratic2D)) return parseQuadratic2D(value);

            return null;
        }
    }
}
