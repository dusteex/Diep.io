//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class Orb : MonoBehaviour , IDamageTakable
{
    [SerializeField] private float _hp;
    [SerializeField] private int _lvl = 1; // level of orb 
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsAlive",true);
    }

    public void TakeDamage(float damage , GameObject damager)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            this.Destroy(damager); // NOT GAMEOBJECT.DESTROY !!!
        }
        else
        {
            _animator.SetTrigger("Damaged");
        }

    }

    private void Destroy(GameObject killer)
    {
        if(killer)
        {
            if(killer.TryGetComponent<PlayerLevelSystem>(out PlayerLevelSystem player))
            {
                player.ObtainXP(_lvl);
            }
        }

        _animator.SetBool("IsAlive",false);
        GameObject.Destroy(gameObject,1f);
    }
}
