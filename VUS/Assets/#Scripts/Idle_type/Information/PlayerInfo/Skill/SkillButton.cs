using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public SkillData Data;
    public GameObject Desc;
    public SKillDesc skilldesc;
    Image icon;

    public int SkillId;

    private void Awake()
    {       
       icon = GetComponent<Image>();
       icon.sprite = Data.SkillIcon;
        SkillId = Data.Skillid;
        Desc.SetActive(false);
    }

    public void OnCLick()
    {
        Desc.SetActive(true);
        skilldesc.GetSkillid(SkillId);
    }
}
