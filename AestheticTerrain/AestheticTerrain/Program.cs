using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace AestheticTerrain {
    static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;

            if (args.Length > 0) {
                if (!File.Exists(args[0])) {
                    Console.WriteLine("File does not exist! Aborting ...");
                    return;
                }
                else {
                    Serializer.Deserialize(
                        args[0],
                        out ImageMetadata metadata,
                        out Renderer renderer,
                        out TerrainGenerator terrainGen,
                        out BackgroundGenerator backgroundGen
                    );

                    renderer.InitContext();

                    Bitmap renderedImage = renderer.Render(terrainGen.GenerateTerrain(), backgroundGen.GenerateBackground());

                    switch (metadata.ImageTypeIndex) {
                        case 0:
                            metadata.ImageName += ".png";
                            renderedImage.Save(metadata.ImageName, ImageFormat.Png);
                            break;
                        case 1:
                            metadata.ImageName += ".jpg";
                            renderedImage.Save(metadata.ImageName, ImageFormat.Jpeg);
                            break;
                        case 2:
                            metadata.ImageName += ".bmp";
                            renderedImage.Save(metadata.ImageName, ImageFormat.Bmp);
                            break;
                        default:
                            metadata.ImageName += ".png";
                            renderedImage.Save(metadata.ImageName, ImageFormat.Png);
                            break;
                    }

                    renderer.DestroyContext();
                    renderedImage.Dispose();
                }
            }
            else {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
        }
    }
}
