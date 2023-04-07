using Assets.Scripts.Prototypes;
using Code.Hexasphere;
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

    [SerializeField] private HexasphereTemplateSO _hexasphereTemplateSO;

    private Mesh _mesh;
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;
    private Hexasphere _hexasphere;

    public Hexasphere Hexasphere => _hexasphere;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshCollider = GetComponent<MeshCollider>();

        if (_hexasphereTemplateSO.HexasphereMesh.Mesh == null)
        {
            DrawHexasphereMesh();
            _hexasphereTemplateSO.HexasphereMesh = new HexData(_mesh);
        }
        else
        {
            _meshFilter.sharedMesh = _hexasphereTemplateSO.HexasphereMesh.Mesh;
            _meshCollider.sharedMesh = _hexasphereTemplateSO.HexasphereMesh.Mesh;
        }

        Debug.Log(_hexasphere.ToJson());
    }

    private void Update()
    {
        //_lastUpdated += Time.deltaTime;
        //if (_lastUpdated < 1f) return;
        //if (Mathf.Abs(_oldRadius - radius) > 0.001f || _oldDivisions != divisions ||
        //    Mathf.Abs(_oldHexSize - hexSize) > 0.001f)
        //{
        //    DrawHexasphereMesh();
        //}
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
