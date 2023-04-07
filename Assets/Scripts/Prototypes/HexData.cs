using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Prototypes
{
    [Serializable]
    public class HexData
    {
        [SerializeField] private Mesh _mesh;
        public Mesh Mesh => _mesh;

        public HexData(Mesh mesh)
        {
            _mesh = mesh;
        }

    }
}
