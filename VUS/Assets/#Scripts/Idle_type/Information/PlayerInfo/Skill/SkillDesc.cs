using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDesc : MonoBehaviour
{
    [SerializeField] Image icon;
    public int Price;
    public int State;
    public string Name;
    [TextArea]
    Text Desc;
    //SkillButton button;
    int skillid;

    [SerializeField] // ����Ƽ �����Ϳ��� ���̵��� �迭�� ����ȭ
    private SkillData[] skillDatas;

    private void OnEnable()
    {
        Desc = GetComponentInChildren<Text>();
    }

    public void GetSkillid(GameObject gameObject)
    {
        skillid = gameObject.GetComponent<SkillButton>().SkillId;
        // skillDatas �迭���� ��ġ�ϴ� Skillid�� ã��
        foreach (var skillData in skillDatas)
        {
            if(skillData.Skillid == skillid)
            {
                // ��ġ�ϴ� Skillid�� ã���� �ش� ��ų �����͸� ����Ͽ� UI�� ����
                Name = skillData.SkillName;
                Desc.text = skillData.SkillDesc;
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