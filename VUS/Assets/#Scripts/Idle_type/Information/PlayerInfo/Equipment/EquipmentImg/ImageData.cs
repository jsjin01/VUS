using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EquipmentImg", menuName = "ScriptableObjects/EquipmentData")]
public class ImageData : ScriptableObject
{
    [Header("장비 타입")]
    [SerializeField] EQUIPMENTTYPE tpye;
    [Header("장비 이미지")]
    [SerializeField]public Sprite[] center;
    [SerializeField]public Sprite[] right;
    [SerializeField]public Sprite[] left;

}
