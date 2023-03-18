using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GridSystem
{
    public class Cell
    {
        private int value;        
        public int Value => value;

        private Sprite _borderSprite;
        public Sprite BorderSprite => _borderSprite;

        protected Cell(int value, Sprite sprite = null)
        {
            this.value = value;
            _borderSprite = sprite;

        }
        
        public virtual void SetValue(int value)
        {
            this.value = value;
        }


    }
}
