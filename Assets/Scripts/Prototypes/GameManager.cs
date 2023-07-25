using Code.Hexasphere;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _sphereTranform;
    [SerializeField] private Transform _pfPoint;
    [SerializeField] private DrawHexasphere _drawHexasphere;
    private Hexasphere _hexasphere;
    private Camera _mainCamera;

    private Touch touch;

    private void Start()
    {
        _mainCamera = Camera.main;
        _hexasphere = _sphereTranform.GetComponent<DrawHexasphere>().Hexasphere;

    }

    private void Update()
    {
        ReycastInput();
    }

    private void ReycastInput()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    StartRaycast(touch);
                    break;

            }  
        }
    }

    private void StartRaycast(Touch touch)
    {
        var touchPoint = touch.position;
        Ray ray = _mainCamera.ScreenPointToRay(touchPoint);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var hitPont = hitInfo.point;
            var center = hitInfo.transform.position;

            var outPoint = hitInfo.normal * _hexasphere.Radius/2;

            var newRay = new Ray(outPoint, -hitInfo.normal);

            if (Physics.Raycast(newRay, out var newHit))
            {
                var hexCenter = newHit.point;
                var vectorInt = Vector3Int.CeilToInt(newHit.point*100);
                var roundedVector = (Vector3)vectorInt / 100;

                Debug.Log("Try find tile " + roundedVector);
                Debug.DrawLine(transform.position, newHit.point, Color.red, 10f);
                if (_drawHexasphere.Territories.ContainsKey(Vector3Int.CeilToInt(newHit.point * 100) / 100))
                {
                    Debug.Log("Tile Exists " + Vector3Int.CeilToInt(newHit.point * 100) / 100);
                }
                
            }

        }
    }

    private void InstantiateObject(Vector3 from, Vector3 to)
    {

    }
}
