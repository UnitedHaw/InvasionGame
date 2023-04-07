using Assets.Scripts.Prototypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mesh;

[CreateAssetMenu(fileName = "HexasphereTemplateSO")]
public class HexasphereTemplateSO : ScriptableObject
{
    public HexData HexasphereMesh;
}
