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

    public void Attritbute() //능력치창 여는 버튼
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[0].SetActive(true);
    }
    public void Equipment() //장비창 여는 버튼
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[1].SetActive(true);
        Blocker.GetComponent<Canvas>().sortingOrder = +1;
    }
    public void Skill() //스킬창 여는 버튼
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[2].SetActive(true);
    }
    public void Challenge() //도전창 여는 버튼
    {
        for(int i = 0; i < funtionWindow.Length; i++)
        {
            funtionWindow[i].SetActive(false);
        }
        funtionWindow[3].SetActive(true);
    }


}
