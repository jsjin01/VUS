using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class UsingSkill : MonoBehaviour
{
    public SkillSelect select;

    private Queue<int> skillQueue = new Queue<int>();  // 스킬 큐
    private bool isSkillRunning = false;  // 현재 스킬 실행 중인지 여부

    // 각 스킬의 쿨타임 (초 단위)
    public float[] skillCooldowns = new float[3];
    // 각 스킬의 쿨타임 타이머
    private float[] skillCooldownTimers = new float[3];

    private void Start()
    {
        GameObject target1 = GameObject.Find("Skill/SkillEquip/Attack_Skill/Image/content/Skill");
        select = target1.GetComponent<SkillSelect>();

        // 스킬 타이머 초기화
        for (int i = 0; i < skillCooldownTimers.Length; i++)
        {
            skillCooldownTimers[i] = 0;
        }
    }

    private void Update()
    {
        // 쿨타임 타이머 업데이트
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


        // 스킬 큐에 추가
        skillQueue.Enqueue(skillId);

        // 만약 스킬이 실행 중이 아니라면 큐에서 스킬 실행
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

        // 스킬 실행 후 해당 스킬의 쿨타임 타이머 설정
        skillCooldownTimers[skillId - 1] = skillCooldowns[skillId - 1];

        // 스킬 실행 중 다른 작업을 기다림 (쿨타임과는 별개로 즉시 다음 스킬을 실행할 수 있음)
        yield return new WaitForSeconds(0.5f);
    }

    private void PlayAnimation1()
    {
        Debug.Log("스킬 1 애니메이션 실행");
        // 애니메이션 로직 추가
    }

    private void PlayAnimation2()
    {
        Debug.Log("스킬 2 애니메이션 실행");
        // 애니메이션 로직 추가
    }

    private void PlayAnimation3()
    {
        Debug.Log("스킬 3 애니메이션 실행");
        // 애니메이션 로직 추가
    }
}
