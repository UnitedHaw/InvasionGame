using Assets.Scripts.Prototypes.GridSystem;
using Code.Hexasphere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Control
    {
        private Camera _camera;
        private Button _cameraButton;

        public Control(Camera camera, Button cameraButton)
        {
            _camera = camera;
            _cameraButton = cameraButton;
            _cameraButton.onClick.AddListener(() => { StopOrActivateCamera(); });
        }

        public Territory GetTileTerritoryWithRay(Vector3 fromScreenPoint, HexasphereController hexasphereController)
        {
            Ray ray = _camera.ScreenPointToRay(fromScreenPoint);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                var outPoint = hitInfo.normal * hexasphereController.Hexasphere.Radius / 2;
                var newRay = new Ray(outPoint, -hitInfo.normal);

                if (Physics.Raycast(newRay, out var newHit))
                {
                    var vectorInt = Vector3Int.CeilToInt(newHit.point * Constants.FloatRounder);
                    var roundedVector = vectorInt;

                    Debug.Log("Try find tile " + roundedVector);
                    Debug.Log("Tile Coordinates" + Vector3Int.CeilToInt(newHit.normal * 5 * Constants.FloatRounder));
                    Debug.DrawLine(hexasphereController.transform.position, newHit.point, Color.red, 10f);
                    var tileCoordinate = Vector3Int.CeilToInt(newHit.point * Constants.FloatRounder);

                    if (hexasphereController.Territories.ContainsKey(tileCoordinate))
                    {
                        Debug.Log("Tile Exists " + tileCoordinate);
                        return hexasphereController.Territories[tileCoordinate];
                    }
                }
            }
            return new Territory(0);
        }

        public void StopOrActivateCamera()
        {
            if (_camera.gameObject.activeSelf)
            {
                _cameraButton.GetComponent<Image>().color = Color.red;
                _camera.gameObject.SetActive(false);
            }
            else
            {
                _cameraButton.GetComponent<Image>().color = Color.white;
                _camera.gameObject.SetActive(true);
            }
                
        }
    }
}
