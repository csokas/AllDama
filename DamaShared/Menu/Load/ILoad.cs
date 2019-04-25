using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DamaShared.Menu.Load
{
    public interface ILoadView
    {
        void DisplayFiles(FileInfo[] files);
        void AddPresenter(ILoadPresenter loadPresenter);
    }

    public interface ILoadPresenter
    {
        void ListFiles();
        void LoadGame(FileInfo info);
    }
}
