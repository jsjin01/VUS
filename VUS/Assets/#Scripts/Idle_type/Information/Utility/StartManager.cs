using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    [SerializeField] GameObject equitment;
    // Start is called before the first frame update
    void Start() //장비 모두 활성화 
    {
        equitment.SetActive(true);
        Invoke("GameObjSet", 0.001f);
    }

    void GameObjSet()
    {
        equitment.SetActive(false);
    }

}
