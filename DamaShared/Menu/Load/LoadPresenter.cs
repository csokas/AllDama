using System;
using System.IO;

namespace DamaShared.Menu.Load
{
    class LoadPresenter : ILoadPresenter
    {
        ILoadView loadView;

        ILoadListener LoadListener;

        public LoadPresenter(ILoadView loadView, ILoadListener loadListener)
        {
            this.loadView = loadView;
            LoadListener = loadListener;
        }


        private static void Clear()
        {
            Console.Clear();
        }
        
        private static void FillTable(string[] content)
        {
            PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();
            PuppetModel.SimpleOrDama type;
            PuppetModel.Colour colour;
            for (int i = 0; i < content.Length - 1; i++)
            {
                string[] element = content[i].Split(' ');
                colour = element[0].Trim() == Constants.red ? PuppetModel.Colour.Red : PuppetModel.Colour.Blue;
                type = element[1].Trim() == Constants.simple ? PuppetModel.SimpleOrDama.Simple : PuppetModel.SimpleOrDama.Dama;
                int x = Convert.ToInt32(element[2]);
                int y = Convert.ToInt32(element[3]);

                puppets[x, y] = new PuppetModel(colour, type);
            }
        }

        private static FileInfo[] SeekFilesToLoad()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\Dama\");
            FileInfo[] files = directoryInfo.GetFiles(Constants.kiterjesztes);
            return files;
        }

        public void ListFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\Dama\");
            FileInfo[] files = directoryInfo.GetFiles(Constants.kiterjesztes);
            loadView.DisplayFiles(files);

        }

        public void LoadGame(FileInfo info)
        {
            string[] content = File.ReadAllLines(info.FullName);
            FillTable(content);
            string playerToTurn = content[content.Length - 1];


            LoadListener.OnLoadReady();
        }


    }

    public interface ILoadListener
    {
        void OnLoadReady();
    }
}
