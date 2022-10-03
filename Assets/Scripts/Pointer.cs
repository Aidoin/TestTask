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
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            Vector2 cursorPosition = _camera.ScreenToWorldPoint(touch.position);
            if (_playerMove) {
                _playerMove.AddMovePoint(cursorPosition);
            }
        }
    }
}
