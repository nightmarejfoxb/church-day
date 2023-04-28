using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talking : MonoBehaviour
{
    public GameObject textPanel;
    public Text textToPlayer;
    public string[] text;
    private int index;

    public GameObject nextButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && playerIsClose)
        {
            if (textPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                textPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(textToPlayer.text == text[index])
        {
            nextButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        textToPlayer.text = "";
        index = 0;
        textPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in text[index].ToCharArray())
        {
            textToPlayer.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        nextButton.SetActive(false);

        if(index < text.Length - 1)
        {
            index++;
            Debug.Log("Index is now " + index);
            textToPlayer.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
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
            zeroText();
        }
    }
}
