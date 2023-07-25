using Assets.Scripts.GridSystem;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private float _cellSize;
    private float offset = .5f;

    private SquareCell[,] _gridArray;

    public Grid(int width, int height, float cellSize, Transform parentTransform)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _gridArray = new SquareCell[_width, _height];

        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                _gridArray[x,y] = new SquareCell(position: GetWorldPosition(x, y), parent: parentTransform);
                DrawBorder(x, y);
            }
        }
        Debug.DrawLine(GetWorldPosition(0 - offset, height - offset), GetWorldPosition(width - offset, height - offset), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width - offset, 0 - offset), GetWorldPosition(width - offset, height - offset), Color.white, 100f);
    }

    private void DrawBorder(int x, int y)
    {    
        Debug.DrawLine(GetWorldPosition(x - offset, y - offset), GetWorldPosition(x + offset, y - offset), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(x - offset, y - offset), GetWorldPosition(x - offset, y + offset), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(float x, float y)
    {
        return new Vector3(x, y) * _cellSize;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        y = Mathf.FloorToInt(worldPosition.y / _cellSize);
    }

     public void SetValue(int x, int y, int value)
    {
        if(x >= 0 && y >= 0 && x < _width && y < _height)
            _gridArray[x, y].SetValue(value);
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;

        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }
}
