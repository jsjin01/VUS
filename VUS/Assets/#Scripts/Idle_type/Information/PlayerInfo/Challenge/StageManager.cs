using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public int currentStage = 1; // ���� �������� ��ȣ (1���� ����)
    public bool[] clearedStages; // �� ���������� Ŭ���� ����

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

    // �������� Ŭ���� ���� �ʱ�ȭ
    void InitializeStages()
    {
        clearedStages = new bool[10]; // ���÷� 10���� ���������� ����
        clearedStages[0] = true; // ù ��° ���������� �׻� Ȱ��ȭ
    }

    // �������� Ŭ���� ó��
    public void ClearStage(int stageIndex)
    {
        if (stageIndex < clearedStages.Length)
        {
            clearedStages[stageIndex] = true;
            if (stageIndex + 1 < clearedStages.Length)
            {
                clearedStages[stageIndex + 1] = true; // ���� �������� Ȱ��ȭ
            }
        }
    }
}
