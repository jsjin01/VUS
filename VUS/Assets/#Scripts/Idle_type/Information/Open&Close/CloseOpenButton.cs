using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseOpenButton : MonoBehaviour
{
    public static CloseOpenButton instance; //나중에 데이터 저장 및 반영을 위하여 객체로 설정

    [SerializeField] Image img; 
    [SerializeField] Sprite close;//닫혔을 때 => 화살표 
    [SerializeField] Sprite open; //열렸을 때 => 화살표 
    //각각의 게임 오브젝트들
    [SerializeField] GameObject openInfo;
    [SerializeField] GameObject CloseExp;
    bool isOpen = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Open();
    }

    public void CloseAndOpenButton()//버튼에 적용되는 함수 
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            Open();
            PlayerBtn.instance.Attritbute();
        } 
        else
        {
            Close();
        }
    }

    void Close() //닫을 때
    {
        isOpen = false;
        img.sprite = close;
        openInfo.SetActive(false);
        CloseExp.transform.localPosition = new Vector2(0, -540f);
    }
    void Open() //열 때
    {
        isOpen = true;
        img.sprite = open;
        openInfo.SetActive(true);
        CloseExp.transform.localPosition = new Vector2(0,0);
    }
}
