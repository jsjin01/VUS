using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancel : MonoBehaviour
{
    GameObject Blocker;

    private void Start()
    {
        Blocker = GameObject.Find("FullBlocker");
    }
    public void CancelBtn()//â �ݴ� ��ư
    {
        transform.parent.gameObject.SetActive(false);
        Blocker.GetComponent<Canvas>().sortingOrder += -1;
    }
}
