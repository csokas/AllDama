using DamaShared.Menu;
using DamaShared.Menu.Load;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamaShared
{
    public interface IGameView
    {
        void ShowTable();
        void WaitForTurn();
        void ShowError(string message);
        void ShowGameOver(string message);
        void Clear();
        string ChooseFileToLoad();
        void DisplayField(PuppetModel puppet);
        void AddPresenter(IGamePresenter presenter);
        void Wait();
        Position[] ParseCoordinates(string nextMove);
    }

    public interface IGamePresenter
    {
        void NewGame();
        void SaveState(PuppetModel.Colour colour);
        void Load(ILoadView loadView, IMenuView menuView);
        void ManualTurn(Position from, Position to);
    }
}
