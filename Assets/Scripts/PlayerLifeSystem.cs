//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLifeSystem : MonoBehaviour , IDamageTakable
{
    [SerializeField] private float _hp;

    public event Action<float> onHPChanged; // bring amount of hp
    public event Action<GameObject> onPlayerDied; // bring killer object;

    private void Start()
    {
        onHPChanged?.Invoke(_hp);
    }

    public void TakeDamage(float damage , GameObject damager)
    {
        _hp-=damage;
        onHPChanged?.Invoke(_hp);
        if(_hp <= 0)
        {
            Death(damager);
        }
    }

    private void Death(GameObject killer)
    {
        onPlayerDied?.Invoke(killer);
        Destroy(gameObject);
    }


}
