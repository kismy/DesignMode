using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum WeaponType
{
Gun=0,
Rifle=1,
Rocket=2,
MAX=3
}

public abstract class IWeapon
{
    //protected int mAtk;
    //protected float mAttackRange;
    protected WeaponBaseAttr mBaseAttr;

    protected GameObject mGameObject;
    protected ICharacter mOwner;
    protected ParticleSystem mParticleSystem;
    protected LineRenderer mLineRenderer;
    protected Light mLight;
    protected AudioSource mAudioSource;

    protected float mEffectDisplayTime = 0;

    public float AttackRange { get { return mBaseAttr.attackRange; } }

    public int atk { get { return mBaseAttr.atk; } }

    public ICharacter owner { set { mOwner = value; } }



    //public IWeapon(int atk,float atkRange,GameObject gameobject)
    public IWeapon(WeaponBaseAttr baseAttr,GameObject gameobject)
    {
        //mAtk = atk;
        //mAttackRange = atkRange;
        mBaseAttr = baseAttr;
        

        mGameObject = gameobject;

        Transform effect = mGameObject.transform.Find("Effect");
        mParticleSystem = effect.GetComponent<ParticleSystem>();
        mLineRenderer = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mParticleSystem = effect.GetComponent<ParticleSystem>();
        mAudioSource=effect.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime <= 0)
            {
                DisableEffect();
            }

        }

    }

   public void Fire(Vector3 targetPosition)
    {
        //显示枪口特效
        PlayMuzzleEffect();


        //显示子弹轨迹特效
        PlayBulletEffect(targetPosition);


        //设置特效显示时间
        SetEffectDispayTime();


        //播放声音
        PlaySound();
    }

    protected abstract void SetEffectDispayTime();

    protected virtual void PlayMuzzleEffect()
    {
        mParticleSystem.Stop();
        mParticleSystem.Play();
        mLight.enabled = true;
    }

    protected abstract void PlayBulletEffect(Vector3 target);
    protected void DoPlayBulletEffect(float width, Vector3 target)
    {
        mLineRenderer.enabled = true;
        mLineRenderer.endWidth = width; mLineRenderer.startWidth = width;
        mLineRenderer.SetPosition(0, mGameObject.transform.position);
        mLineRenderer.SetPosition(1, target);
    }


    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName )
    {   
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        mAudioSource.clip = clip;
        mAudioSource.Play();
    }


    private void DisableEffect()
    {
        mLineRenderer.enabled = false;
        mLight.enabled = false;

    }

}