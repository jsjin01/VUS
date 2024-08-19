using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int maxHP = 100;
    public int currentHP;
    public int maxMP = 50;
    public int currentMP;
    public int maxEXP = 100;
    public int currentEXP;
    public int gold = 1000;
    public int minerals = 500;

    public Slider hpBar;
    public Slider mpBar;
    public Slider expBar;
    public Button levelUpButton;

    public Text goldText;
    public Text mineralsText;

    private void Start()
    {
        currentHP = maxHP;
        currentMP = maxMP;
        currentEXP = 0;

        hpBar.maxValue = maxHP;
        mpBar.maxValue = maxMP;
        expBar.maxValue = maxEXP;

        UpdateUI();

        //levelUpButton.onClick.AddListener(LevelUp);
    }

    private void UpdateUI()
    {
        hpBar.value = currentHP;
        mpBar.value = currentMP;
        expBar.value = currentEXP;
        goldText.text = "Gold: " + gold;
        mineralsText.text = "��ȭ��: " + minerals;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;
        UpdateUI();
    }

    // ��� ���� �޼���
    public void AddGold(int amount)
    {
        gold += amount;
        UpdateUI();
    }

    // ���� ���� �޼���
    public void AddMinerals(int amount)
    {
        minerals += amount;
        UpdateUI();
    }

    // ���� ��� �޼���
    public void UseMP(int mp)
    {
        currentMP -= mp;
        if (currentMP < 0) currentMP = 0;
        UpdateUI();
    }

   // ����ġ �޼���
    public void GainEXP(int exp)
    {
        currentEXP += exp;
        if (currentEXP >= maxEXP)
        {
            currentEXP -= maxEXP;
            LevelUp();
        }
        UpdateUI();
    }

    public void LevelUp()
    {
        level++;
        maxHP += 10;
        maxMP += 5;
        currentHP = maxHP;
        currentMP = maxMP;
        currentEXP = 0;

        hpBar.maxValue = maxHP;
        mpBar.maxValue = maxMP;
        expBar.maxValue = maxEXP;

        UpdateUI();
    }
}