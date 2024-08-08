using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc; //설명창 오브젝트
    SkillButton button; //스킬버튼 스크립트
    SkillSelect select; //스킬선택 스크립트
    public GameObject SkillButtonParant; //스킬버튼 초기화를 위한 부모오브젝트 위치
    public GameObject SkillSelectParant;
    int skillid;

    private void OnEnable()
    {
        SkillButtonParant = GameObject.Find("Skill/Skill_Inventory/Panel/Content");
        if (SkillButtonParant == null)
        {
            Debug.LogWarning("SkillButtonParant 오브젝트를 찾을 수 없습니다. 경로를 확인하세요.");
            return; // 오브젝트를 찾지 못한 경우 이후 코드를 실행하지 않음
        }

        SkillButton[] skillButtons = SkillButtonParant.GetComponentsInChildren<SkillButton>();

        SkillSelectParant = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content");
        if (SkillSelectParant == null)
        {
            Debug.LogWarning("SkillSelectParant 오브젝트를 찾을 수 없습니다. 경로를 확인하세요.");
            return; // 오브젝트를 찾지 못한 경우 이후 코드를 실행하지 않음
        }

        SkillSelect[] skillSelects = SkillSelectParant.GetComponentsInChildren<SkillSelect>();

        if (skillButtons != null && skillButtons.Length > 0)
        {
            button = skillButtons[0]; // 예: 첫 번째 스킬 버튼을 선택
        }

        if (skillSelects != null && skillSelects.Length > 0)
        {
            select = skillSelects[0]; // 예: 첫 번째 스킬 선택을 선택
        }
    }

    public void OnClick()
    {
        if (button == null || select == null)
        {
            Debug.LogWarning("button 또는 select가 초기화되지 않았습니다.");
            return;
        }

        Desc.SetActive(false);
        skillid = button.SkillId;

        select.SkillEquip(1);
        select.GetSkillid(skillid);
    }
}
