using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 项目进行中我们怀疑LoadAsset是性能瓶颈，如果我们直接修改ResourcesAssetFactory，但最后发现LoadAsset并不导致性能消耗，又得把ResourcesAssetFactory改回来
/// 有没有一种办法，不用修改原有的类ResourcesAssetFactory，就可以直接测试LoadAsset是不是性能瓶颈产生的原因？
/// 1）思路一：ResourcesAssetProxyFactory持有ResourcesAssetFactory的引用，ResourcesAssetFactory作为ResourcesAssetProxyFactory的代理
/// 2）思路二：ResourcesAssetProxyFactory继承ResourcesAssetFactory，重写ResourcesAssetFactory
/// </summary>
public class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory mAssetProxyFactory = new ResourcesAssetFactory();
    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnenmys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();


    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioClips.ContainsKey(name))
        {
            return mAudioClips[name];  //有没有想过如果性能瓶颈不是resourcesLoad,而是实例化呢？对象池
        }
        else
        {
            AudioClip audio = mAssetProxyFactory.LoadAudioClip(name);
            mAudioClips.Add(name, audio);
            return audio;
        }
    }

    public GameObject LoadEffect(string name)
    {
        if (mEffects.ContainsKey(name))
        {
            return GameObject.Instantiate(mEffects[name]);  //有没有想过如果性能瓶颈不是resourcesLoad,而是实例化呢？对象池
        }
        else
        {
            GameObject asset = mAssetProxyFactory.LoadAsset(ResourcesAssetFactory.EffectPath + name) as GameObject;
            mEffects.Add(name, asset);
            return asset;
        }
    }

    public GameObject LoadEnemy(string name)
    {
        if (mEnenmys.ContainsKey(name))
        {
            return GameObject.Instantiate(mEnenmys[name]);  //有没有想过如果性能瓶颈不是resourcesLoad,而是实例化呢？对象池
        }
        else
        {
            GameObject asset = mAssetProxyFactory.LoadAsset(ResourcesAssetFactory.EnemyPath + name) as GameObject;
            mEnenmys.Add(name, asset);
            return asset;
        }
    }

    public GameObject LoadSoldier(string name)
    {
        if (mSoldiers.ContainsKey(name))
        {
            return GameObject.Instantiate(mSoldiers[name]);  //有没有想过如果性能瓶颈不是resourcesLoad,而是实例化呢？对象池
        }
        else
        {
          GameObject asset=  mAssetProxyFactory.LoadAsset(ResourcesAssetFactory.SoldierPath + name) as GameObject;
            mSoldiers.Add(name,asset);
            return asset;
        }

    
    }

    public Sprite LoadSprite(string name)
    {
        if (mSprites.ContainsKey(name))
        {
            return mSprites[name];  //有没有想过如果性能瓶颈不是resourcesLoad,而是实例化呢？对象池
        }
        else
        {
            Sprite sprite = mAssetProxyFactory.LoadSprite(name);
            mSprites.Add(name, sprite);
            return sprite;
        }
    }

    public GameObject LoadWeapon(string name)
    {
        if (mWeapons.ContainsKey(name))
        {
            return GameObject.Instantiate(mWeapons[name]);  //有没有想过如果性能瓶颈不是resourcesLoad,而是实例化呢？对象池
        }
        else
        {
            GameObject asset = mAssetProxyFactory.LoadAsset(ResourcesAssetFactory.WeaponPath + name) as GameObject;
            mWeapons.Add(name, asset);
            return asset;
        }
    }
}