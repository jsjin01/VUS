using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseOpenButton : MonoBehaviour
{
    public static CloseOpenButton instance; //���߿� ������ ���� �� �ݿ��� ���Ͽ� ��ü�� ����

    [SerializeField] Image img; 
    [SerializeField] Sprite close;//������ �� => ȭ��ǥ 
    [SerializeField] Sprite open; //������ �� => ȭ��ǥ 
    //������ ���� ������Ʈ��
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

    public void CloseAndOpenButton()//��ư�� ����Ǵ� �Լ� 
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

    void Close() //���� ��
    {
        isOpen = false;
        img.sprite = close;
        openInfo.SetActive(false);
        CloseExp.transform.localPosition = new Vector2(0, -540f);
    }
    void Open() //�� ��
    {
        isOpen = true;
        img.sprite = open;
        openInfo.SetActive(true);
        CloseExp.transform.localPosition = new Vector2(0,0);
    }
}
