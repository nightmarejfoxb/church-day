using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image failure;

    public Image victory;
   
    public Image restart;

    public int messPiles;

    public GameObject mess;

    public float time;
    public bool countdown = true;
    // Start is called before the first frame update
    void Start()
    {
        victory.enabled = false;
        failure.enabled = false;
        restart.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        messPiles = GameObject.FindGameObjectsWithTag("Mess").Length;

        if(messPiles < 1)
        {
            victory.enabled = true;
            restart.enabled = true;
        }

        if (time > 0 && countdown == true && victory.enabled == false)
        {
            StartCoroutine("Wait");
            countdown = false;
        }
        if(time < 1 && victory.enabled == false)
        {
            failure.enabled = true;
            restart.enabled = true;
        }
        else
        {
            failure.enabled = false;
        }
        if(restart.enabled == true && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("InSide");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        time--;
        countdown = true;

    }
}
