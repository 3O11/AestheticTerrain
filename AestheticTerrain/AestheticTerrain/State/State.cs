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

        public Resolution(Resolution r) {
            Width = r.Width;
            Height = r.Height;
        }

        public Vector2i AsVector() {
            return new Vector2i(Width, Height);
        }

        public float GetAspectRatio() {
            return (float)Width / Height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }

    class State {
        public State() {

        }

        public State(State s) {
            ImgType = s.ImgType;
            ImgResolution = new Resolution(s.ImgResolution);

            TerrainMeshRadius = s.TerrainMeshRadius;
            TerrainSeed = s.TerrainSeed;
            TerrainLowerCutoff = s.TerrainLowerCutoff;
            TerrainUpperCutoff = s.TerrainUpperCutoff;

            BgSunPosition = new Vector2i(s.BgSunPosition.X, s.BgSunPosition.Y);
            BgSunRadius = s.BgSunRadius;
            BgSunColour = new Vector3i(s.BgSunColour.X, s.BgSunColour.Y, s.BgSunColour.Z);
            BgStarCount = s.BgStarCount;
            BgStarSpacing = s.BgStarSpacing;
            BgStarColour = new Vector3i(s.BgStarColour.X, s.BgStarColour.Y, s.BgStarColour.Z);
        }

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

            s.BgSunColour = new Vector3i(176, 38, 255);

            return s;
        }
    }
}
