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

    [SerializeField]private List<Vector3> _pointsList;


    private void Start()
    {
        _hexes = new List<Vector3>();
        _mainCamera = Camera.main;
        _hexasphere = _sphereTranform.GetComponent<DrawHexasphere>().Hexasphere;
        _pointsList = new List<Vector3>();
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

                if(_pointsList.Count < 2)
                {
                    _pointsList.Add(Instantiate(_pfPoint, hexCenter, Quaternion.identity).position);

                    if(_pointsList.Count == 2)
                        Debug.DrawLine(_pointsList[0], _pointsList[1], Color.red, 2f);
                }
                else
                {              
                    _pointsList.Clear();
                    _pointsList.Add(Instantiate(_pfPoint, hexCenter, Quaternion.identity).position);
                }
                
            }

        }
    }

    private void InstantiateObject(Vector3 from, Vector3 to)
    {

    }
}
