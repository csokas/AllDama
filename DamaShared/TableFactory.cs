
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaShared
{
    class TableFactory
    {
       
        public static void CreateTable()
        {
            PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < puppets.GetLength(0); j++)
                {
                    if ((i % 2 == 0) && (j % 2 == 0) || (i % 2 == 1) && (j % 2 == 1))
                    {
                        puppets[i, j] = new PuppetModel(PuppetModel.Colour.Red);
                    }
                }
            }

            for (int i = puppets.GetLength(1) - 1; i > puppets.GetLength(1) - 4; i--)
            {
                for (int j = 0; j < puppets.GetLength(0); j++)
                {
                    if ((i % 2 == 0) && (j % 2 == 0) || (i % 2 == 1) && (j % 2 == 1))
                    {
                        puppets[i, j] = new PuppetModel(PuppetModel.Colour.Blue);
                    }
                }
            }
        }
    }
}
