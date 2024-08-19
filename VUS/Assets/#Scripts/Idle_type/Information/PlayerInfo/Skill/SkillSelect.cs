using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelect : MonoBehaviour
{
    public float Size = 1;
    public float upSizeTime = 0.3f;

    


    [SerializeField]
    private SkillData[] skillDatas;


    private Image icon;
    private int currentSkillId;
    private Coroutine equipCoroutine;
    SkillManager skillManager;

    public struct UsingSkills
    {
        public Button Skillbutton;
        public int SKillid;
    }

    public UsingSkills[] UsingSkill = new UsingSkills[3];

    private void OnEnable()
    {
        icon = GetComponent<Image>();
        GameObject Target = GameObject.Find("Skill/SkillManager");
        skillManager = Target.GetComponent<SkillManager>();

        //스킬버튼 지정
        UsingSkill[0].Skillbutton = GameObject.Find("Skill1").GetComponent<Button>();
        UsingSkill[1].Skillbutton = GameObject.Find("Skill2").GetComponent<Button>();
        UsingSkill[2].Skillbutton = GameObject.Find("Skill3").GetComponent<Button>();

    }

    public void StartEquipProcess(int skillid)
    {
        currentSkillId = skillid;
        equipCoroutine = StartCoroutine(CanEquip());  // 크기 변화 코루틴 시작
    }

    private IEnumerator CanEquip()
    {
        float time = 0;
        while (true)
        {
            if (time <= upSizeTime)
            {
                transform.localScale = Vector3.one * (time * 1.2f);
            }
            else if (time <= upSizeTime * 2)
            {
                transform.localScale = Vector3.one * (time * 1.5f);
            }
            else
            {
                transform.localScale = Vector3.one;
                time = 0;
            }
            time += Time.deltaTime;
            yield return null;
        }
    }

    public void OnClick1()
    {
        if (equipCoroutine != null)
        {
            StopEquipCoroutine();  // 크기 변화 코루틴 중지
            skillManager.SelectStop();
        }

        // SkillData 배열에서 currentSkillId와 일치하는 데이터를 찾아서 이미지 변경
        foreach (var skillData in skillDatas)
        {
            if (skillData.Skillid == currentSkillId)
            {
                icon.sprite = skillData.SkillIcon;  // 아이콘 이미지 변경
                
                UsingSkill[0].SKillid = currentSkillId;
                Debug.Log(UsingSkill[0].SKillid);
                
                break;
            }
        }

        transform.localScale = Vector3.one;  // 크기 원래대로 설정
    }

    public void OnClick2()
    {
        if (equipCoroutine != null)
        {
            StopEquipCoroutine();  // 크기 변화 코루틴 중지
            skillManager.SelectStop();
        }

        // SkillData 배열에서 currentSkillId와 일치하는 데이터를 찾아서 이미지 변경
        foreach (var skillData in skillDatas)
        {
            if (skillData.Skillid == currentSkillId)
            {
                icon.sprite = skillData.SkillIcon;  // 아이콘 이미지 변경
                UsingSkill[1].SKillid = currentSkillId;
                Debug.Log(UsingSkill[1].SKillid);
                break;
            }
        }

        transform.localScale = Vector3.one;  // 크기 원래대로 설정
    }

    public void OnClick3()
    {
        if (equipCoroutine != null)
        {
            StopEquipCoroutine();  // 크기 변화 코루틴 중지
            skillManager.SelectStop();
        }

        // SkillData 배열에서 currentSkillId와 일치하는 데이터를 찾아서 이미지 변경
        foreach (var skillData in skillDatas)
        {
            if (skillData.Skillid == currentSkillId)
            {
                icon.sprite = skillData.SkillIcon;  // 아이콘 이미지 변경
                UsingSkill[2].SKillid = currentSkillId;
                Debug.Log(UsingSkill[2].SKillid);
                break;
            }
        }

        transform.localScale = Vector3.one;  // 크기 원래대로 설정
    }

    public void StopEquipCoroutine()
    {
        StopCoroutine(equipCoroutine);
        transform.localScale = Vector3.one;
    }

    public bool IsCoroutineRunning()
    {
        return equipCoroutine != null;
    }

    public void AddSkill()
    {
        
    }
    
}

