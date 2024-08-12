using UnityEngine;
using UnityEngine.UI;

public class StageButtonManager : MonoBehaviour
{
    public GameObject stageButtonPrefab;  // Prefab ����
    public Transform contentPanel;  // Scroll View�� Content Panel ����

    void Start()
    {
        // ����: 10���� �������� ��ư ����
        for (int i = 0; i < 10; i++)
        {
            GameObject newButton = Instantiate(stageButtonPrefab, contentPanel);
            newButton.GetComponentInChildren<Text>().text = "Stage " + (i + 1);

            int stageIndex = i + 1;  // 1���� �����ϵ��� ����
            newButton.GetComponent<Button>().onClick.AddListener(() => OnStageButtonClick(stageIndex));
        }
    }

    void OnStageButtonClick(int stageIndex)
    {
        Debug.Log("Stage " + stageIndex + " ���õ�");
        // ���⿡ �������� ���� �� ������ ���� �߰�
    }
}