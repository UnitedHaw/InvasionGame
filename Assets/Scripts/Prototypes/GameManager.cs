using Assets.Scripts.Game;
using Assets.Scripts.Prototypes.GridSystem;
using Code.Hexasphere;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _sphereTranform;
    [SerializeField] private Transform _pfPoint;
    [SerializeField] private HexasphereController _hexasphereController;
    [SerializeField] private Button _cameraButton;
    private Camera _mainCamera;
    private GameInput _gameInput;
    private Control _control;

    private Func<Vector3, Territory> SetFirstTileWithTouch;
    private Func<Vector3, Territory> SetSecondTileWithTouch;
    private Touch _touch;

    private Territory _firstFocusedTerritory;
    private Territory _secondFocusedTerritory;

    [SerializeField] private int firstTileId;
    [SerializeField] private int secondTileId;

    private void Start()
    {
        _mainCamera = Camera.main;
        _gameInput = new GameInput();
        _control = new Control(_mainCamera, _cameraButton);
        _firstFocusedTerritory = new Territory(0);
        _secondFocusedTerritory = new Territory(0);

        SetFirstTileWithTouch = GetFirstTile;
        SetSecondTileWithTouch = GetSecondTile;
    }

    private void Update()
    {
        _gameInput.TouchInput(SetFirstTileWithTouch);
        _gameInput.TouchInput(endedEvent: SetSecondTileWithTouch);
    }

    private Territory GetFirstTile(Vector3 screenPoint)
    {
        _firstFocusedTerritory = _control.GetTileTerritoryWithRay(screenPoint, _hexasphereController);
        firstTileId = _firstFocusedTerritory.Id;
        return _firstFocusedTerritory;
    }

    private Territory GetSecondTile(Vector3 screenPoint)
    {
        _secondFocusedTerritory = _control.GetTileTerritoryWithRay(screenPoint, _hexasphereController);
        secondTileId = _secondFocusedTerritory.Id;
        return _secondFocusedTerritory;
    }

    private void InstantiateObject(Vector3 from, Vector3 to)
    {

    }
}
