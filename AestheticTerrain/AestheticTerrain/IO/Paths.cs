using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AestheticTerrain {
    class Paths {
        public static string GetPath(string fileExtensions) {
            string path = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = fileExtensions;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    path = openFileDialog.FileName;
                }
            }

            return path;
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
            Regex checker = new Regex("^[a-zA-Z0-9-_]+$");
            return checker.IsMatch(filename);
        }
    }
}
