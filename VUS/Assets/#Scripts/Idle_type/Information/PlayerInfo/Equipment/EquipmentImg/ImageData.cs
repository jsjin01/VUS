using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EquipmentImg", menuName = "ScriptableObjects/EquipmentData")]
public class ImageData : ScriptableObject
{
    [Header("��� Ÿ��")]
    [SerializeField] EQUIPMENTTYPE tpye;
    [Header("��� �̹���")]
    [SerializeField]public Sprite[] center;
    [SerializeField]public Sprite[] right;
    [SerializeField]public Sprite[] left;

}
