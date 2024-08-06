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


    [SerializeField] // 유니티 에디터에서 보이도록 배열을 직렬화
    private SkillData[] skillDatas;


    Image icon;


    private void Start()
    {
        icon = GetComponent<Image>();
    }

    public void SkillEquip(int state)
    {
        if(state == 1)//장착버튼 누르기 가능
        {
            CanEquip();
        }
        else//불가능
        {
            return;
        }
    }

    public void CanEquip()//장착가능 상태를 표시하기 위해서 크기 변화주기
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
        // skillDatas 배열에서 일치하는 Skillid를 찾기
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