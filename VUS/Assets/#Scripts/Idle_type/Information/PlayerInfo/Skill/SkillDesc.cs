using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDesc : MonoBehaviour
{
    private Image icon;
    public int Price;
    public int State;
    public string Name;
    [TextArea]
    public string Desc;
    SkillButton button;
    int skillid;

    [SerializeField] // ����Ƽ �����Ϳ��� ���̵��� �迭�� ����ȭ
    private SkillData[] skillDatas;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void GetSkillid()
    {
        skillid = button.SkillId;
        // skillDatas �迭���� ��ġ�ϴ� Skillid�� ã��
        foreach (var skillData in skillDatas)
        {
            if(skillData.Skillid == skillid)
            {
                // ��ġ�ϴ� Skillid�� ã���� �ش� ��ų �����͸� ����Ͽ� UI�� ����
                Name = skillData.SkillName;
                Desc = skillData.SkillDesc;
                Price = skillData.Price;
                icon.sprite = skillData.SkillIcon;

                // ��ų Ÿ�Լ���
                State = skillData.skilltype == SkillData.Skilltype.Attack ? 1 : 0;

                // ������ ������ �Ϸ�Ǹ� ������ ����
                break;
            }
        }
    }
}