using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc;
    SkillButton button;
    SkillSelect select;
    int skillid;

    private void OnEnable()
    {
        button = transform.parent.parent.GetChild(0).GetChild(2).GetComponent<SkillButton>();
        select = transform.parent.parent.GetChild(1).GetChild(3).GetComponent<SkillSelect>();
    }


    public void OnClick()
    {        
        Desc.SetActive(false);
        skillid = button.SkillId;

        select.SkillEquip(1);
        select.GetSkillid(skillid);
    }
}