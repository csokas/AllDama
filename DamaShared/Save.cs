using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DamaShared;

namespace DamaShared
{
    class Save
    {
        public static string path = @"D:\Dama\SavedGame3.txt";
        static PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();

        public void SaveState(PuppetModel.Colour colour)
        {
            CreateDirs();
            try
            {
                string content = "";
                for (int x = 0; x < puppets.GetLength(0); x++)
                {
                    for (int y = 0; y < puppets.GetLength(1); y++)
                    {
                        if (puppets[x, y] != null)
                        {
                            content = puppets[x, y].Color.ToString() + Constants.space + puppets[x, y].Typ.ToString() +
                                        Constants.space + x.ToString() + Constants.space + y.ToString() + Environment.NewLine;
                            File.AppendAllText(path, content);
                        }
                    }
                }
                File.AppendAllText(path, colour.ToString());
                FileInfo fInfo = new FileInfo(path)
                {
                    IsReadOnly = true
                };
            }

            catch (Exception e)
            {
                FileAlreadyExistsMessage(e);
                return;
            }
        }

        private void FileAlreadyExistsMessage(Exception e)
        {
            Console.WriteLine(Constants.fileNemLetezik); 
        }


        private void CreateDirs()
        {
            string parent = Path.GetDirectoryName(path);
            if (!Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }
        }
    }
}
