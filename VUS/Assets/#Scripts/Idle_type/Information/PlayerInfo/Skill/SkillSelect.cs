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

    private void Start()
    {
        icon = GetComponent<Image>();
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
                transform.localScale = Vector3.one * (0.5f + Size + (time * 0.3f));
            }
            else if (time <= upSizeTime * 2)
            {
                transform.localScale = Vector3.one * (1 * Size * upSizeTime + 1 - time * Size);
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
            StopCoroutine(equipCoroutine);  // ũ�� ��ȭ �ڷ�ƾ ����
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
}

