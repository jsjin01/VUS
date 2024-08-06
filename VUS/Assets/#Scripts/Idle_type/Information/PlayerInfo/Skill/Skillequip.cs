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
        skillid = button.SkillId;
        Desc.SetActive(false);
        select.SkillEquip(1);
        select.GetSkillid(skillid);

    }
}