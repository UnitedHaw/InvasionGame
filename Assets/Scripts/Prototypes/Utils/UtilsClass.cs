using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class UtilsClass
    {

        public static TextMesh CreateHexText(string text, Transform parent = null, Vector3 loacalPosition = default(Vector3),
            Vector3 rotation = default, int fontSize = 10, Color color = default)
        {
            GameObject gameObject = new GameObject("HexCount", typeof(TextMesh));
            gameObject.transform.position = loacalPosition;
            Transform transform = gameObject.transform;
            transform.SetParent(parent);
            transform.localPosition = loacalPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.text = text;
            textMesh.alignment = TextAlignment.Center;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.color = color;

            return textMesh;
        }
        public static Vector3 GetMouseWorldPosition(Vector3 mousePosition)
        {
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
