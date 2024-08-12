using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoWearingEquipment : MonoBehaviour
{
    EquipmentData data;


    public void LoadData(EquipmentData Edata)//데이터를 받아오는 함수
    {
        data = Edata;
    }
}
