//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLevelSystem : MonoBehaviour
{
    public const float RECEIVED_XP_MULTIPLYER = 50; // this * lvl = how much xp player will receive 
    public const float GIVED_XP_MULTIPLYER = 25; // this * lvl = how much xp player will give 

    public event Action<float> onXPChanged; // bring amount of xp
    public event Action<int> onLevelUp; // bring lvl

    [SerializeField] private PlayerLifeSystem _playerLifeSystem;

    private int _lvl = 1;
    private float _xp;

    private void Start()
    {
        //Set up
        onXPChanged?.Invoke(_xp);
        onLevelUp?.Invoke(_lvl);
    }

    public void ObtainXP(int targetLevel)
    {
        _xp += targetLevel * GIVED_XP_MULTIPLYER;
        onXPChanged?.Invoke(_xp);
        if(_xp > _lvl*RECEIVED_XP_MULTIPLYER)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        _lvl ++;
        _xp = 0;
        onLevelUp?.Invoke(_lvl);
    }

    private void TryGiveXP(GameObject killerObj)
    {   
        if(killerObj.TryGetComponent<PlayerLevelSystem>(out PlayerLevelSystem killerPlayer))
        {
            killerPlayer.ObtainXP(_lvl);
        }
    }
}
