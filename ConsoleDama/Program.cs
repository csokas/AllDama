using DamaShared;

namespace ConsoleDama
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuView menuView = new MenuView();
            MenuPresenter menuPresenter = new MenuPresenter(menuView);
            menuView.AddPresenter(menuPresenter);

            menuPresenter.Init();
        }
    }
}
