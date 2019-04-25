using DamaShared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DamaVisualization
{
    public partial class Table : Form
    {
        new const int Size = 50;
        string from = null;
        
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
                    if (puppets[j, i] != null)
                    {
                        if (puppets[j, i].Color == PuppetModel.Colour.Blue)
                        {
                            b.Image = Image.FromFile(@"C:\Users\Lackó\Pictures\Blue.png");
                        }
                        else
                        {
                            b.Image = Image.FromFile(@"C:\Users\Lackó\Pictures\Red.png");
                        }
                    }

                    b.Location = new Point(0 + b.Width * i, 0 + b.Height * j);
                    b.Click += new System.EventHandler(this.button1_Click);
                    b.Tag = new Position(i, j);
                    Controls.Add(b);
                }
            }

           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string to = null;
            if (sender is Button)
            {
                richTextBox1.Text = ((Button)sender).Tag.ToString();
                if(from == null)
                {
                    from = ((Button)sender).Tag.ToString();
                }
                else
                {
                    to = ((Button)sender).Tag.ToString();
                }
                
            }
            
        }


    }
}
