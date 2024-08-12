using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public Text statNameText; // 스탯 이름 및 레벨 텍스트
    public Text statValueText; // 스탯 값 텍스트
    public Text statDescriptionText; // 스탯 설명 텍스트

    private int statLevel = 1; // 스탯 레벨 초기값
    private int currentStatValue = 100; // 스탯 초기값
    private int statIncreaseAmount = 5; // 스탯 증가량

    void Start()
    {
        UpdateStatUI();
    }

    // 버튼 클릭 시 호출되는 메서드
    public void OnStatIncreaseButtonClick()
    {
        currentStatValue += statIncreaseAmount;
        statLevel++;
        UpdateStatUI();
    }

    // UI 업데이트 메서드
    private void UpdateStatUI()
    {
        statNameText.text = "공격력: Lv." + statLevel;
        statValueText.text = currentStatValue + " -> " + (currentStatValue + statIncreaseAmount);
        statDescriptionText.text = "공격력은 몬스터에게 기본 공격으로 주는 데미지에 영향을 미칩니다.";
    }
}
