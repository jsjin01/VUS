using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public SkillData Data;
    public GameObject Desc;
    Image icon;

    public int SkillId;

    private void Awake()
    {
        icon = GetComponent<Image>();
        icon.sprite = Data.SkillIcon;
        SkillId = Data.Skillid;
        Desc.SetActive(false);
    }

    public void OnCLick()
    {
        if(Desc != null)
        {
            Desc.SetActive(true);
        }
        else
        {
            Debug.LogError("Desc is not assigned in the SkillButton script!");
        }
    }
}