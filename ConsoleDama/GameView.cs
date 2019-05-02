using DamaShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDama
{
    public class GameView : IGameView
    {
        IGamePresenter presenter;

        public void AddPresenter(IGamePresenter presenter)
        {
            this.presenter = presenter;
        }
        public GameView()
        {
            presenter = new GamePresenter(this);
        }
        public string ChooseFileToLoad()
        {
            ShowError(Constants.valasszFilet);
            string fileNumber = Console.ReadLine();
            return fileNumber;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayField(PuppetModel puppet)
        {
            if (puppet != null)
            {
                Console.Write(Constants.I);
                if (puppet.Color == PuppetModel.Colour.Blue)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("{0}", puppet.Typ == PuppetModel.SimpleOrDama.Simple ? Constants.X : Constants.Y);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(Constants.ISpace);
            }
        }

        public void ShowError(string message)
        {
            Clear();
            ShowTable();
            Console.WriteLine("\n" + message);
        }

        public void ShowGameOver(string message)
        {
            Clear();
            Console.WriteLine(message);
        }
        /// <summary>
        /// Iterates a "table modell" 2D singleton array and display its fields
        /// </summary>
        public void ShowTable()
        {
            PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();
            Clear();

            for (int x = 0; x < puppets.GetLength(1); x++)
            {
                Console.WriteLine(Constants.top);
                Console.Write("{0} ", x + 1);
                for (int y = 0; y < puppets.GetLength(0); y++)
                {
                    DisplayField(puppets[x, y]);
                }
                Console.WriteLine("|");
            }

            Console.Write("   ");
            for (int i = 0; i < puppets.GetLength(0); i++)
            {
                Console.Write("{0} ", Convert.ToChar('A' + i));
            }
            //Console.ReadKey();
        }

        public void WaitForTurn()
        {
            Console.WriteLine();
            Console.WriteLine("Ön jön! Így adja meg a lépését pl.:B2 C3");
            string nextMove = Console.ReadLine();
            Position[] poses = ParseCoordinates(nextMove);
            if (poses != null)
            {
                presenter.ManualTurn(poses[0], poses[1]);
            }
            else
            {
                ShowError("Nagyon hibás paraméter");
                WaitForTurn();
            }
        }

        public Position[] ParseCoordinates(string nextMove)
        {
            try
            {
                return new Position[] { new Position(Convert.ToInt32(nextMove[1] - '1'), (nextMove[0] - 'A')),
                new Position(Convert.ToInt32(nextMove[4] - '1'), nextMove[3] - 'A')};

            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Wait()
        {
            Console.ReadLine();
        }
    }
}