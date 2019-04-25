using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamaShared
{
    abstract class PlayControl
    {
        protected PuppetModel[,] puppets = SingletonPuppets.instance.Value.GetInstance();

        protected List<Position[]> SeekPuppetToMove(PuppetModel.Colour colour)
        {
            List<Position[]> possibleMoves = new List<Position[]>();
            Position fromPos;
            for (int x = 0; x < puppets.GetLength(0); x++)
            {
                for (int y = 0; y < puppets.GetLength(1); y++)
                {
                    fromPos = new Position(x, y);
                    if (PuppetIsExist(fromPos, colour))
                    {
                        List<Position> allCoordinatesMove = PossibleMove(fromPos, colour);
                        foreach (var toPos in allCoordinatesMove)
                        {
                            possibleMoves.Add(new Position[2] {fromPos, toPos});
                        }
                    }
                }
            }
            return possibleMoves;
        }

        protected List<Position[]> SeekPuppetToHit(PuppetModel.Colour colour)
        {
            List<Position[]> possibleHits = new List<Position[]>();
            for (int x = 0; x < puppets.GetLength(0); x++)
            {
                for (int y = 0; y < puppets.GetLength(1); y++)
                {
                    Position fromPos = new Position(x, y);
                    if (PuppetIsExist(fromPos, colour))
                    {
                        List<Position> allToCoordinatesHit = PossibleHit(fromPos, colour);
                        foreach (var toPos in allToCoordinatesHit)
                        {
                            possibleHits.Add(new Position[2] {fromPos, toPos});
                        }
                    }
                }
            }
            return possibleHits;
        }


        protected List<Position> PossibleMove(Position from, PuppetModel.Colour colour)
        {
            List<Position> possibleMoves = new List<Position>();
            int length = puppets[from.x, from.y].Typ == PuppetModel.SimpleOrDama.Simple ? 2 : 4; //dáma 4 lehetőséget vizsgál, simple 2-t
            int xdiff = colour == PuppetModel.Colour.Blue ? 1 : -1; //kék előre piros hátra
            Position to;
            for (int i = 0; i < length; i++)
            {
                if (i == 2)
                {
                    xdiff *= -1;//dáma
                }
                to = CalculateToCoordinatesMove(from, xdiff, i % 2 == 0);
                if (CanMove(from, to, colour))
                {
                    possibleMoves.Add(to);
                }
            }
            return possibleMoves;
        }

        protected bool CanMove(Position from, Position to, PuppetModel.Colour colour)
        {
            try
            {
                PuppetModel freeSpace = puppets[to.x, to.y];
                if (freeSpace == null)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private Position CalculateToCoordinatesMove(Position pos, int xdiff, bool isRight)
        {
            int sign = isRight ? -1 : 1;
            return new Position (pos.x - xdiff, pos.y + sign );
        }

        protected List<Position> PossibleHit(Position from, PuppetModel.Colour colour)
        {
            List<Position> PossibleHits = new List<Position>();
            int xdiff = colour == PuppetModel.Colour.Blue ? 1 : -1;
            Position to;
            int length = puppets[from.x, from.y].Typ == PuppetModel.SimpleOrDama.Simple ? 2 : 4;

            for (int i = 0; i < length; i++)
            {
                if (i == 2)
                {
                    xdiff *= -1;
                }
                to = CalculateToCoordinatesHit(from, xdiff, i % 2 == 0);
                if (CanHit(from, to, colour))
                {
                    PossibleHits.Add(to);
                }
            }
            return PossibleHits;
        }

        /// <summary>
        /// Is valid hit
        /// </summary>
        /// <param name="fromX">from coordinate</param>
        /// <param name="fromY">from coordinate</param>
        /// <param name="xdiff">up or down direction</param>
        /// <param name="colour">puppet colour</param>
        /// <param name="isRight">right or left</param>
        /// <returns>returns true if the hit is valid, false if not</returns>
        protected bool CanHit(Position from, Position to, PuppetModel.Colour colour)
        {
            try
            {
                PuppetModel enemy = puppets[(from.x + to.x) / 2, (from.y + to.y) / 2];
                PuppetModel freeSpace = puppets[to.x, to.y];
                if (enemy.Color == NegateColour(colour) && freeSpace == null)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private Position CalculateToCoordinatesHit(Position pos, int xdiff, bool isRight)
        {
            int sign = isRight ? -1 : 1;
            return new Position ( pos.x - 2 * xdiff, pos.y + sign * 2 );
        }

        protected void Hit(Position from, Position to, PuppetModel.Colour colour)
        {
            puppets[to.x, to.y] = puppets[from.x, from.y]; //bábú áthelyezése
            puppets[from.x, from.y] = null;      //bábú áthelyezése
            puppets[(to.x + from.x) / 2, (from.y + to.y) / 2] = null;          //levétel
            if (colour == PuppetModel.Colour.Blue && to.x == 0)
            {
                puppets[to.x, to.y].Typ = PuppetModel.SimpleOrDama.Dama;
            }
            if (colour == PuppetModel.Colour.Red && to.x == 7)
            {
                puppets[to.x, to.y].Typ = PuppetModel.SimpleOrDama.Dama;
            }
            //View.DisplayTable(puppets);
        }
        protected PuppetModel.Colour NegateColour(PuppetModel.Colour colour)
        {
            if (colour == PuppetModel.Colour.Blue) return PuppetModel.Colour.Red;
            return PuppetModel.Colour.Blue;
        }

        protected void Move(Position from, Position to, PuppetModel.Colour colour)
        {
            puppets[to.x, to.y] = puppets[from.x, from.y];  //bábú áthelyezése
            puppets[from.x, from.y] = null;               //bábú levétele
            if (colour == PuppetModel.Colour.Blue && to.x == 0)
            {
                puppets[to.x, to.y].Typ = PuppetModel.SimpleOrDama.Dama;
            }
            if (colour == PuppetModel.Colour.Red && to.x == 7)
            {
                puppets[to.x, to.y].Typ = PuppetModel.SimpleOrDama.Dama;
            }
            //View.DisplayTable(puppets);
        }
        protected bool PuppetIsExist(Position pos, PuppetModel.Colour colour)//az adott koordinátájú mezőn adott színű bábú szerepel-e
        {
            if ((puppets[pos.x, pos.y] != null) && puppets[pos.x, pos.y].Color == colour)
                return true;
            return false;
        }

        public static PuppetModel.Colour? EndOfGame(PuppetModel[,] puppets)
        {
            int numberOfReds = 0;
            int numberOfBlues = 0;
            for (int i = 0; i < puppets.GetLength(0); i++)
            {
                for (int j = 0; j < puppets.GetLength(1); j++)
                {
                    if (puppets[i, j] != null)
                    {
                        if (puppets[i, j].Color == PuppetModel.Colour.Blue) numberOfBlues++;
                        else numberOfReds++;
                    }
                }
            }
            if (numberOfBlues == 0)
                return PuppetModel.Colour.Red;
            if (numberOfReds == 0)
                return PuppetModel.Colour.Blue;
            return null;
        }
    }
}
