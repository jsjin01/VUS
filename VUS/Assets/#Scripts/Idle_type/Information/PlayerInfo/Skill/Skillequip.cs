using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc;
    private SkillSelect[] skillSelects;
    public GameObject SkillSelectParant;
    private SkillDesc skilldesc;
    private int skillid;

    private void OnEnable()
    {
        SkillSelectParant = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content");
        skillSelects = SkillSelectParant.GetComponentsInChildren<SkillSelect>();  // 모든 SkillSelect 컴포넌트 가져오기
        skilldesc = GetComponentInParent<SkillDesc>();
    }

    public void OnClick()
    {
        skillid = skilldesc.skillid;  // SkillDesc에서 스킬 ID를 가져옴

        if (skillSelects != null)
        {
            foreach (SkillSelect select in skillSelects)
            {
                if (select != null)
                {
                    select.StartEquipProcess(skillid);  // 모든 SkillSelect에 대해 코루틴 시작
                }
            }
        }

        Desc.SetActive(false);
    }
}



