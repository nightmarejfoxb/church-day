using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public GameObject Mess;
    public List<Sprite> rotStage;
    public int rotting = 0;
    public SpriteRenderer sR;
    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (rotting < rotStage.Count - 1)
            {
                rotting++;
            }
            sR.sprite = rotStage[rotting];
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Roomba"))
        {
            Destroy(Mess);
        }
    }
}
