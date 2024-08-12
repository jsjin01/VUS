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
        skillSelects = SkillSelectParant.GetComponentsInChildren<SkillSelect>();  // ��� SkillSelect ������Ʈ ��������
        skilldesc = GetComponentInParent<SkillDesc>();
    }

    public void OnClick()
    {
        skillid = skilldesc.skillid;  // SkillDesc���� ��ų ID�� ������

        if (skillSelects != null)
        {
            foreach (SkillSelect select in skillSelects)
            {
                if (select != null)
                {
                    select.StartEquipProcess(skillid);  // ��� SkillSelect�� ���� �ڷ�ƾ ����
                }
            }
        }

        Desc.SetActive(false);
    }
}



