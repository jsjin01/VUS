using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public int currentStage = 1; // 현재 스테이지 번호 (1부터 시작)
    public bool[] clearedStages; // 각 스테이지의 클리어 여부

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeStages();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 스테이지 클리어 여부 초기화
    void InitializeStages()
    {
        clearedStages = new bool[10]; // 예시로 10개의 스테이지를 설정
        clearedStages[0] = true; // 첫 번째 스테이지는 항상 활성화
    }

    // 스테이지 클리어 처리
    public void ClearStage(int stageIndex)
    {
        if (stageIndex < clearedStages.Length)
        {
            clearedStages[stageIndex] = true;
            if (stageIndex + 1 < clearedStages.Length)
            {
                clearedStages[stageIndex + 1] = true; // 다음 스테이지 활성화
            }
        }
    }
}
