using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    class UtilsClass
    {
        public static Vector3 GetMouseWorldPosition(Vector3 mousePosition)
        {
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
