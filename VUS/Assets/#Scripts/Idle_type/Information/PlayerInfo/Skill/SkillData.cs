using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/SkillData")]

public class SkillData : ScriptableObject

{
    public enum Skilltype {Attack, Passive }

    [Header("#MAIN INFO")]
    public Skilltype skilltype;
    public int Skillid;
    public float Damage;
    public float Mana;
    public string SkillName;
    public int Price;
    public float CoolTime;
    [TextArea]
    public string SkillDesc;
    public Sprite SkillIcon;
}
