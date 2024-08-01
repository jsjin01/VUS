using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SKillDesc : MonoBehaviour
{
    public SkillData Data;
    Image icon;
    public int Price;
    public int State;
    public string Name;
    public string Desc;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void GetSkillid(int skillid)
    {
        switch (skillid)
        {
            case 0:

                break;
        }
    }

}
