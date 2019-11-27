using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// captive 俘虏 ,当做Soldier来使用
/// </summary>
public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;
    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;
        ICharacterAttr attr = new SoldierAttr(enemy.attr.strategy,1,enemy.attr.baseAttr);
        this.attr = attr;
        this.gameobject = mEnemy.gameobject;
        this.weapon = mEnemy.weapon;
    }

    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }

    protected override void PlaySound()
    {
       
    }
}