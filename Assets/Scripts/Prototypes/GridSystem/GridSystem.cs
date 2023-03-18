using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private Grid _grid;

    void Start()
    {
        _grid = new Grid(6, 7, 5f, transform);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 0;

            _grid.SetValue(Camera.main.ScreenToWorldPoint(mousePosition), 1);
        }
    }
}
