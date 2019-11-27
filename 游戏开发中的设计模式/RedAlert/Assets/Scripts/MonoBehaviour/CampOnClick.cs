using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CampOnClick:MonoBehaviour
{
    private ICamp mCamp;
    public ICamp camp { set { mCamp = value; } }

    private void OnMouseUpAsButton()
    {
        GameFacade.Instance.ShowCampInfo(mCamp);
    }
}