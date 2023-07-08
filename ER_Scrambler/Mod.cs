using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Scrambler
{
    public class Mod
    {
        public string basePath { get; set; }
        public string scramblePath { get; set; }

        public Mod() { }

        public Mod(string modPath)
        {
            this.basePath = modPath;
        }

        public void Scramble()
        {
            if (this.basePath == "")
            {
                return;
            }

            scramblePath = this.basePath + $"-Scrambled";

            if (System.IO.Directory.Exists(scramblePath))
            {
                System.IO.Directory.Delete(scramblePath, true);
            }
            System.IO.Directory.CreateDirectory(scramblePath);
            
            string source = this.basePath;
            string destination = scramblePath;

            foreach (string dirPath in Directory.GetDirectories(source, "*",
    SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(source, destination));

            foreach (string newPath in Directory.GetFiles(source, "*.*",
    SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(source, destination), true);
        }

        public bool HasPath(string path)
        {
            return System.IO.Directory.Exists($"{scramblePath}//{path}");
        }
    }
}
