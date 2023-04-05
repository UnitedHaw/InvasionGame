using Code.Hexasphere;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomHexasphere : MonoBehaviour
{
    public float radius = 100f;
    public int divisions = 10;
    public float hexSize = 1;

    [SerializeField] public Hexasphere _hexasphere;

    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();

        _hexasphere = new Hexasphere(radius, divisions, hexSize);

        Mesh mesh = new Mesh();

        _meshFilter.mesh = mesh;

        mesh.vertices = _hexasphere.MeshDetails.Vertices.ToArray();
        mesh.triangles = _hexasphere.MeshDetails.Triangles.ToArray();
        mesh.RecalculateNormals();

        _hexasphere.Tiles.ForEach(tile =>
        {
            var gameObject = new GameObject();
        });

        
    }
}
