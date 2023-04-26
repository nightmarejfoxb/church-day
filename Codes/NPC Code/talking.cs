using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talking : MonoBehaviour
{
    public Text textOfTalking;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.T) && playerIsClose)
        {
           // textOfTalking.SetActive(true);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
