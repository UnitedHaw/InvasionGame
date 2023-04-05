using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ChunkRenderer : MonoBehaviour
{
    private List<Vector3> _verticies = new List<Vector3>();
    private List<int> _triangels = new List<int>();

    private float verticalDiametr = .87f;
    private float horizontalDiametr = .5f;

    private void Start()
    {
        Mesh chunkMesh = new Mesh();



        GenerateHex(0, 0);




        chunkMesh.vertices = _verticies.ToArray();
        chunkMesh.triangles = _triangels.ToArray();

        chunkMesh.RecalculateNormals();
        chunkMesh.RecalculateBounds();


        GetComponent<MeshFilter>().mesh = chunkMesh;
    }

    private void GenerateHex(float y, float z)
    {

        _verticies.Add(new Vector3(0, 0, 0));
        _verticies.Add(new Vector3(0, -verticalDiametr, -horizontalDiametr));
        _verticies.Add(new Vector3(0, -verticalDiametr, horizontalDiametr));
        _verticies.Add(new Vector3(0, 0, horizontalDiametr*2));
        _verticies.Add(new Vector3(0, verticalDiametr, horizontalDiametr));
        _verticies.Add(new Vector3(0, verticalDiametr, -horizontalDiametr));
        _verticies.Add(new Vector3(0, 0, -horizontalDiametr*2));

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



        Debug.DrawLine(_verticies[1], _verticies[5], Color.yellow, 100f);
        Debug.DrawLine(_verticies[2], _verticies[4], Color.yellow, 100f);
        Debug.DrawLine(_verticies[6], _verticies[3], Color.yellow, 100f);
        Debug.DrawLine((_verticies[2] + _verticies[1])/2, (_verticies[5] + _verticies[4]) / 2, Color.yellow, 100f);
    }

}
