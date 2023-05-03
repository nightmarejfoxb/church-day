
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public GameObject Mess;
    public List<Sprite> rotStage;
    public int rotting = 0;
    public SpriteRenderer sR;
    public bool rotAway;
    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        rotAway = true;
    }

    private void Update()
    {
            if (rotting < rotStage.Count - 1 && rotAway == true)
            {
                StartCoroutine("Rotting");
                rotAway = false;
            }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Roomba"))
        {
            Destroy(Mess);
        }
    }

    IEnumerator Rotting()
    {
        yield return new WaitForSeconds(10);
        
        rotting++;
        
        sR.sprite = rotStage[rotting];

        rotAway = true;
    }
}
