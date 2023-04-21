using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public Image victory;

    public GameObject[] turrets;
    // Start is called before the first frame update
    void Start()
    {
        victory.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Mess");
    }
}
