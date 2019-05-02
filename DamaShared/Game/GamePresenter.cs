using DamaShared.Menu;
using DamaShared.Menu.Load;
using System;
using System.IO;

namespace DamaShared
{
    class GamePresenter : IGamePresenter
    {
        IGameView view;
        PuppetModel.Colour nextPlayer = PuppetModel.Colour.Blue;            //defines the starter and nextplayer colour
        PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();
        ManualPlayControl manualPlayControl = new ManualPlayControl();
        ComputerPlayControl computerPlayControl = new ComputerPlayControl();

        public GamePresenter(IGameView view)
        {
            this.view = view;
        }
        /// <summary>
        /// Initialayie a new table, then starts a new game
        /// </summary>
        public void NewGame()
        {
            TableFactory.CreateTable();
            Start();
        }
        /// <summary>
        /// Checks if the current is over if not starts a game bz show the table and call turn method
        /// </summary>
        public void Start()
        {
            PuppetModel.Colour? winnerColour = PlayControl.EndOfGame(puppets);
            if (winnerColour != null)
            {
                view.ShowGameOver(Constants.gameOverMessage + winnerColour.ToString());
            }
            else
            {
                view.ShowTable();
                Turn();
            }
        }
        public void Load(ILoadView loadView, IMenuView menuView)//menu elem betöltése
        {

            MenuPresenter menuPresenter = new MenuPresenter(menuView);
            LoadPresenter loader = new LoadPresenter(loadView, menuPresenter);
            loadView.AddPresenter(loader);
            loader.ListFiles();
        }


        public void SaveState(PuppetModel.Colour colour)
        {
            throw new NotImplementedException();
        }

        public void ManualTurn(Position from, Position to)
        {
            if (!manualPlayControl.Turn(nextPlayer, from, to))
            {
                view.ShowError(Constants.invalidLepes);
                view.WaitForTurn();
            }
            else
            {
                nextPlayer = NegateColour(nextPlayer);
                Start();
            }
        }
        /// <summary>
        /// Handles manual and computer turn, manual->WaitForTurn(); computer->computerPlayControl.Turn(nextPlayer);
        /// </summary>
        public void Turn()
        {
            if (nextPlayer == PuppetModel.Colour.Blue) //Manual
            {
                view.WaitForTurn();
            }
            else    //Computer
            {
                if (computerPlayControl.Turn(nextPlayer))
                {
                    nextPlayer = NegateColour(nextPlayer);
                }
                Start();
            }

        }

        public void ComputerPlay(PuppetModel.Colour colour)
        {
            throw new NotImplementedException();
        }


        public PuppetModel.Colour NegateColour(PuppetModel.Colour colour)
        {
            if (colour == PuppetModel.Colour.Blue) return PuppetModel.Colour.Red;
            return PuppetModel.Colour.Blue;
        }
    }
}
