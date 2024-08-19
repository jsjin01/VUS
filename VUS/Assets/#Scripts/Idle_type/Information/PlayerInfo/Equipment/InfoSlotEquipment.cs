using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class InfoSlotEquipment : MonoBehaviour
{
    string wearingPath;
    string slotPath;
    EquipmentData wearingData;
    EquipmentData slotData;
    GameObject wearingEquipment;
    GameObject slotEquipment;


    GameObject Blocker;
    [SerializeField] GameObject upgradeInfo;

    public void LoadData(string _wearingPath, string _slotPath, EquipmentData _wearingData, EquipmentData _slotData, GameObject _wearingEquipment, GameObject _slotEquipment)//데이터 로드
    {
        wearingPath = _wearingPath;
        slotPath = _slotPath;
        wearingData = _wearingData;
        slotData = _slotData;
        wearingEquipment = _wearingEquipment;
        slotEquipment = _slotEquipment;

        Blocker = GameObject.Find("FullBlocker");
    }

    public void ChangeEquipment()//장비 교체
    {
        // JSON 파일 변경
        string slotJson = JsonUtility.ToJson(wearingData, true);
        File.WriteAllText(slotPath , slotJson);

        string wearingJson = JsonUtility.ToJson(slotData, true);
        File.WriteAllText(wearingPath, wearingJson);

        wearingEquipment.GetComponent<WearingEquipment>().DataLoad();
        slotEquipment.GetComponent<EquipmentSlot>().DataLoad();


        //변환된 다시 저장
        string wearingJsonData = File.ReadAllText(wearingPath);
        string slotJsonData = File.ReadAllText(slotPath);

        wearingData = JsonUtility.FromJson<EquipmentData>(wearingJsonData);
        slotData = JsonUtility.FromJson<EquipmentData>(slotJsonData);

        slotEquipment.GetComponent<EquipmentSlot>().ShowInfo();
        Blocker.GetComponent<Canvas>().sortingOrder += -1;
    }

    public void SlotUpgradeInfo()//업글레이드 창 띄우기
    {
        upgradeInfo.SetActive(true);
        upgradeInfo.GetComponent<UpgradeEquipment>().UploadData(slotData, slotPath);
    }

    public void WearingUpgradeInfo()//업글레이드 창 띄우기
    {
        upgradeInfo.SetActive(true);
        upgradeInfo.GetComponent<UpgradeEquipment>().UploadData(wearingData, wearingPath);
    }
}
