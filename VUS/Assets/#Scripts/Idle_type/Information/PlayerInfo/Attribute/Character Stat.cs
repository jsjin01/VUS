using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStats stats;

    void Start()
    {
        // �ʱ� ���� ���� (����)
        stats = new CharacterStats(40f, 20f, 0.1f, 30f, 0.05f, 0.05f);
    }

    // ���� ������Ʈ �Լ� ����
    public void IncreaseAttackPower(float amount)
    {
        stats.attackPower += amount;
        Debug.Log("���ݷ��� �����߽��ϴ�: " + stats.attackPower);
    }
}
