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
    public void UploadData(EquipmentData _data, string _filePath) // 업데이트
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
            Debug.Log("Gold가 없습니다.");
        }
    }

    void UpdateInfo()
    {
        currentTitle.text = $"현재 레벨 능력치(+{data.level})";
        currentDescription.text = $"공격력: +{data.attackPower}" ;
        nextTitle.text = $"다음 레벨 능력치(+{data.level + 1})";
        nextDescription.text = $"공격력 : + {data.attackPower + up}(+{up})";
        cost.text = $"비용: {data.upgradeCost}";

    }
}
