using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
 
public class WeaponGun : IWeapon
{
    public WeaponGun(WeaponBaseAttr baseAttr, GameObject gameobject) : base(baseAttr, gameobject)
    {
    }

    //public WeaponGun(int atk, float atkRange, GameObject gameobject) : base(atk, atkRange, gameobject)
    //{
    //}

    /*
public override void Fire(Vector3 targetPosition)
{

Debug.Log("显示特效 Gun");
Debug.Log("播放声音 Gun");

//显示枪口特效
//mParticleSystem.Stop();
//mParticleSystem.Play();
//mLight.enabled = true;
PlayMuzzleEffect();


//显示子弹轨迹特效
//mLineRenderer.enabled = true;
//mLineRenderer.endWidth = 0.05f;   mLineRenderer.startWidth = 0.05f;
//mLineRenderer.SetPosition(0,mGameObject.transform.position);
//mLineRenderer.SetPosition(1,targetPosition);
PlayBulletEffect(targetPosition);


//播放声音
//string clipName = "GunShot";
//AudioClip clip = null;   //todo
//mAudioSource.clip = clip;
//mAudioSource.Play();
PlaySound();



}
*/

    protected override void PlayBulletEffect(Vector3 target)
    {
        DoPlayBulletEffect(0.05f,target);
    }

    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }

    protected override void SetEffectDispayTime()
    {
        mEffectDisplayTime = 0.2f;
    }
}
