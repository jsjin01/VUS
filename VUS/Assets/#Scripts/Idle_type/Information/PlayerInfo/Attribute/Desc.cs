using UnityEngine;
using UnityEngine.UI;

public class ShowDescription : MonoBehaviour
{
    public GameObject descriptionPanel; // 설명 패널
    public Text descriptionText; // 설명 텍스트

    //스탯 정보를 위한 변수
    public float AttackLevel; //공격력 레벨
    public float currentAttackPower; //현재 공격력 레벨
    public float nextAttackPower; //다음 공격력 레벨

    public float MagicLevel; //주문력 레벨
    public float currentMagicPower; //현재 주문력 레벨
    public float nextMagicPower; //다음 주문력 레벨

    public float AttackSpeedLevel; //공격속도 레벨
    public float currentAttackSpeed; //현재 공격속도 레벨
    public float nextAttackSpeed; //다음 공격속도 레벨

    public float MoveSpeedLevel; //이동속도 레벨
    public float currentMoveSpeed; //현재 이동속도 레벨
    public float nextMoveSpeed; //다음 이동속도 레벨

    public float PhysicalStrengthLevel; //육체강화 레벨
    public float currentPhysicalStrength; //현재 육체강화 레벨
    public float nextPhysicalStrength; //다음 육체강화 레벨

    public float CritChanceLevel; //치명타 확률 레벨
    public float currentCritChance; //현재 치명타 확률 레벨
    public float nextCritChance; //다음 치명타 확률 레벨

    public float CritDamageLevel; //치명타 데미지 레벨
    public float currentCritDamage; //현재 치명타 데미지 레벨
    public float nextCritDamage; //다음 치명타 데미지 레벨

    // 버튼 클릭 시 호출되는 함수
    public void OnButtonClick(string type)
    {
        string description = "";

        if (type == "Attack")
        {
            description = $"공격력 LV {AttackLevel}.\n" +
                          $"현재 공격력: {currentAttackPower}\n" +
                          $"다음 공격력: {nextAttackPower}\n\n" +
                          "공격력은 몬스터에게 기본 공격으로 주는 데미지에 영향을 미칩니다.";
        }
        else if (type == "Magic")
        {
            description = $"주문력 LV {MagicLevel}.\n" +
                          $"현재 주문력: {currentMagicPower}\n" +
                          $"다음 주문력: {nextMagicPower}\n\n" +
                          "주문력은 몬스터에게 스킬로 주는 데미지에 영향을 미칩니다.\n" +
                          "또한, 스킬을 사용하는 데 필요한 MP도 늘려줍니다.";
        }
        else if (type == "AttackSpeed")
        {
            description = $"공격속도 LV {AttackSpeedLevel}.\n" +
                          $"현재 공격속도: {currentAttackSpeed}\n" +
                          $"다음 공격속도: {nextAttackSpeed}\n\n" +
                          "공격속도는 기본 공격을 시전하는데 걸리는 시간에 영향을 미칩니다.";
        }
        else if (type == "MoveSpeed")
        {
            description = $"공격속도 LV {MoveSpeedLevel}.\n" +
                          $"현재 이동속도: {currentMoveSpeed}\n" +
                          $"다음 이동속도: {nextMoveSpeed}\n\n" +
                          "이동속도는 플레이어가 이동하는 속도에 영향을 미칩니다.";
        }
        else if (type == "PhysicalStrength")
        {
            description = $"육체강화 LV {PhysicalStrengthLevel}.\n" +
                          $"현재 육체강화: {currentPhysicalStrength}\n" +
                          $"다음 육체강화: {nextPhysicalStrength}\n\n" +
                          "육체강화는 플레이어의 체력, 방어력, 마법 저항력에 영향을 미칩니다.";
        }
        else if (type == "CritChance")
        {
            description = $"치명타 확률 LV {CritChanceLevel}.\n" +
                          $"현재 치명타 확률: {currentCritChance}\n" +
                          $"다음 치명타 확률: {nextCritChance}\n\n" +
                          "치명타 확률은 치명타가 뜰 확률에 영향을 미칩니다.";
        }
        else if (type == "CritDamage")
        {
            description = $"치명타 데미지 LV {CritDamageLevel}.\n" +
                          $"현재 치명타 데미지: {currentCritDamage}\n" +
                          $"다음 치명타 데미지: {nextCritDamage}\n\n" +
                          "치명타 데미지는 치명타 데미지에 영향을 미칩니다.";
        }

        descriptionText.text = description;
        descriptionPanel.SetActive(true);
    }
}

