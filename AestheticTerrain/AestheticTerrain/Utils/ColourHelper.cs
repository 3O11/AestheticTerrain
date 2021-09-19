using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    class ColourHelper {
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

        public static Vector3 ConvertToVector(Color colour) {
            return new Vector3((float)colour.R / 255, (float)colour.G / 255, (float)colour.B / 255);
        }

        public static Vector3 GetGradient(Vector3 u, Vector3 v, float blend) {
            return new Vector3(blend * u + (1 - blend) * v);
        }
    }
}
