using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamaShared
{
    class ManualPlayControl : PlayControl
    {
        public ManualPlayControl()
        {
        }

        public bool Turn(PuppetModel.Colour colour, Position from, Position to)
        {
            Position[] poses = { from, to };
            List<Position[]> possibleHits = SeekPuppetToHit(colour);
            List<Position[]> possibleMoves = SeekPuppetToMove(colour);

            if (possibleHits.Any(x => (x[0].x == from.x && x[0].y == from.y) && (x[1].x == to.x && x[1].y == to.y)))
            {
                Hit(from, to, colour);
                return true;
            }

            else if (possibleMoves.Any(x => (x[0].x == from.x && x[0].y == from.y) && (x[1].x == to.x && x[1].y == to.y)))
            {
                Move(from, to, colour);
                return true;
            }

            else if (possibleMoves.Contains(poses))
            {
                Move(from, to, colour);
                return true;
            }
            else
            {
                return false;
            }
        }

        private Position[] ParseCoordinate(string movement)
        {
            try
            {
                Position[] result = new Position[2];
                string[] Positions = movement.Split(' ');
                result[0] = new Position(Positions[0][1] - '1', Positions[0][0] - 'A');
                result[1] = new Position(Positions[1][1] - '1', Positions[1][0] - 'A');
                
                return result;
            }
            catch (Exception)
            {
                throw new InvalidCastException();
            }
        }
    }
}
