using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc; //설명창 오브젝트
    SkillButton[] skillButtons; // 스킬버튼 스크립트 배열
    SkillSelect[] skillSelects; // 스킬선택 스크립트 배열
    public GameObject SkillButtonParant; //스킬버튼 초기화를 위한 부모오브젝트 위치
    public GameObject SkillSelectParant;
    int skillid;

    private void OnEnable()
    {
        // SkillButtonParant와 SkillSelectParant 오브젝트를 찾기
        SkillButtonParant = GameObject.Find("Skill/Skill_Inventory/Panel/Content");
        SkillSelectParant = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content");


        // 부모 오브젝트에서 모든 SkillButton과 SkillSelect 컴포넌트를 가져오기
        skillButtons = SkillButtonParant.GetComponentsInChildren<SkillButton>();
        skillSelects = SkillSelectParant.GetComponentsInChildren<SkillSelect>();
    }

    public void OnClick()
    {
        // 첫 번째 스킬 버튼을 선택했을때 
        if (skillButtons != null && skillButtons.Length > 0)
        {
            SkillButton button = skillButtons[0]; // 첫 번째 스킬 버튼을 선택
            skillid = button.SkillId; // 선택한 스킬 버튼의 SkillId를 가져옴

            // 스킬 장착 수행
            if (skillSelects != null && skillSelects.Length > 0)
            {
                SkillSelect select = skillSelects[0]; // 첫 번째 스킬 선택을 선택

                if (select != null)
                {
                    select.SkillEquip(1); // 스킬 장착
                    select.GetSkillid(skillid); // 스킬 ID 설정
                }
            }
        }

        // 설명창 비활성화
        Desc.SetActive(false);
    }
}


