using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelect : MonoBehaviour
{
    float time = 0;
    public float Size = 5;
    private int state;

    public float upSizeTime = 0.5f;


    [SerializeField] // ����Ƽ �����Ϳ��� ���̵��� �迭�� ����ȭ
    private SkillData[] skillDatas;


    Image icon;


    private void Start()
    {
        icon = GetComponent<Image>();
    }

    public void SkillEquip(int state)
    {
        if(state == 1)//������ư ������ ����
        {
            CanEquip();
        }
        else//�Ұ���
        {
            return;
        }
    }

    public void CanEquip()//�������� ���¸� ǥ���ϱ� ���ؼ� ũ�� ��ȭ�ֱ�
    {
        if(time <= upSizeTime)
        {
            transform.localScale = Vector3.one * (1 + Size + time);
        }
        else if(time <= upSizeTime * 2)
        {
            transform.localScale = Vector3.one * (2 * Size * upSizeTime + 1 - time * Size);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        time += Time.deltaTime;
    }

    public void OnClick()
    {
        time = 0;
        state = 0;
        SkillEquip(state);
    }


    public void GetSkillid(int skillid)
    {
        // skillDatas �迭���� ��ġ�ϴ� Skillid�� ã��
        foreach(var skillData in skillDatas)
        {
            if(skillData.Skillid == skillid)
            {
                icon.sprite = skillData.SkillIcon;
                break;
            }
        }
    }

}