//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerLifeSystem _playerLifeSystem;
    [SerializeField] private PlayerLevelSystem _playerLevelSystem;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _lvlTextField;    
    [SerializeField] private TextMeshProUGUI _hpTextField;    
    [SerializeField] private TextMeshProUGUI _xpTextField;    


    private void OnEnable()
    {
        _playerLifeSystem.onHPChanged += ChangeHP;
        _playerLevelSystem.onXPChanged += ChangeXP;
        _playerLevelSystem.onLevelUp   += ChangeLevel;

    }

    private void OnDisable()
    {
        _playerLifeSystem.onHPChanged -= ChangeHP;
    }

    public void ChangeHP(float hp)
    {
        _hpTextField.text = "HP : " + hp.ToString();
    }

    public void ChangeXP(float xp)
    {
        _xpTextField.text = "XP : " + xp.ToString();
    }

    public void ChangeLevel(int lvl)
    {
        ChangeXP(0);
        _lvlTextField.text = "LVL : " + lvl.ToString();
    }
}
