using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public SkillSelect[] skillbutton;


    public void SelectStop()
    {
        foreach (var button in skillbutton)
        {
            if ( button.IsCoroutineRunning())
            {
                button.StopEquipCoroutine();
            }
        }
    }

    public void AddSkill()
    {
        
    }

}

