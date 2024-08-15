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

    private void OnEnable()
    {
        icon = GetComponent<Image>();
        GameObject Target = GameObject.Find("Skill/SkillManager");
        skillManager = Target.GetComponent<SkillManager>();
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
                transform.localScale = Vector3.one * ( time * 1.2f);
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

    public void OnClick()
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
}

