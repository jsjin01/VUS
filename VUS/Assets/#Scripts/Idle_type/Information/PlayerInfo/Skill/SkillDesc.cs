using System.Collections;
using System.Collections.Generic;
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


        Price = Data.Price;
        State = 0;

        icon.sprite = Data.SkillIcon;
        
        Name = Data.SkillName;
        Desc = Data.SkillDesc;
    }


}
