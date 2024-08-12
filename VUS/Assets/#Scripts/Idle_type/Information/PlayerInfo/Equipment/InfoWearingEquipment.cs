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
        transform.GetChild(4).GetComponent<Button>().onClick.AddListener(UpgradeInfo);//��ư Ŭ�� 
    }

    public void UploadData(EquipmentData _data, string _filePath)//�����͸� �޾ƿ��� �Լ�
    {
        data = _data;
        filePath = _filePath;
    }

    void UpgradeInfo()//���۷��̵� â ����
    {
        upgradeInfo.SetActive(true);
        upgradeInfo.GetComponent<UpgradeEquipment>().UploadData(data, filePath);
    }
}
