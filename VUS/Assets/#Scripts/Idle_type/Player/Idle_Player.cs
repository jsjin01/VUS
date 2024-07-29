using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Idle_Player : MonoBehaviour
{
    public static Idle_Player instance;//��ü�� �ϳ�
    //�÷��̾� �ɷ�ġ 
    public float attackPower { get; private set; }      //���ݷ�
    public float magicPower { get; private set; }       //�ֹ���
    public float attackSpeed { get; private set; }      //���ݼӵ�
    public float speed { get; private set; }            //�̵��ӵ�
    public float hp { get; private set; }               //���� ü��
    public float maxHp { get; private set; }           //�ִ� ü��
    public float mp { get; private set; }               //���� ����
    public float maxMp { get; private set; }            //�ִ� ����
    public float exp { get; private set; }              //���� ����ġ
    public float maxExp { get; private set; }           //���� ����ġ���� �ʿ��� ����ġ
    public float dp { get; private set; }               //defensive power ����
    public float mr { get; private set; }               //magic resistance ���� ���׷�
    public float cri { get; private set; }              //ġ��Ÿ Ȯ��
    public float criDmg { get; private set; }           //ġ��Ÿ ������

    private void Awake()
    {
        instance = this;
    }
}



