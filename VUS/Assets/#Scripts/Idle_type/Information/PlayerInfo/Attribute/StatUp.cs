using UnityEngine;
using UnityEngine.UI;

public class StatUp : MonoBehaviour
{
    // 스탯 변수들
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


    // 스탯 이전 값 변수들
    private int previousAttackPower;
    private int previousMagicPower;
    private float previousAttackSpeed;
    private float previousMoveSpeed;
    private int previousStrength;   
    private float previousCritChance;
    private float previousCritDamage;

    // UI 텍스트 변수들
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
        // 초기화 시 이전 값 저장
        previousAttackPower = attackPower;
        previousMagicPower = magicPower;
        previousAttackSpeed = attackSpeed;
        previousMoveSpeed = moveSpeed;
        previousStrength = Strength;
        previousCritChance = CritChance;
        previousCritDamage = CritDamage;

        UpdateUI();
    }

    // 공격력 증가 메서드
    public void IncreaseAttackPower()
    {
        attackLevel++;
        previousAttackPower = attackPower;
        attackPower += 5; // 레벨에 따라 공격력 증가
        UpdateUI();
    }

    // 주문력 증가 메서드
    public void IncreaseMagicPower()
    {
        magicLevel++;
        previousMagicPower = magicPower;
        magicPower += 10; // 레벨에 따라 주문력 증가
        UpdateUI();
    }

    // 공격속도 증가 메서드
    public void IncreaseAttackSpeed()
    {
        attackSpeedLevel++;
        previousAttackSpeed = attackSpeed;
        attackSpeed += 0.1f * attackSpeedLevel; // 레벨에 따라 공격속도 증가
        UpdateUI();
    }
    
    // 이동속도 증가 메서드
    public void IncreaseMoveSpeed()
    {
        moveSpeedLevel++;
        previousMoveSpeed = moveSpeed;
        moveSpeed += 0.1f * moveSpeedLevel; // 레벨에 따라 이동속도 증가
        UpdateUI();
    }

    // 육체강화 증가 메서드
    public void IncreaseStrength()
    {
        StrengthLevel++;
        previousStrength = Strength;
        Strength += 10; // 레벨에 따라 육체강화
        UpdateUI();
    }
    
    // 치명타 확률 증가 메서드
    public void IncreaseCritChance()
    {
        CritChanceLevel++;
        previousCritChance = CritChance;
        CritChance += 0.1f; // 레벨에 따라 치명타 확률 증가
        UpdateUI();
    }

    // 치명타 데미지 증가 메서드
    public void IncreaseCritDamage()
    {
        CritDamageLevel++;
        previousCritDamage = CritDamage;
        CritDamage += 0.5f; // 레벨에 따라 치명타 데미지 증가
        UpdateUI();
    }
    // UI 갱신 메서드
    void UpdateUI()
    {
        attackLevelText.text = "공격력 Lv." + attackLevel;
        magicLevelText.text = "주문력 Lv." + magicLevel;
        attackSpeedLevelText.text = "공격속도 Lv." + attackSpeedLevel;
        moveSpeedLevelText.text = "이동속도 Lv." + moveSpeedLevel;
        strengthLevelText.text = "육체강화 Lv." + StrengthLevel;
        critChanceLevelText.text = "치명타 확률 Lv." + CritChanceLevel;
        critDamageLevelText.text = "치명타 데미지 Lv." + CritDamageLevel;

        attackPowerText.text = previousAttackPower + " -> " + attackPower;
        magicPowerText.text = previousMagicPower + " -> " + magicPower;
        attackSpeedText.text = previousAttackSpeed.ToString("F1") + " -> " + attackSpeed.ToString("F1");
        moveSpeedText.text = previousMoveSpeed.ToString("F1") + " -> " + moveSpeed.ToString("F1");
        strengthText.text = previousStrength + " -> " + Strength;
        critChanceText.text = previousCritChance.ToString("F1") + " -> " + CritChance.ToString("F1");
        critDamageText.text = previousCritDamage.ToString("F1") + " -> " + CritDamage.ToString("F1");

    }
}

