using DamaShared;
using DamaShared.Menu.Load;
using System;
using System.IO;

namespace ConsoleDama
{
    class LoadView : ILoadView
    {
        ILoadPresenter loader;

        public void AddPresenter(ILoadPresenter loadView)
        {
            this.loader = loadView;
        }
        /// <summary>
        /// Shows list of files on console and wait for selection. After selection calls presenter.loadgame()
        /// </summary>
        /// <param name="files"></param>
        public void DisplayFiles(FileInfo[] files)
        {
            Console.Clear();
            Console.WriteLine(Constants.valasszFilet);
            foreach (var file in files)
            {
                Console.WriteLine("{0} - {1}", Array.IndexOf(files, file), file.Name);
            }
            string fileNumber = Console.ReadLine();
            loader.LoadGame(files[Convert.ToInt32(fileNumber)]);
        }

    }
}
