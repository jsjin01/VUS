using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    SkillSelect select;


    private void Start()
    {
        GameObject target1 = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content/Skill");
        select = target1.GetComponent<SkillSelect>();
    }

    void SkillUse(int skillButtonIndex)
    {
        int skillId = select.UsingSkill[skillButtonIndex].SKillid;

        switch(skillId)
        {
            case 0:
                Skill0();
                break;

            case 1:
                Skill1();
                break;
        }
    }



    public void Skill0()
    {

    }

    public void Skill1()
    {

    }
}
