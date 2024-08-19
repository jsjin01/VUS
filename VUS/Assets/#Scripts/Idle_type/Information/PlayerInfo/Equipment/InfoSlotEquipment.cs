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

    public void LoadData(string _wearingPath, string _slotPath, EquipmentData _wearingData, EquipmentData _slotData, GameObject _wearingEquipment, GameObject _slotEquipment)//������ �ε�
    {
        wearingPath = _wearingPath;
        slotPath = _slotPath;
        wearingData = _wearingData;
        slotData = _slotData;
        wearingEquipment = _wearingEquipment;
        slotEquipment = _slotEquipment;

        Blocker = GameObject.Find("FullBlocker");
    }

    public void ChangeEquipment()//��� ��ü
    {
        // JSON ���� ����
        string slotJson = JsonUtility.ToJson(wearingData, true);
        File.WriteAllText(slotPath , slotJson);

        string wearingJson = JsonUtility.ToJson(slotData, true);
        File.WriteAllText(wearingPath, wearingJson);

        wearingEquipment.GetComponent<WearingEquipment>().DataLoad();
        slotEquipment.GetComponent<EquipmentSlot>().DataLoad();


        //��ȯ�� �ٽ� ����
        string wearingJsonData = File.ReadAllText(wearingPath);
        string slotJsonData = File.ReadAllText(slotPath);

        wearingData = JsonUtility.FromJson<EquipmentData>(wearingJsonData);
        slotData = JsonUtility.FromJson<EquipmentData>(slotJsonData);

        slotEquipment.GetComponent<EquipmentSlot>().ShowInfo();
        Blocker.GetComponent<Canvas>().sortingOrder += -1;
    }

    public void SlotUpgradeInfo()//���۷��̵� â ����
    {
        upgradeInfo.SetActive(true);
        upgradeInfo.GetComponent<UpgradeEquipment>().UploadData(slotData, slotPath);
    }

    public void WearingUpgradeInfo()//���۷��̵� â ����
    {
        upgradeInfo.SetActive(true);
        upgradeInfo.GetComponent<UpgradeEquipment>().UploadData(wearingData, wearingPath);
    }
}
