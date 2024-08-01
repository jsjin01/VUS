using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillequip : MonoBehaviour
{
    public GameObject Desc;
    SkillSelect equip;

    public void OnClick()
    {
        Desc.SetActive(false);
        equip.SkillEquip(1);

    }
}
