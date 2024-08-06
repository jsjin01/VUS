using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc;
    SkillButton button;
    SkillSelect select;
    int skillid;

    public void OnClick()
    {        
        Desc.SetActive(false);
        skillid = button.SkillId;

        select.SkillEquip(1);
        select.GetSkillid(skillid);
    }
}