//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PlayerInputObserver _playerInputObserver;

    private Rigidbody2D _rb;
    private Vector3 _moveDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInputObserver.onMoveInput += ChangeMoveDirection;
        _playerInputObserver.onPlayerStopped += StopPlayer;
    }

    private void OnDisable()
    {
        _playerInputObserver.onMoveInput -= ChangeMoveDirection;
        _playerInputObserver.onPlayerStopped -= StopPlayer;
    }

    private void Update()
    {
        //_rb.velocity = _moveDirection * _moveSpeed * Time.deltaTime;
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }


    private void ChangeMoveDirection(Vector3 targetDirection)
    {
        _moveDirection = targetDirection;
    }

    private void StopPlayer()
    {
        _moveDirection = Vector3.zero;
    }

}
