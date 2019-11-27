using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static  class UnityTool
{
    public static GameObject FindChild(GameObject parent, string childName)
    {

        Transform[] children = parent.GetComponentsInChildren<Transform>();

        Transform t = null;
        //int FindCount = 0;
        bool isFinded = false;
        foreach (Transform item in children)
        {
            if (item.name == childName)
            {
                if (isFinded)
                {
                    Debug.LogError("在" + parent.name + "下存在多个名为：" + childName + "的子物体。");
                }
                isFinded = true;
                //FindCount++;
                t = item;
            }
        }

        //if (FindCount >= 2)
        //{
        //    Debug.LogError("在" + parent.name + "下存在多个名为：" + childName + "的子物体。");        
        //}

        if (isFinded)
            return t.gameObject;
        else

        {
            Debug.LogError("UnityTool.FindChild():在游戏物体" + parent.name + "下查找不到" + childName);
            return null;
        }
      
    }

    public static void Attach(GameObject parent, GameObject child,bool toParentSpaceZero)
    {
        child.transform.parent = parent.transform;
        if (toParentSpaceZero)
        {
            child.transform.localPosition = Vector3.zero;
            child.transform.localRotation = Quaternion.identity;
        }
    }
}