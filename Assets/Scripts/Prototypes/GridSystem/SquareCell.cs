using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GridSystem
{
    public class SquareCell : Cell
    {
        private Vector3 _position;

        public Vector3 Position => _position;

        private TextMesh _textMesh;
        public TextMesh ValueText { 
            get {
                _textMesh.text = Value.ToString();
                return _textMesh;
            } }

        public SquareCell(
            int value = 0, Sprite sprite = null, Vector3 position = default, Transform parent = null, int fontSize = 10) 
            : base(value, sprite)
        {
            _position = position;
            _textMesh = Create(parent, fontSize);
        }

        private TextMesh Create(Transform parent = null, int fontSize = 10)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;

            if(parent != null)
                transform.SetParent(parent, false);

            transform.localPosition = _position;

            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Left;
            textMesh.text = Value.ToString();
            textMesh.fontSize = fontSize;
            textMesh.color = Color.white;

            return textMesh;
        }

        public override void SetValue(int value)
        {
            base.SetValue(value);
            _textMesh.text = Value.ToString();
        }
    }
}
