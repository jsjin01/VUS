using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBtn : MonoBehaviour
{
    public static PlayerBtn instance;
    [SerializeField] GameObject[] funtionWindow;
    [SerializeField] GameObject Blocker;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
    }

    public void Attritbute() //�ɷ�ġâ ���� ��ư
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[0].SetActive(true);
    }
    public void Equipment() //���â ���� ��ư
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[1].SetActive(true);
        Blocker.GetComponent<Canvas>().sortingOrder = +1;
    }
    public void Skill() //��ųâ ���� ��ư
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[2].SetActive(true);
    }
    public void Challenge() //����â ���� ��ư
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[3].SetActive(true);
    }


}
