using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStats stats;

    void Start()
    {
        // 초기 스탯 설정 (예시)
        stats = new CharacterStats(40f, 20f, 0.1f, 30f, 0.05f, 0.05f);
    }

    // 스탯 업데이트 함수 예시
    public void IncreaseAttackPower(float amount)
    {
        stats.attackPower += amount;
        Debug.Log("공격력이 증가했습니다: " + stats.attackPower);
    }
}
