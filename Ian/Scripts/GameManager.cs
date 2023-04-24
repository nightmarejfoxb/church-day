using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image failure;

    public Image victory;

    public int messPiles;

    public GameObject mess;
    // Start is called before the first frame update
    void Start()
    {
        victory.enabled = false;
        failure.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        messPiles = GameObject.FindGameObjectsWithTag("Mess").Length;

        if(messPiles == 0)
        {
            victory.enabled = true;
        }
    }
}
