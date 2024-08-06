using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] int index; //슬롯 번호
    EquipmentData equipmentData;//해당칸의 장비 데이터
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
            // JSON 파일 읽기
            string jsonData = File.ReadAllText(filePath);

            // JSON 데이터를 EquipmentData 객체로 변환 
            equipmentData = JsonUtility.FromJson<EquipmentData>(jsonData);
        }
        else
        {
            Debug.LogError("Cannot find JSON file at " + filePath);
        }

    }
}
