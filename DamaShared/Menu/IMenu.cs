using DamaShared.Menu.Load;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaShared.Menu
{
   public  interface IMenuView
    {
        void DisplayMenuItems();
    }

    public interface IMenuPresenter
    {
        void Init();
        void Play(IGameView view);
        void Load(IGameView view, ILoadView loadView);
        void Quit();
    }
}
