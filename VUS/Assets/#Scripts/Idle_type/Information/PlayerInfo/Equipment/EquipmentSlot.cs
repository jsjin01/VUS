using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] int index; //���� ��ȣ
    EquipmentData equipmentData;//�ش�ĭ�� ��� ������
    string path = "#SaveJSON/EquipmentSlot/EquipmentSlot";


    private void Start()
    {
        DataLoad();
    }


    void DataLoad()
    {
        path = path + index + ".json";
        string filePath = Path.Combine(Application.dataPath, path);

        if(File.Exists(filePath))
        {
            // JSON ���� �б�
            string jsonData = File.ReadAllText(filePath);

            // JSON �����͸� EquipmentData ��ü�� ��ȯ 
            equipmentData = JsonUtility.FromJson<EquipmentData>(jsonData);
        }
        else
        {
            Debug.LogError("Cannot find JSON file at " + filePath);
        }

    }
}
