//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _maxLiveTime;
    [SerializeField] private Color _colorAsPlayer; // if this bullet from player
    [SerializeField] private Color _colorAsEnemy;  // if this bullet from enemy

    private float _startTime;
    private float _damage;
    private IDamageTakable _sender;
    private GameObject _senderObject;
    protected Vector3 _moveDirection;

    public virtual void Init(float damage , GameObject sender)
    {
        _damage = damage;
        _moveDirection = sender.transform.up;
        _senderObject = sender;
        _sender = sender.GetComponent<IDamageTakable>();
    }

    private void Start()
    {
        _startTime = Time.time;
        OnStart();
    }

    private void Update()
    {
        if(Time.time - _startTime >= _maxLiveTime)
            CallDestroyAnimation();
        OnUpdate();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent<IDamageTakable>(out IDamageTakable target))
        {
            if(_sender == target) return;
            target.TakeDamage(_damage,_senderObject);
            CallDestroyAnimation();
        }
    }

    // для дочерних классов

    protected virtual void OnStart()
    {
        return;
    }

    protected virtual void OnUpdate() 
    {
        return;
    }

    protected abstract void Move();
    protected abstract void CallDestroyAnimation();

}
