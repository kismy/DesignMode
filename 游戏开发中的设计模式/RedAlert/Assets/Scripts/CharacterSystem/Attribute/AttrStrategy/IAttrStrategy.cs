using System;
using System.Collections.Generic;
using System.Text;

public interface IAttrStrategy
{
    int GetEXtraHPValue(int lv);  //在基础最大血量之上，因等级提升而增加的额外血量
    int GetDmgDescValue(int lv); //受到攻击时，因等级提升而增加的防御
    int GetCritDmg(float critRate);  //攻击敌人时，因等级提升而增加的暴击率


}