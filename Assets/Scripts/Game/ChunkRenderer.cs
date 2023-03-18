using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ChunkRenderer : MonoBehaviour
{
    private List<Vector3> _verticies = new List<Vector3>();
    private List<int> _triangels = new List<int>();

    private void Start()
    {
        Mesh chunkMesh = new Mesh();

        

        SetHex();

        chunkMesh.vertices = _verticies.ToArray();
        chunkMesh.triangles = _triangels.ToArray();

        chunkMesh.RecalculateNormals();
        chunkMesh.RecalculateBounds();


        GetComponent<MeshFilter>().mesh = chunkMesh;
    }

    private void SetHex()
    {
        var diametr = 0.87f;
        _verticies.Add(new Vector3(0, 0, 0));
        _verticies.Add(new Vector3(0, -diametr, -.5f));
        _verticies.Add(new Vector3(0, -diametr, .5f));
        _verticies.Add(new Vector3(0, 0, 1));
        _verticies.Add(new Vector3(0, diametr, .5f));
        _verticies.Add(new Vector3(0, diametr, -.5f));
        _verticies.Add(new Vector3(0, 0, -1));

        _triangels.Add(2);
        _triangels.Add(1);
        _triangels.Add(0);

        _triangels.Add(3);
        _triangels.Add(2);
        _triangels.Add(0);

        _triangels.Add(4);
        _triangels.Add(3);
        _triangels.Add(0);

        _triangels.Add(5);
        _triangels.Add(4);
        _triangels.Add(0);

        _triangels.Add(6);
        _triangels.Add(5);
        _triangels.Add(0);

        _triangels.Add(1);
        _triangels.Add(6);
        _triangels.Add(0);
    }
}
