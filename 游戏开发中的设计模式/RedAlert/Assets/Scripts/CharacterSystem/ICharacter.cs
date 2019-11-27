using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavMeshAgent;
    protected AudioSource mAudioSource;
    protected Animation mAnim;
    protected IWeapon mWeapon;
    protected bool mIsKilled = false;
    protected bool mCanDestroy = false;
    private float mDestroyTimer = 2;
    public bool canDestroy { get { return mCanDestroy; } }
    //public WeaponGun gun;
    //public WeaponRifle rifle;
    // public WeaponRocket rocket;
    public IWeapon weapon {
        get { return mWeapon; }
        set
        {
            mWeapon = value;
            mWeapon.owner = this;
            Transform weaponPoint = UnityTool.FindChild(mGameObject,"weapon-point").transform;
            UnityTool.Attach(mGameObject,weaponPoint.gameObject,true);

        }
    }

    public Vector3 position
    {
        get
        {
            if (mGameObject != null) return mGameObject.transform.position;
            else
            {
                Debug.LogError("mGameObject不能为null");
                return Vector3.zero;
            }
        }
    }

    public float atkRange { get { return mWeapon.AttackRange; } }

    public ICharacterAttr attr { get { return mAttr; } set { mAttr = value; } }

    public bool IsKilled { get { return mIsKilled; } }

    public GameObject gameobject
    {
        get{ return mGameObject; }
        set
        {
            mGameObject = value;
            mNavMeshAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudioSource = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();

        }
    }

    public void Update()
    {
        if (mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if (mDestroyTimer <= 0)
            {
                mCanDestroy = true;
            }
            return;
        } 
        mWeapon.Update();
    }

    public abstract void UpdateFSMAI(List<ICharacter> targrts);

    public abstract void RunVisitor(ICharacterVisitor visitor);

    public void Attack(ICharacter target) {
        //if (gun != null)
        //{
        //    gun.Fire(target);
        //}
        //else if (rifle != null)
        //{
        //    rifle.Fire(target);
        //}
        //else if(rocket!=null) {
        //    rocket.Fire(target);
        //}

        mWeapon.Fire(target.position);
        mGameObject.transform.LookAt(target.position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.atk+mAttr.critValue);

    }

    public virtual void UnderAttack(int damage) //被攻击的Character掉血
    {
        mAttr.TakeDamage(damage);
    }

    public virtual void Killed()
    {
        mIsKilled = true;
        mNavMeshAgent.isStopped=true;
    }

    public void Release()
    {
        //GameObject.Destroy(mGameObject, 2);
        GameObject.Destroy(mGameObject);
    }

    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }

    public void MoveTo(Vector3 target)
    {
        mNavMeshAgent.SetDestination(target);
        PlayAnim("move");

    }

    protected void DoPlayEffect(string effectName)
    {
        //加载特效
        GameObject effectGO = FactoryManager.assetFactory.LoadEffect(effectName);
        effectGO.transform.position = position;

        //销毁特效 在特效身上自我销毁最好
        //GameObject.Destroy(effectGO,3f);
    }

    protected void DoPlaySound(string soundName)
    {
        //加载声音
        UnityEngine.AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(soundName);
        mAudioSource.clip = clip;
        mAudioSource.Play();


    }


}
