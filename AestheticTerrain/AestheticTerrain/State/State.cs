using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Mathematics;

namespace AestheticTerrain {

    enum ImageType {
        PNG,
        JPEG,
        BMP,
    }

    class Resolution {
        public Resolution(int width, int height) {
            Width = width;
            Height = height;
        }

        public Vector2i AsVector() {
            return new Vector2i(Width, Height);
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }

    class State {
        // Image Options
        public ImageType ImgType { get; set; }
        public Resolution ImgResolution { get; set; }

        // Terrain Options
        public int TerrainMeshRadius { get; set; }
        public int TerrainSeed { get; set; }
        public float TerrainLowerCutoff { get; set; }
        public float TerrainUpperCutoff { get; set; }

        // Background Options
        public Vector2i BgSunPosition { get; set; }
        public int BgSunRadius { get; set; }
        public Vector3i BgSunColour { get; set; }
        public int BgStarCount { get; set; }
        public int BgStarSpacing { get; set; }
        public Vector3i BgStarColour { get; set; }

        public static State GetDefault() {
            State s = new State();

            s.ImgType = ImageType.PNG;
            s.ImgResolution = new Resolution(1280, 720);

            s.BgSunColour = new Vector3i(0, 0, 255);

            return s;
        }
    }
}
