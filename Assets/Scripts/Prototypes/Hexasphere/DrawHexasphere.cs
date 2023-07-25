using Assets.Scripts.Prototypes;
using Assets.Scripts.Prototypes.GridSystem;
using Assets.Scripts.Utils;
using Code.Hexasphere;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class DrawHexasphere : MonoBehaviour
{
    [Min(5f)]
    [SerializeField] private float radius = 10f;
    [Range(1, 15)]
    [SerializeField] private int divisions = 4;
    [Range(0.1f, 1f)]
    [SerializeField] private float hexSize = 1f;

    [SerializeField] private Transform pfPoint;
    private Mesh _mesh;
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;
    private Hexasphere _hexasphere;

    private List<Vector3> _tilesCenters;
    public List<Vector3> TilesCenters => _tilesCenters;
    public Hexasphere Hexasphere => _hexasphere;

    private Dictionary<Vector3, Territory> _territories;

    public Dictionary<Vector3, Territory> Territories => _territories;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshCollider = GetComponent<MeshCollider>();

        DrawHexasphereMesh();

        Debug.Log(_hexasphere.ToJson());

        _territories = new Dictionary<Vector3, Territory>();
        _tilesCenters = new List<Vector3>();

        int index = 0;
        _hexasphere.Tiles.ForEach(tile =>
        {
            var roundVector = Vector3Int.CeilToInt(tile.TileCenter*100);
            _territories[(Vector3)roundVector/100] = new Territory();
            _tilesCenters.Add(tile.TileCenter);
        });

    }

    private void DrawHexasphereMesh()
    {   
        _hexasphere = new Hexasphere(radius, divisions, hexSize);

        _mesh = new Mesh();

        _mesh.vertices = _hexasphere.MeshDetails.Vertices.ToArray();
        _mesh.triangles = _hexasphere.MeshDetails.Triangles.ToArray();
        _mesh.RecalculateNormals();
        _mesh.RecalculateBounds();

        _meshFilter.sharedMesh = _mesh;
        _meshCollider.sharedMesh = _mesh;
    }
}
