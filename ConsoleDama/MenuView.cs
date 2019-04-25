using DamaShared;
using DamaShared.Menu;
using System;

namespace ConsoleDama
{
    class MenuView : IMenuView
    {
        static string[] menuItems = { Constants.play, Constants.load, Constants.quit };
        static int currentSelection = 0;
        IMenuPresenter menuPresenter;
        
        public void AddPresenter(IMenuPresenter menuPresenter)
        {
            this.menuPresenter = menuPresenter;
        }

        private void Show()
        {
            const int startX = 15;
            const int startY = 8;
            int optionsPerLine = menuItems.Length;
            const int spacingPerLine = 14;

            Console.CursorVisible = false;

            Console.Clear();

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                if (i == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write(menuItems[i]);

                Console.ResetColor();
            }

            Console.CursorVisible = true;

        }
        /// <summary>
        /// Handle console to choose from menuitems and call the right method Play, Load, Quit
        /// from menuPresenter
        /// </summary>
        private void HandleMenuItems()
        {
            int optionsPerLine = menuItems.Length;
            ConsoleKey key;
            do
            {
                Show();
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < menuItems.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            menuPresenter.Quit();
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            switch (currentSelection)
            {
                case 0:
                    menuPresenter.Play(new GameView());
                    break;
                case 1:
                    menuPresenter.Load(new GameView(), new LoadView());
                    break;
                case 2:
                    menuPresenter.Quit();
                    break;
                default:
                    break;
            }
        }

        public void DisplayMenuItems()
        {
            HandleMenuItems();
        }
    }
}

