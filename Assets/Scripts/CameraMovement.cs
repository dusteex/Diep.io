//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _lerpSpeed;

    private void LateUpdate()
    {
        Vector3 newPosition = _player.position;
        newPosition.z = -10;
        //transform.position = newPosition;
        transform.position = Vector3.Lerp(transform.position,newPosition,Time.deltaTime * _lerpSpeed);

    }
}
