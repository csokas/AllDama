using DamaShared;
using DamaShared.Menu;
using DamaShared.Menu.Load;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamaVisualization
{
    public partial class Menu : Form, IMenuView, ILoadView, ILoadListener
    {
        private IMenuPresenter menuPresenter;
        private ILoadPresenter loadPresenter;

        public Menu()
        {
            InitializeComponent();
        }

        private void PlayClick(object sender, EventArgs e)
        {
            Table table = new Table();
            menuPresenter.Play(table);
            table.Show();
            //TODO:Csak a menut bezárni??
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            menuPresenter = new MenuPresenter(this);

            menuPresenter.Init();
        }

        public void DisplayMenuItems()
        {
           //TODO:Refactor behavior
        }

        private void QuitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadClick(object sender, EventArgs e)
        {
            //this.gameView = gameView;
            LoadPresenter loader = new LoadPresenter(this, this);
            AddPresenter(loader);
            loader.ListFiles();
        }

        public void DisplayFiles(FileInfo[] files)
        {
            Table table = new Table();
            table.GetRichTextBoxText = "";
            table.GetRichTextBoxText += Constants.valasszFilet;
            foreach (var file in files)
            {
                //Console.WriteLine("{0} - {1}", Array.IndexOf(files, file), file.Name);
                table.GetRichTextBoxText += Array.IndexOf(files, file) + "-" + file.Name;
            }
            string fileNumber = Console.ReadLine();
            loadPresenter.LoadGame(files[Convert.ToInt32(fileNumber)]);
        }

        public void AddPresenter(ILoadPresenter loadPresenter)
        {
            this.loadPresenter = loadPresenter;
        }

        public void OnLoadReady()
        {
            throw new NotImplementedException();
        }
    }
}
