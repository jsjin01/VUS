using UnityEngine;
using UnityEngine.UI;

public class StatUp : MonoBehaviour
{
    // ���� ������
    public int attackLevel = 1;
    public int magicLevel = 1;
    public int attackSpeedLevel = 1;
    public int moveSpeedLevel = 1;
    public int StrengthLevel = 1;
    public int CritChanceLevel = 1;
    public int CritDamageLevel = 1;

    public int attackPower = 100;
    public int magicPower = 80;
    public float attackSpeed = 1.0f;
    public float moveSpeed = 5.0f;
    public int Strength = 10;
    public float CritChance = 5.0f;
    public float CritDamage = 150.0f;


    // ���� ���� �� ������
    private int previousAttackPower;
    private int previousMagicPower;
    private float previousAttackSpeed;
    private float previousMoveSpeed;
    private int previousStrength;   
    private float previousCritChance;
    private float previousCritDamage;

    // UI �ؽ�Ʈ ������
    public Text attackLevelText;
    public Text magicLevelText;
    public Text attackSpeedLevelText;
    public Text moveSpeedLevelText;
    public Text strengthLevelText;
    public Text critChanceLevelText;
    public Text critDamageLevelText;

    public Text attackPowerText;
    public Text magicPowerText;
    public Text attackSpeedText;
    public Text moveSpeedText;
    public Text strengthText;
    public Text critChanceText;
    public Text critDamageText;

    void Start()
    {
        // �ʱ�ȭ �� ���� �� ����
        previousAttackPower = attackPower;
        previousMagicPower = magicPower;
        previousAttackSpeed = attackSpeed;
        previousMoveSpeed = moveSpeed;
        previousStrength = Strength;
        previousCritChance = CritChance;
        previousCritDamage = CritDamage;

        UpdateUI();
    }

    // ���ݷ� ���� �޼���
    public void IncreaseAttackPower()
    {
        attackLevel++;
        previousAttackPower = attackPower;
        attackPower += 5; // ������ ���� ���ݷ� ����
        UpdateUI();
    }

    // �ֹ��� ���� �޼���
    public void IncreaseMagicPower()
    {
        magicLevel++;
        previousMagicPower = magicPower;
        magicPower += 10; // ������ ���� �ֹ��� ����
        UpdateUI();
    }

    // ���ݼӵ� ���� �޼���
    public void IncreaseAttackSpeed()
    {
        attackSpeedLevel++;
        previousAttackSpeed = attackSpeed;
        attackSpeed += 0.1f * attackSpeedLevel; // ������ ���� ���ݼӵ� ����
        UpdateUI();
    }
    
    // �̵��ӵ� ���� �޼���
    public void IncreaseMoveSpeed()
    {
        moveSpeedLevel++;
        previousMoveSpeed = moveSpeed;
        moveSpeed += 0.1f * moveSpeedLevel; // ������ ���� �̵��ӵ� ����
        UpdateUI();
    }

    // ��ü��ȭ ���� �޼���
    public void IncreaseStrength()
    {
        StrengthLevel++;
        previousStrength = Strength;
        Strength += 10; // ������ ���� ��ü��ȭ
        UpdateUI();
    }
    
    // ġ��Ÿ Ȯ�� ���� �޼���
    public void IncreaseCritChance()
    {
        CritChanceLevel++;
        previousCritChance = CritChance;
        CritChance += 0.1f; // ������ ���� ġ��Ÿ Ȯ�� ����
        UpdateUI();
    }

    // ġ��Ÿ ������ ���� �޼���
    public void IncreaseCritDamage()
    {
        CritDamageLevel++;
        previousCritDamage = CritDamage;
        CritDamage += 0.5f; // ������ ���� ġ��Ÿ ������ ����
        UpdateUI();
    }
    // UI ���� �޼���
    void UpdateUI()
    {
        attackLevelText.text = "���ݷ� Lv." + attackLevel;
        magicLevelText.text = "�ֹ��� Lv." + magicLevel;
        attackSpeedLevelText.text = "���ݼӵ� Lv." + attackSpeedLevel;
        moveSpeedLevelText.text = "�̵��ӵ� Lv." + moveSpeedLevel;
        strengthLevelText.text = "��ü��ȭ Lv." + StrengthLevel;
        critChanceLevelText.text = "ġ��Ÿ Ȯ�� Lv." + CritChanceLevel;
        critDamageLevelText.text = "ġ��Ÿ ������ Lv." + CritDamageLevel;

        attackPowerText.text = previousAttackPower + " -> " + attackPower;
        magicPowerText.text = previousMagicPower + " -> " + magicPower;
        attackSpeedText.text = previousAttackSpeed.ToString("F1") + " -> " + attackSpeed.ToString("F1");
        moveSpeedText.text = previousMoveSpeed.ToString("F1") + " -> " + moveSpeed.ToString("F1");
        strengthText.text = previousStrength + " -> " + Strength;
        critChanceText.text = previousCritChance.ToString("F1") + " -> " + CritChance.ToString("F1");
        critDamageText.text = previousCritDamage.ToString("F1") + " -> " + CritDamage.ToString("F1");

    }
}

