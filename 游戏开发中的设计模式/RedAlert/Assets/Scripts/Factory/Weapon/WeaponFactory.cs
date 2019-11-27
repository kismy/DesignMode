using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;


        //string assetName = "";
        //switch (weaponType)
        //{
        //    case WeaponType.Gun:
        //        assetName = "WeaponGun";
        //        break;

        //    case WeaponType.Rifle:
        //        assetName = "WeaponRifle";
        //        break;

        //    case WeaponType.Rocket:
        //        assetName = "WeaponRocket";
        //        break;
        //}
        WeaponBaseAttr baseAttr = FactoryManager.attrFactory.GetWeaponBaseAttr(weaponType);



        //GameObject weaponGO = FactoryManager.assetFactory.LoadWeapon(assetName);
        GameObject weaponGO = FactoryManager.assetFactory.LoadWeapon(baseAttr.assetName);



        switch (weaponType)
        {
            case WeaponType.Gun:
                //weapon = new WeaponGun(20,5,weaponGO);
                weapon = new WeaponGun(FactoryManager.attrFactory.GetWeaponBaseAttr(WeaponType.Gun),weaponGO);
                break;

            case WeaponType.Rifle:
                //weapon = new WeaponRifle(30, 7, weaponGO);
                weapon = new WeaponRifle(FactoryManager.attrFactory.GetWeaponBaseAttr(WeaponType.Rifle), weaponGO);
                break;

            case WeaponType.Rocket:
                //weapon = new WeaponRocket(40, 8, weaponGO);
                weapon = new WeaponRocket(FactoryManager.attrFactory.GetWeaponBaseAttr(WeaponType.Rocket), weaponGO);
                break;
        }
        return weapon;
    }
}