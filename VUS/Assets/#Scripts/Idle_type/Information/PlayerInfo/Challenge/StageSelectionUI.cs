using UnityEngine;
using UnityEngine.UI;

public class StageSelectionUI : MonoBehaviour
{
    public Button[] stageButtons; // 스테이지 선택 버튼 배열
    public Color clearedColor = Color.blue; // 클리어한 스테이지의 색상
    public Color unclearedColor = Color.red; // 클리어하지 못한 스테이지의 색상

    void Start()
    {
        UpdateStageButtons();
    }

    // 스테이지 버튼의 상태 업데이트
    void UpdateStageButtons()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (StageManager.instance.clearedStages[i])
            {
                stageButtons[i].interactable = true; // 클릭 가능
                stageButtons[i].GetComponent<Image>().color = clearedColor; // 파란색
            }
            else
            {
                stageButtons[i].interactable = false; // 클릭 불가
                stageButtons[i].GetComponent<Image>().color = unclearedColor; // 빨간색
            }
        }
    }

    // 스테이지 버튼을 클릭했을 때 실행 (선택한 스테이지로 이동)
    public void OnStageButtonClick(int stageIndex)
    {
        if (StageManager.instance.clearedStages[stageIndex])
        {
            // 여기에 선택한 스테이지로 이동하는 로직 추가 가능
            Debug.Log("스테이지 " + (stageIndex + 1) + " 선택됨");
        }
    }
}
