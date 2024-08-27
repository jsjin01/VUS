using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class UsingSkill : MonoBehaviour
{
    public SkillSelect select;

    private Queue<int> skillQueue = new Queue<int>();  // ��ų ť
    private bool isSkillRunning = false;  // ���� ��ų ���� ������ ����

    // �� ��ų�� ��Ÿ�� (�� ����)
    public float[] skillCooldowns = new float[3];
    // �� ��ų�� ��Ÿ�� Ÿ�̸�
    private float[] skillCooldownTimers = new float[3];

    private void Start()
    {
        GameObject target1 = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content/Skill");
        select = target1.GetComponent<SkillSelect>();

        // ��ų Ÿ�̸� �ʱ�ȭ
        for (int i = 0; i < skillCooldownTimers.Length; i++)
        {
            skillCooldownTimers[i] = 0;
        }
    }

    private void Update()
    {
        // ��Ÿ�� Ÿ�̸� ������Ʈ
        for (int i = 0; i < skillCooldownTimers.Length; i++)
        {
            if (skillCooldownTimers[i] > 0)
            {
                skillCooldownTimers[i] -= Time.deltaTime;
            }
        }
    }

    public void UseSkill(int skillButtonIndex)
    {
        int skillId = select.UsingSkill[skillButtonIndex].SKillid;


        // ��ų ť�� �߰�
        skillQueue.Enqueue(skillId);

        // ���� ��ų�� ���� ���� �ƴ϶�� ť���� ��ų ����
        if (!isSkillRunning)
        {
            StartCoroutine(ProcessSkillQueue());
        }
    }

    private IEnumerator ProcessSkillQueue()
    {
        while (skillQueue.Count > 0)
        {
            isSkillRunning = true;
            int skillId = skillQueue.Dequeue();
            yield return StartCoroutine(ExecuteSkill(skillId));
        }

        isSkillRunning = false;
    }

    private IEnumerator ExecuteSkill(int skillId)
    {
        switch (skillId)
        {
            case 1:
                PlayAnimation1();
                yield break;
            case 2:
                PlayAnimation2();
                yield break;
            case 3:
                PlayAnimation3();
                yield break;

        }

        // ��ų ���� �� �ش� ��ų�� ��Ÿ�� Ÿ�̸� ����
        skillCooldownTimers[skillId - 1] = skillCooldowns[skillId - 1];

        // ��ų ���� �� �ٸ� �۾��� ��ٸ� (��Ÿ�Ӱ��� ������ ��� ���� ��ų�� ������ �� ����)
        yield return new WaitForSeconds(0.5f);
    }

    private void PlayAnimation1()
    {
        Debug.Log("��ų 1 �ִϸ��̼� ����");
        // �ִϸ��̼� ���� �߰�
    }

    private void PlayAnimation2()
    {
        Debug.Log("��ų 2 �ִϸ��̼� ����");
        // �ִϸ��̼� ���� �߰�
    }

    private void PlayAnimation3()
    {
        Debug.Log("��ų 3 �ִϸ��̼� ����");
        // �ִϸ��̼� ���� �߰�
    }
}
