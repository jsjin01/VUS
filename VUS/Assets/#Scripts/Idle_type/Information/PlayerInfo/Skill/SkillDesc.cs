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

    [SerializeField] // 유니티 에디터에서 보이도록 배열을 직렬화
    private SkillData[] skillDatas;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void GetSkillid()
    {
        skillid = button.SkillId;
        // skillDatas 배열에서 일치하는 Skillid를 찾기
        foreach (var skillData in skillDatas)
        {
            if(skillData.Skillid == skillid)
            {
                // 일치하는 Skillid를 찾으면 해당 스킬 데이터를 사용하여 UI를 설정
                Name = skillData.SkillName;
                Desc = skillData.SkillDesc;
                Price = skillData.Price;
                icon.sprite = skillData.SkillIcon;

                // 스킬 타입설정
                State = skillData.skilltype == SkillData.Skilltype.Attack ? 1 : 0;

                // 데이터 설정이 완료되면 루프를 종료
                break;
            }
        }
    }
}