using Code.Hexasphere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Prototypes.GridSystem
{
    public class Territory
    {
        private int value;
        public int Value => value;

        private int _id;
        public int Id => _id;

        private Tile _tile;
        public Tile Tile => _tile;

        public Territory(int id, Tile tile = null)
        {
            _id = id;
            _tile = tile;
        }
    }
}
