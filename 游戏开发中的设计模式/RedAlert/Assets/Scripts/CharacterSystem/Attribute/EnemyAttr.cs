﻿using System;
using System.Collections.Generic;
using System.Text;

public class EnemyAttr : ICharacterAttr
{
    //public EnemyAttr(IAttrStrategy strategy, int lv, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName) : base(strategy, lv,name,maxHP,moveSpeed,iconSprite,prefabName)
    //{
    //}
    public EnemyAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr) : base(strategy, lv, baseAttr)
    {
    }
}