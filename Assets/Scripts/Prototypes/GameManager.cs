using Code.Hexasphere;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _sphereTranform;
    [SerializeField] private Transform _pfPoint;
    private Hexasphere _hexasphere;
    private Camera _mainCamera;
    private List<Vector3> _hexes;

    private Touch touch;


    private void Start()
    {
        _hexes = new List<Vector3>();
        _mainCamera = Camera.main;
        _hexasphere = _sphereTranform.GetComponent<DrawHexasphere>().Hexasphere;
        _hexasphere.Tiles.ForEach(tile =>
        {
            _hexes.Add(tile.Center.Position);
        });
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

            Debug.DrawRay(ray.origin, hitPont - ray.origin, Color.yellow);

            Debug.DrawLine(center, hitInfo.normal * 10, Color.red, 10f);

            var outPoint = hitInfo.normal * 10;

            var newRay = new Ray(outPoint, -hitInfo.normal);

            if (Physics.Raycast(newRay, out var newHit))
            {
                var hexCenter = newHit.point;
                Instantiate(_pfPoint, hexCenter, Quaternion.identity);
            }

        }
    }
}
