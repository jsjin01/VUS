using UnityEngine;

[System.Serializable]
public class CharacterStats : MonoBehaviour
{
    public float attackPower; // 공격력
    public float magicPower;  // 주문력
    public float attackSpeed; // 공격속도
    public float strength; //육체강화
    public float critChance; //치명타확률
    public float critDamage; //치명타데미지

    // 생성자
    public CharacterStats(float attackPower, float magicPower, float attackSpeed, float strength, float critChance, float critDamage)
    {
        this.attackPower = attackPower;
        this.magicPower = magicPower;
        this.attackSpeed = attackSpeed;
        this.strength = strength;
        this.critChance = critChance;
        this.critDamage = critDamage;
    }
}

