using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UITool
{
    public static GameObject GetCanvas(string name="Canvas")
    {
      return  GameObject.Find(name);
    }
    public static T FindChild<T>(GameObject parent, string childName)
    {
      GameObject uiGO=  UnityTool.FindChild(parent, childName);

        if (uiGO == null)
        {
            Debug.LogError("UITool.FindChild<T>()  : 在游戏物体" + parent.name+"下查找不到"+childName);
            return default(T);
        }
        return uiGO.GetComponent<T>();
    }

}