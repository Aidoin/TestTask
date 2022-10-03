using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    private Camera _camera;


    private void Start() {
        _camera = Camera.main;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector2 cursorPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            if (_playerMove) {
                _playerMove.AddMovePoint(cursorPosition);
            }
        } else
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            _playerMove.StopMove();
        }
    }
}
