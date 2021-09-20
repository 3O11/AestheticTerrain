using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace AestheticTerrain {
    class ImageMetadata {
        public string ImageName { get; set; }
        public int ImageTypeIndex { get; set; }
    }

    class Serializer {
        public static string GetSavepathFromDialog() {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "Aesthetic Terrain State files (*.ats)|*.ats|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    string filename = saveFileDialog.FileName;
                    if (!filename.EndsWith(".ats")) filename += ".ats";
                    return filename;
                }
            }
            return "";
        }

        public static string GetOpenpathFromDialog() {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Aesthetic Terrain State files (*.ats)|*.ats|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    return openFileDialog.FileName;
                }
            }
            return "";
        }

        public static void Serialize(string filepath, ImageMetadata imgMeta, Renderer renderer, TerrainGenerator terrainGen, BackgroundGenerator backgroundGen) {
            StreamWriter writer = new StreamWriter(filepath);

            List<PropertyInfo> imageMetaProperties = new List<PropertyInfo>(imgMeta.GetType().GetProperties());
            foreach (var property in imageMetaProperties) {
                writer.WriteLine(property.Name + "=" + property.GetValue(imgMeta).Serialize());
            }

            List<PropertyInfo> rendererProperties = new List<PropertyInfo>(renderer.GetType().GetProperties());
            foreach (var property in rendererProperties) {
                writer.WriteLine(property.Name + "=" + property.GetValue(renderer).Serialize());
            }

            List<PropertyInfo> terrainGenProperties = new List<PropertyInfo>(terrainGen.GetType().GetProperties());
            foreach (var property in terrainGenProperties) {
                writer.WriteLine(property.Name + "=" + property.GetValue(terrainGen).Serialize());
            }

            List<PropertyInfo> backgroundGenProperties = new List<PropertyInfo>(backgroundGen.GetType().GetProperties());
            foreach (var property in backgroundGenProperties) {
                writer.WriteLine(property.Name + "=" + property.GetValue(backgroundGen).Serialize());
            }

            writer.Close();
            writer.Dispose();
        }

        public static void Deserialize(string filepath, out ImageMetadata imgMeta, out Renderer renderer, out TerrainGenerator terrainGen, out BackgroundGenerator backgroundGen) {
            // Prepare necessary variables
            renderer = new Renderer();
            terrainGen = new TerrainGenerator();
            backgroundGen = new BackgroundGenerator();
            imgMeta = new ImageMetadata();

            List<Tuple<string, string>> keyValPairs = new List<Tuple<string, string>>();
            using (StreamReader reader = new StreamReader(filepath)) {
                string line = reader.ReadLine();
                while (line != null) {
                    if (line.Trim().StartsWith("//")) continue;
                    var splitLine = line.Split(new char[] { '=' });
                    if (splitLine.Length != 2) continue;

                    keyValPairs.Add(new(splitLine[0], splitLine[1]));

                    line = reader.ReadLine();
                }
            }

            Dictionary<string, Tuple<PropertyInfo, object>> properties = new Dictionary<string, Tuple<PropertyInfo, object>>();
            foreach (var prop in imgMeta.GetType().GetProperties()) properties.Add(prop.Name, new(prop, imgMeta));
            foreach (var prop in renderer.GetType().GetProperties()) properties.Add(prop.Name, new(prop, renderer));
            foreach (var prop in terrainGen.GetType().GetProperties()) properties.Add(prop.Name, new(prop, terrainGen));
            foreach (var prop in backgroundGen.GetType().GetProperties()) properties.Add(prop.Name, new(prop, backgroundGen));

            foreach (var pair in keyValPairs) {
                if (properties.ContainsKey(pair.Item1)) {
                    var propertyPair = properties[pair.Item1];
                    propertyPair.Item1.SetValue(propertyPair.Item2, Utils.Deserialize(pair.Item2, propertyPair.Item1.PropertyType));
                }
            }
        }
    }
}
