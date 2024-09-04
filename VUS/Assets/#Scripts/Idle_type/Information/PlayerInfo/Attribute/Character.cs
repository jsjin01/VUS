using UnityEngine;

[System.Serializable]
public class CharacterStats : MonoBehaviour
{
    public float attackPower; // ���ݷ�
    public float magicPower;  // �ֹ���
    public float attackSpeed; // ���ݼӵ�
    public float strength; //��ü��ȭ
    public float critChance; //ġ��ŸȮ��
    public float critDamage; //ġ��Ÿ������

    // ������
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

