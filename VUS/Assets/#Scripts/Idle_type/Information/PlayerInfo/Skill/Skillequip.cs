using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc; //����â ������Ʈ
    SkillButton button; //��ų��ư ��ũ��Ʈ
    SkillSelect select; //��ų���� ��ũ��Ʈ
    public GameObject SkillButtonParant; //��ų��ư �ʱ�ȭ�� ���� �θ������Ʈ ��ġ
    public GameObject SkillSelectParant;
    int skillid;

    private void OnEnable()
    {
        SkillButtonParant = GameObject.Find("Skill/Skill_Inventory/Panel/Content");
        if (SkillButtonParant == null)
        {
            Debug.LogWarning("SkillButtonParant ������Ʈ�� ã�� �� �����ϴ�. ��θ� Ȯ���ϼ���.");
            return; // ������Ʈ�� ã�� ���� ��� ���� �ڵ带 �������� ����
        }

        SkillButton[] skillButtons = SkillButtonParant.GetComponentsInChildren<SkillButton>();

        SkillSelectParant = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content");
        if (SkillSelectParant == null)
        {
            Debug.LogWarning("SkillSelectParant ������Ʈ�� ã�� �� �����ϴ�. ��θ� Ȯ���ϼ���.");
            return; // ������Ʈ�� ã�� ���� ��� ���� �ڵ带 �������� ����
        }

        SkillSelect[] skillSelects = SkillSelectParant.GetComponentsInChildren<SkillSelect>();

        if (skillButtons != null && skillButtons.Length > 0)
        {
            button = skillButtons[0]; // ��: ù ��° ��ų ��ư�� ����
        }

        if (skillSelects != null && skillSelects.Length > 0)
        {
            select = skillSelects[0]; // ��: ù ��° ��ų ������ ����
        }
    }

    public void OnClick()
    {
        if (button == null || select == null)
        {
            Debug.LogWarning("button �Ǵ� select�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
            return;
        }

        Desc.SetActive(false);
        skillid = button.SkillId;

        select.SkillEquip(1);
        select.GetSkillid(skillid);
    }
}
