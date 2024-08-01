using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelect : MonoBehaviour
{
    float time = 0;
    public float Size = 5;

    public float upSizeTime = 0.5f;

    SkillData Data;
    Image icon;

    private void Start()
    {
        icon = GetComponent<Image>();
    }

    public void SkillEquip(int state)
    {
        if (state == 1)
        {
            CanEquip();
        }
        else
        {
            return;
        }
    }

    public void CanEquip()
    {
        if(time <= upSizeTime) 
        { 
            transform.localScale = Vector3.one * (1 + Size + time);
        }
        else if(time <= upSizeTime * 2) 
        { 
            transform.localScale = Vector3.one * (2 * Size * upSizeTime + 1 - time * Size);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        time += Time.deltaTime;
    }

    public void OnClick(int state)
    {
        time = 0;
        state = 0;
        icon.sprite = Data.SkillIcon;
    }

}
