using UnityEngine;
using UnityEngine.UI;

public class ShowDescription : MonoBehaviour
{
    public GameObject descriptionPanel; // ���� �г�
    public Text descriptionText; // ���� �ؽ�Ʈ

    //���� ������ ���� ����
    public float AttackLevel; //���ݷ� ����
    public float currentAttackPower; //���� ���ݷ� ����
    public float nextAttackPower; //���� ���ݷ� ����

    public float MagicLevel; //�ֹ��� ����
    public float currentMagicPower; //���� �ֹ��� ����
    public float nextMagicPower; //���� �ֹ��� ����

    public float AttackSpeedLevel; //���ݼӵ� ����
    public float currentAttackSpeed; //���� ���ݼӵ� ����
    public float nextAttackSpeed; //���� ���ݼӵ� ����

    public float MoveSpeedLevel; //�̵��ӵ� ����
    public float currentMoveSpeed; //���� �̵��ӵ� ����
    public float nextMoveSpeed; //���� �̵��ӵ� ����

    public float PhysicalStrengthLevel; //��ü��ȭ ����
    public float currentPhysicalStrength; //���� ��ü��ȭ ����
    public float nextPhysicalStrength; //���� ��ü��ȭ ����

    public float CritChanceLevel; //ġ��Ÿ Ȯ�� ����
    public float currentCritChance; //���� ġ��Ÿ Ȯ�� ����
    public float nextCritChance; //���� ġ��Ÿ Ȯ�� ����

    public float CritDamageLevel; //ġ��Ÿ ������ ����
    public float currentCritDamage; //���� ġ��Ÿ ������ ����
    public float nextCritDamage; //���� ġ��Ÿ ������ ����

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnButtonClick(string type)
    {
        string description = "";

        if (type == "Attack")
        {
            description = $"���ݷ� LV {AttackLevel}.\n" +
                          $"���� ���ݷ�: {currentAttackPower}\n" +
                          $"���� ���ݷ�: {nextAttackPower}\n\n" +
                          "���ݷ��� ���Ϳ��� �⺻ �������� �ִ� �������� ������ ��Ĩ�ϴ�.";
        }
        else if (type == "Magic")
        {
            description = $"�ֹ��� LV {MagicLevel}.\n" +
                          $"���� �ֹ���: {currentMagicPower}\n" +
                          $"���� �ֹ���: {nextMagicPower}\n\n" +
                          "�ֹ����� ���Ϳ��� ��ų�� �ִ� �������� ������ ��Ĩ�ϴ�.\n" +
                          "����, ��ų�� ����ϴ� �� �ʿ��� MP�� �÷��ݴϴ�.";
        }
        else if (type == "AttackSpeed")
        {
            description = $"���ݼӵ� LV {AttackSpeedLevel}.\n" +
                          $"���� ���ݼӵ�: {currentAttackSpeed}\n" +
                          $"���� ���ݼӵ�: {nextAttackSpeed}\n\n" +
                          "���ݼӵ��� �⺻ ������ �����ϴµ� �ɸ��� �ð��� ������ ��Ĩ�ϴ�.";
        }
        else if (type == "MoveSpeed")
        {
            description = $"���ݼӵ� LV {MoveSpeedLevel}.\n" +
                          $"���� �̵��ӵ�: {currentMoveSpeed}\n" +
                          $"���� �̵��ӵ�: {nextMoveSpeed}\n\n" +
                          "�̵��ӵ��� �÷��̾ �̵��ϴ� �ӵ��� ������ ��Ĩ�ϴ�.";
        }
        else if (type == "PhysicalStrength")
        {
            description = $"��ü��ȭ LV {PhysicalStrengthLevel}.\n" +
                          $"���� ��ü��ȭ: {currentPhysicalStrength}\n" +
                          $"���� ��ü��ȭ: {nextPhysicalStrength}\n\n" +
                          "��ü��ȭ�� �÷��̾��� ü��, ����, ���� ���׷¿� ������ ��Ĩ�ϴ�.";
        }
        else if (type == "CritChance")
        {
            description = $"ġ��Ÿ Ȯ�� LV {CritChanceLevel}.\n" +
                          $"���� ġ��Ÿ Ȯ��: {currentCritChance}\n" +
                          $"���� ġ��Ÿ Ȯ��: {nextCritChance}\n\n" +
                          "ġ��Ÿ Ȯ���� ġ��Ÿ�� �� Ȯ���� ������ ��Ĩ�ϴ�.";
        }
        else if (type == "CritDamage")
        {
            description = $"ġ��Ÿ ������ LV {CritDamageLevel}.\n" +
                          $"���� ġ��Ÿ ������: {currentCritDamage}\n" +
                          $"���� ġ��Ÿ ������: {nextCritDamage}\n\n" +
                          "ġ��Ÿ �������� ġ��Ÿ �������� ������ ��Ĩ�ϴ�.";
        }

        descriptionText.text = description;
        descriptionPanel.SetActive(true);
    }
}

