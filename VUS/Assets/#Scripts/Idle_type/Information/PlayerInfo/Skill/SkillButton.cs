using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public SkillData Data;
    SkillDesc skilldesc;
    public GameObject Desc;
    Image icon;

    public int SkillId;
    private void OnEnable()
    {
        icon = GetComponent<Image>();
        icon.sprite = Data.SkillIcon;
        SkillId = Data.Skillid;
        Desc.SetActive(false);
        skilldesc = transform.parent.parent.parent.parent.GetChild(4).GetComponent<SkillDesc>();
    }

    public void OnCLick()
    {
        if(Desc != null)
        {
            Desc.SetActive(true);
            Debug.Log(skilldesc);
            skilldesc.GetSkillid(gameObject);
        }
        else
        {
            Debug.LogError("Desc is not assigned in the SkillButton script!");
        }
    }
}