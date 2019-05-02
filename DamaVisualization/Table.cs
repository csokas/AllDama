using DamaShared;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace DamaVisualization
{
    public partial class Table : Form, IGameView
    {
        new const int Size = 50;
        private string from = null;
        private string to;
        private IGamePresenter gamePresenter;
        PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();
        private Button prevoiusButton;

        public Table()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();
            Button b;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    b = new Button
                    {
                        Width = Size,
                        Height = Size
                    };
                    if ((i + j) % 2 == 1)
                    {
                        b.BackColor = Color.Black;
                    }

                    b.Location = new Point(0 + b.Width * i, 0 + b.Height * j);
                    b.Click += new System.EventHandler(this.button1_Click);
                    b.Tag = new Position(j, i);
                    Controls.Add(b);
                }
            }
            ShowTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string to = null;
            if (sender is Button)
            {
                Button button = sender as Button;
                richTextBox1.Text = button.Tag.ToString();
                if (from == null)
                {
                    from = button.Tag.ToString();
                }
                else
                {
                    to = button.Tag.ToString();
                }

                if (prevoiusButton == null)
                {
                    prevoiusButton = button;
                }
                else
                {
                    gamePresenter.ManualTurn(prevoiusButton.Tag as Position, button.Tag as Position);
                    prevoiusButton = null;
                }
            }

        }

        public void ShowTable()
        {
            Position tag;
            foreach (var item in Controls)
            {
                if (item is Button)
                {
                    Button b = (item as Button);
                    tag = (item as Button).Tag as Position;

                    if (puppets[tag.x, tag.y] != null)
                    {
                        if (puppets[tag.x, tag.y].Color == PuppetModel.Colour.Blue)
                        {
                            b.Image = Image.FromFile(@"C:\Users\Lackó\Pictures\Blue.png");
                        }
                        else
                        {
                            b.Image = Image.FromFile(@"C:\Users\Lackó\Pictures\Red.png");
                        }
                    }
                    else
                    {
                        b.Image = null;
                    }
                }
            }
        }

        public void WaitForTurn()
        {
            //string nextMove = from + to;
            //Position[] poses = ParseCoordinates(nextMove);
            //if (poses != null)
            //{
            //    gamePresenter.ManualTurn(poses[0], poses[1]);
            //}
            //else
            //{
            //    ShowError("Nagyon hibás paraméter");
            //    WaitForTurn();
            //}
        }

        private string FindPositions()
        {
            //throw new NotImplementedException();
            return null;
        }

        public void ShowError(string message)
        {
            richTextBox1.Text = message;
        }

        public void ShowGameOver(string message)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public string ChooseFileToLoad()
        {
            throw new NotImplementedException();
        }

        public void DisplayField(PuppetModel puppet)
        {
            throw new NotImplementedException();
        }

        public void AddPresenter(IGamePresenter presenter)
        {
            gamePresenter = presenter;
        }

        public void Wait()
        {
            throw new NotImplementedException();
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
