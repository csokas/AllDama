using DamaShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamaShared
{
    class ComputerPlayControl : PlayControl
    {
        public ComputerPlayControl() 
        {
        }

        public bool Turn(PuppetModel.Colour colour)
        {
            List<Position[]> possibleHits = SeekPuppetToHit(colour);
            List<Position[]> possibleMoves = SeekPuppetToMove(colour);
            Random r = new Random();

            if (possibleHits.Count == 0)
            {
                if (possibleMoves.Count == 0)
                {
                    return false;
                }
                else
                {
                    Position[] actMove = possibleMoves[r.Next(possibleMoves.Count - 1)];
                    Move(actMove[0], actMove[1], colour);
                }
            }
            else
            {
                Position[] actHit = possibleHits[r.Next(possibleHits.Count - 1)];
                Hit(actHit[0], actHit[1], colour);
            }
            return true;
        }
    }
}
