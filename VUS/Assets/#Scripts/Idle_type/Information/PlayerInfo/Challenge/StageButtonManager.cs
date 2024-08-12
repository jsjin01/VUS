using UnityEngine;
using UnityEngine.UI;

public class StageButtonManager : MonoBehaviour
{
    public GameObject stageButtonPrefab;  // Prefab 연결
    public Transform contentPanel;  // Scroll View의 Content Panel 연결

    void Start()
    {
        // 예시: 10개의 스테이지 버튼 생성
        for (int i = 0; i < 10; i++)
        {
            GameObject newButton = Instantiate(stageButtonPrefab, contentPanel);
            newButton.GetComponentInChildren<Text>().text = "Stage " + (i + 1);

            int stageIndex = i + 1;  // 1부터 시작하도록 설정
            newButton.GetComponent<Button>().onClick.AddListener(() => OnStageButtonClick(stageIndex));
        }
    }

    void OnStageButtonClick(int stageIndex)
    {
        Debug.Log("Stage " + stageIndex + " 선택됨");
        // 여기에 스테이지 선택 시 실행할 로직 추가
    }
}