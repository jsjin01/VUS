using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Idle_Player : MonoBehaviour
{
    public static Idle_Player instance;//객체가 하나
    //플레이어 능력치 
    public float attackPower { get; private set; }      //공격력
    public float magicPower { get; private set; }       //주문력
    public float attackSpeed { get; private set; }      //공격속도
    public float speed { get; private set; }            //이동속도
    public float hp { get; private set; }               //현재 체력
    public float maxHp { get; private set; }           //최대 체력
    public float mp { get; private set; }               //현재 마나
    public float maxMp { get; private set; }            //최대 마나
    public float exp { get; private set; }              //현재 경험치
    public float maxExp { get; private set; }           //다음 경험치까지 필요한 경험치
    public float dp { get; private set; }               //defensive power 방어력
    public float mr { get; private set; }               //magic resistance 마법 저항력
    public float cri { get; private set; }              //치명타 확률
    public float criDmg { get; private set; }           //치명타 데미지

    private void Awake()
    {
        instance = this;
    }
}



