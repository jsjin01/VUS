using UnityEngine;
using UnityEngine.UI;

public class StageSelectionUI : MonoBehaviour
{
    public Button[] stageButtons; // �������� ���� ��ư �迭
    public Color clearedColor = Color.blue; // Ŭ������ ���������� ����
    public Color unclearedColor = Color.red; // Ŭ�������� ���� ���������� ����

    void Start()
    {
        UpdateStageButtons();
    }

    // �������� ��ư�� ���� ������Ʈ
    void UpdateStageButtons()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (StageManager.instance.clearedStages[i])
            {
                stageButtons[i].interactable = true; // Ŭ�� ����
                stageButtons[i].GetComponent<Image>().color = clearedColor; // �Ķ���
            }
            else
            {
                stageButtons[i].interactable = false; // Ŭ�� �Ұ�
                stageButtons[i].GetComponent<Image>().color = unclearedColor; // ������
            }
        }
    }

    // �������� ��ư�� Ŭ������ �� ���� (������ ���������� �̵�)
    public void OnStageButtonClick(int stageIndex)
    {
        if (StageManager.instance.clearedStages[stageIndex])
        {
            // ���⿡ ������ ���������� �̵��ϴ� ���� �߰� ����
            Debug.Log("�������� " + (stageIndex + 1) + " ���õ�");
        }
    }
}
