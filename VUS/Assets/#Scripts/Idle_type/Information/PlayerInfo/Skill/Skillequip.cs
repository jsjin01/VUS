using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc; //����â ������Ʈ
    SkillButton[] skillButtons; // ��ų��ư ��ũ��Ʈ �迭
    SkillSelect[] skillSelects; // ��ų���� ��ũ��Ʈ �迭
    public GameObject SkillButtonParant; //��ų��ư �ʱ�ȭ�� ���� �θ������Ʈ ��ġ
    public GameObject SkillSelectParant;
    int skillid;

    private void OnEnable()
    {
        // SkillButtonParant�� SkillSelectParant ������Ʈ�� ã��
        SkillButtonParant = GameObject.Find("Skill/Skill_Inventory/Panel/Content");
        SkillSelectParant = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content");


        // �θ� ������Ʈ���� ��� SkillButton�� SkillSelect ������Ʈ�� ��������
        skillButtons = SkillButtonParant.GetComponentsInChildren<SkillButton>();
        skillSelects = SkillSelectParant.GetComponentsInChildren<SkillSelect>();
    }

    public void OnClick()
    {
        // ù ��° ��ų ��ư�� ���������� 
        if (skillButtons != null && skillButtons.Length > 0)
        {
            SkillButton button = skillButtons[0]; // ù ��° ��ų ��ư�� ����
            skillid = button.SkillId; // ������ ��ų ��ư�� SkillId�� ������

            // ��ų ���� ����
            if (skillSelects != null && skillSelects.Length > 0)
            {
                SkillSelect select = skillSelects[0]; // ù ��° ��ų ������ ����

                if (select != null)
                {
                    select.SkillEquip(1); // ��ų ����
                    select.GetSkillid(skillid); // ��ų ID ����
                }
            }
        }

        // ����â ��Ȱ��ȭ
        Desc.SetActive(false);
    }
}


