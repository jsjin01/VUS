using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoWearingEquipment : MonoBehaviour
{
    EquipmentData data;
    string filePath;
    [SerializeField]GameObject upgradeInfo;

    private void Start()
    {
        transform.GetChild(4).GetComponent<Button>().onClick.AddListener(UpgradeInfo);//버튼 클릭 
    }

    public void UploadData(EquipmentData _data, string _filePath)//데이터를 받아오는 함수
    {
        data = _data;
        filePath = _filePath;
    }

    void UpgradeInfo()//업글레이드 창 띄우기
    {
        upgradeInfo.SetActive(true);
        upgradeInfo.GetComponent<UpgradeEquipment>().UploadData(data, filePath);
    }
}
