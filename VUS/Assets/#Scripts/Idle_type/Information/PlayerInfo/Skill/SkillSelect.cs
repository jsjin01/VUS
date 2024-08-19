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

        //��ų��ư ����
        UsingSkill[0].Skillbutton = GameObject.Find("Skill1").GetComponent<Button>();
        UsingSkill[1].Skillbutton = GameObject.Find("Skill2").GetComponent<Button>();
        UsingSkill[2].Skillbutton = GameObject.Find("Skill3").GetComponent<Button>();

    }

    public void StartEquipProcess(int skillid)
    {
        currentSkillId = skillid;
        equipCoroutine = StartCoroutine(CanEquip());  // ũ�� ��ȭ �ڷ�ƾ ����
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
            StopEquipCoroutine();  // ũ�� ��ȭ �ڷ�ƾ ����
            skillManager.SelectStop();
        }

        // SkillData �迭���� currentSkillId�� ��ġ�ϴ� �����͸� ã�Ƽ� �̹��� ����
        foreach (var skillData in skillDatas)
        {
            if (skillData.Skillid == currentSkillId)
            {
                icon.sprite = skillData.SkillIcon;  // ������ �̹��� ����
                
                UsingSkill[0].SKillid = currentSkillId;
                Debug.Log(UsingSkill[0].SKillid);
                
                break;
            }
        }

        transform.localScale = Vector3.one;  // ũ�� ������� ����
    }

    public void OnClick2()
    {
        if (equipCoroutine != null)
        {
            StopEquipCoroutine();  // ũ�� ��ȭ �ڷ�ƾ ����
            skillManager.SelectStop();
        }

        // SkillData �迭���� currentSkillId�� ��ġ�ϴ� �����͸� ã�Ƽ� �̹��� ����
        foreach (var skillData in skillDatas)
        {
            if (skillData.Skillid == currentSkillId)
            {
                icon.sprite = skillData.SkillIcon;  // ������ �̹��� ����
                UsingSkill[1].SKillid = currentSkillId;
                Debug.Log(UsingSkill[1].SKillid);
                break;
            }
        }

        transform.localScale = Vector3.one;  // ũ�� ������� ����
    }

    public void OnClick3()
    {
        if (equipCoroutine != null)
        {
            StopEquipCoroutine();  // ũ�� ��ȭ �ڷ�ƾ ����
            skillManager.SelectStop();
        }

        // SkillData �迭���� currentSkillId�� ��ġ�ϴ� �����͸� ã�Ƽ� �̹��� ����
        foreach (var skillData in skillDatas)
        {
            if (skillData.Skillid == currentSkillId)
            {
                icon.sprite = skillData.SkillIcon;  // ������ �̹��� ����
                UsingSkill[2].SKillid = currentSkillId;
                Debug.Log(UsingSkill[2].SKillid);
                break;
            }
        }

        transform.localScale = Vector3.one;  // ũ�� ������� ����
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

