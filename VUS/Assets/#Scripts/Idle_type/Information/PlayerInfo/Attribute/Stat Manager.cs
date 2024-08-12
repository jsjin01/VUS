using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public Text statNameText; // ���� �̸� �� ���� �ؽ�Ʈ
    public Text statValueText; // ���� �� �ؽ�Ʈ
    public Text statDescriptionText; // ���� ���� �ؽ�Ʈ

    private int statLevel = 1; // ���� ���� �ʱⰪ
    private int currentStatValue = 100; // ���� �ʱⰪ
    private int statIncreaseAmount = 5; // ���� ������

    void Start()
    {
        UpdateStatUI();
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnStatIncreaseButtonClick()
    {
        currentStatValue += statIncreaseAmount;
        statLevel++;
        UpdateStatUI();
    }

    // UI ������Ʈ �޼���
    private void UpdateStatUI()
    {
        statNameText.text = "���ݷ�: Lv." + statLevel;
        statValueText.text = currentStatValue + " -> " + (currentStatValue + statIncreaseAmount);
        statDescriptionText.text = "���ݷ��� ���Ϳ��� �⺻ �������� �ִ� �������� ������ ��Ĩ�ϴ�.";
    }
}
