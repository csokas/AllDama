using DamaShared.Menu;
using DamaShared.Menu.Load;
using System;

namespace DamaShared
{
    class MenuPresenter : IMenuPresenter, ILoadListener
    {
        IMenuView menuView;
        IGameView gameView;

        public MenuPresenter(IMenuView menuView)
        {
            this.menuView = menuView;
        }

        //public MenuPresenter()
        //{

        //}

        public void Init()
        {
            menuView.DisplayMenuItems();
        }

        public void Load(IGameView gameView, ILoadView loadView)
        {
            this.gameView = gameView;
            LoadPresenter loader = new LoadPresenter(loadView, this);
            loadView.AddPresenter(loader);
            loader.ListFiles();

        }

        public void OnLoadReady()
        {
            GamePresenter gamePresenter = new GamePresenter(gameView);
            gamePresenter.Start();
        }

        public void Play(IGameView gameView)
        {
            GamePresenter gamePresenter = new GamePresenter(gameView);
            gameView.AddPresenter(gamePresenter);

            gamePresenter.NewGame();
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
    }
}
