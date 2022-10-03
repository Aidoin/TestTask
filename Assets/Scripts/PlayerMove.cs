using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    private Player _player;

    [SerializeField] private float _speed = 2;
    private List<Vector3> _points = new List<Vector3>();
    private bool _isActive = true;


    private void Awake() {
        _player = GetComponent<Player>();
    }

    private void Start() {
        _player.Subscribe(SetActive);
    }

    private void Update() {
        Move();
    }

    private void Move() {
        if (_isActive == false || _points.Count == 0) return;

        transform.position = Vector2.MoveTowards(transform.position, _points[0], _speed * Time.deltaTime);
        _line.SetPosition(0, transform.position);

        if (transform.position == _points[0]) {
            _points.RemoveAt(0);
            UpdateLine();
        }
    }

    public void AddMovePoint(Vector2 point) {
        if (_isActive == false) return;

        _points.Add(point);
        UpdateLine();
    }

    private void UpdateLine() {
        Vector3[] newMassive = new Vector3[_points.Count + 1];
        newMassive[0] = transform.position;
        for (int i = 0; i < _points.Count; i++) {
            newMassive[i + 1] = _points[i];
        }

        _line.positionCount = _points.Count + 1;
        _line.SetPositions(newMassive);
    }

    public void StopMove() {
        _points.Clear();
        _line.positionCount = 0;
    }
    
    private void SetActive(bool value) {
        _isActive = value;
        if (value == false) {
            StopMove();
        }
    }
}
