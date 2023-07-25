using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private Grid _grid;

    private Vector3 gridPositionOffest;

    void Start()
    {
        _grid = new Grid(6, 7, 5f, transform);
        gridPositionOffest = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            var screenPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            screenPosition -= gridPositionOffest;
            screenPosition.z = 0;

            _grid.SetValue(screenPosition, 1);
            
        }
    }
}
