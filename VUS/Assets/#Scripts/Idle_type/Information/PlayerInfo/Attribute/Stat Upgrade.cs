using UnityEngine;

public class StatUpgrade : MonoBehaviour
{
    public int attackPower = 10; // �⺻ ���ݷ�
    public int magicPower = 10;  // �⺻ �ֹ���
    public int mana = 100;       // �⺻ ����
    public int gold = 1000;      // �ʱ� ���
    public float attackSpeed = 1.0f; //�⺻ ���� �ӵ� (1.0���)
    public float moveSpeed = 5.0f; //�⺻ �̵� �ӵ�

    public int maxHealth = 100;      // �⺻ �ִ� ü��
    public int defense = 10;         // �⺻ ����
    public int magicResist = 10;     // �⺻ ���� ���׷�
    public float critChance = 5.0f;  // �⺻ ġ��Ÿ Ȯ�� (5%)
    public float critDamage = 150.0f; // �⺻ ġ��Ÿ ������ (150%)

    public void UpgradeAttackPower(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            attackPower += amount * 5;  // 1���� 5 ���ݷ� ����
            gold -= cost;
            Debug.Log($"���ݷ��� {attackPower}�� �����߽��ϴ�. ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }

    public void UpgradeMagicPower(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            magicPower += amount * 5;  // 1���� 5 �ֹ��� ����
            mana += amount * 10;       // 1���� 10 ���� ����
            gold -= cost;
            Debug.Log($"�ֹ����� {magicPower}, ������ {mana}�� �����߽��ϴ�. ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }
    public void UpgradeAttackSpeed(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            attackSpeed += attackSpeed * 0.05f * amount;  // 1���� 5% ����
            gold -= cost;
            Debug.Log($"���� �ӵ��� {attackSpeed}�� �����߽��ϴ�. ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }

    public void UpgradeMoveSpeed(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            moveSpeed += moveSpeed * 0.05f * amount;  // 1���� 5% ����
            gold -= cost;
            Debug.Log($"�̵� �ӵ��� {moveSpeed}�� �����߽��ϴ�. ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }
    public void UpgradePhysicalStrength(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            maxHealth += amount * 10;      // 1���� �ִ� ü�� 10 ����
            defense += amount * 5;         // 1���� ���� 5 ����
            magicResist += amount * 5;     // 1���� ���� ���׷� 5 ����
            gold -= cost;
            Debug.Log($"�ִ� ü��: {maxHealth}, ����: {defense}, ���� ���׷�: {magicResist}�� �����߽��ϴ�. ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }

    public void UpgradeCritChance(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            critChance += 0.1f * amount;  // 1���� ġ��Ÿ Ȯ�� 0.1% ����
            gold -= cost;
            Debug.Log($"ġ��Ÿ Ȯ���� {critChance}%�� �����߽��ϴ�. ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }

    public void UpgradeCritDamage(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            critDamage += 0.5f * amount;  // 1���� ġ��Ÿ ������ 0.5% ����
            gold -= cost;
            Debug.Log($"ġ��Ÿ �������� {critDamage}%�� �����߽��ϴ�. ���� ���: {gold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }
}