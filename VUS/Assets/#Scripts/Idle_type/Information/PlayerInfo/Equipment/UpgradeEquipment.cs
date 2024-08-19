using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeEquipment : MonoBehaviour
{
    EquipmentData data;
    string filePath;

    [SerializeField] GameObject player;
    [SerializeField] Text currentTitle;
    [SerializeField] Text currentDescription;
    [SerializeField] Text nextTitle;
    [SerializeField] Text nextDescription;
    [SerializeField] Text cost;


    float up = 5f;
    private void Start()
    {
        UpdateInfo();
    }
    public void UploadData(EquipmentData _data, string _filePath) // ������Ʈ
    {
        data = _data;
        filePath = _filePath; 
    }

    public void Upgrade()
    {
        if(player.GetComponent<StatUpgrade>().gold >= data.upgradeCost)
        {
            data.upgradeCost = (int)(data.upgradeCost*1.1);
            data.level += 1;
            data.attackPower += up;
            UpdateInfo();
        }
        else
        {
            Debug.Log("Gold�� �����ϴ�.");
        }
    }

    void UpdateInfo()
    {
        currentTitle.text = $"���� ���� �ɷ�ġ(+{data.level})";
        currentDescription.text = $"���ݷ�: +{data.attackPower}" ;
        nextTitle.text = $"���� ���� �ɷ�ġ(+{data.level + 1})";
        nextDescription.text = $"���ݷ� : + {data.attackPower + up}(+{up})";
        cost.text = $"���: {data.upgradeCost}";

    }
}
