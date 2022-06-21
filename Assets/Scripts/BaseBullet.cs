//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : Bullet
{
    [Header("Base Bullet Speed")]
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _speedReducingByFrame;
    
    private Animator _animator;

    protected override void OnStart()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsAlive",true);
    }

    protected override void OnUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        _moveSpeed = GetReducedSpeed(_moveSpeed,_minSpeed,_speedReducingByFrame);
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private float GetReducedSpeed(float speed , float minSpeed , float reduceValue)
    {
        if(speed - reduceValue >= minSpeed)
            speed -= reduceValue;
        return speed;
    }

    protected override void CallDestroyAnimation()
    {
        _animator.SetBool("IsAlive",false);
    }

    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
