using UnityEngine;

public class StatUpgrade : MonoBehaviour
{
    public int attackPower = 10; // 기본 공격력
    public int magicPower = 10;  // 기본 주문력
    public int mana = 100;       // 기본 마나
    public int gold = 1000;      // 초기 골드
    public float attackSpeed = 1.0f; //기본 공격 속도 (1.0배속)
    public float moveSpeed = 5.0f; //기본 이동 속도

    public int maxHealth = 100;      // 기본 최대 체력
    public int defense = 10;         // 기본 방어력
    public int magicResist = 10;     // 기본 마법 저항력
    public float critChance = 5.0f;  // 기본 치명타 확률 (5%)
    public float critDamage = 150.0f; // 기본 치명타 데미지 (150%)

    public void UpgradeAttackPower(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            attackPower += amount * 5;  // 1업당 5 공격력 증가
            gold -= cost;
            Debug.Log($"공격력이 {attackPower}로 증가했습니다. 남은 골드: {gold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }

    public void UpgradeMagicPower(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            magicPower += amount * 5;  // 1업당 5 주문력 증가
            mana += amount * 10;       // 1업당 10 마나 증가
            gold -= cost;
            Debug.Log($"주문력이 {magicPower}, 마나가 {mana}로 증가했습니다. 남은 골드: {gold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
    public void UpgradeAttackSpeed(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            attackSpeed += attackSpeed * 0.05f * amount;  // 1업당 5% 증가
            gold -= cost;
            Debug.Log($"공격 속도가 {attackSpeed}로 증가했습니다. 남은 골드: {gold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }

    public void UpgradeMoveSpeed(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            moveSpeed += moveSpeed * 0.05f * amount;  // 1업당 5% 증가
            gold -= cost;
            Debug.Log($"이동 속도가 {moveSpeed}로 증가했습니다. 남은 골드: {gold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
    public void UpgradePhysicalStrength(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            maxHealth += amount * 10;      // 1업당 최대 체력 10 증가
            defense += amount * 5;         // 1업당 방어력 5 증가
            magicResist += amount * 5;     // 1업당 마법 저항력 5 증가
            gold -= cost;
            Debug.Log($"최대 체력: {maxHealth}, 방어력: {defense}, 마법 저항력: {magicResist}로 증가했습니다. 남은 골드: {gold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }

    public void UpgradeCritChance(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            critChance += 0.1f * amount;  // 1업당 치명타 확률 0.1% 증가
            gold -= cost;
            Debug.Log($"치명타 확률이 {critChance}%로 증가했습니다. 남은 골드: {gold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }

    public void UpgradeCritDamage(int amount)
    {
        int cost = amount * 100;

        if (gold >= cost)
        {
            critDamage += 0.5f * amount;  // 1업당 치명타 데미지 0.5% 증가
            gold -= cost;
            Debug.Log($"치명타 데미지가 {critDamage}%로 증가했습니다. 남은 골드: {gold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
}