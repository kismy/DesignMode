using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 三步实现单例的双重锁定模式
/// </summary>
public class DM14Singleton : MonoBehaviour {
    private DM14Singleton() { }  //1)设置构造方法为私有，这样就不能在外部实例化类对象了

    private static readonly object myLock = new object(); //2）


    //3
    private static DM14Singleton instance;
    public static DM14Singleton Instance
    {
        get {

            // 这里面使用两个判断是否为null的原因是，我们不需要每次访问加锁，只有当对象不存在的时候加锁就可以了，因为上锁是费时操作
            if (instance == null)
            {
                // 锁定的作用就是为了保证当多线程同时执行这句代码的时候保证对象的唯一性
                // 锁定会让同时执行这段代码的线程排队执行
                // lock里面需要用一个已经存在的对象来判断，所以不能使用instance

                lock (myLock)
                {
                    // 这里还需要一个判断的原因是，如果多线程都通过了外层的判断进行排队
                    // 那将会实例化多个对象出来，所以这里还需要进行一次判断，保证线程的安全
                    if (instance == null)
                        instance = new DM14Singleton();
                }

            }
            return instance;
        }
    }
}
