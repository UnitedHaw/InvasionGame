using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GridSystem
{
    public enum GridType
    {
        Cell,
        Hex
    }

     class GridFactory
    {
        public TextMesh Create(SquareCell cell, Transform parent, int fontSize)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = cell.Position;

            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Left;
            textMesh.text = cell.Value.ToString();
            textMesh.fontSize = fontSize;
            textMesh.color = Color.white;

            return textMesh;
        }
    }
}