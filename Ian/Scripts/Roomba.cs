using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public float vInput;
    public float hInput;
    public float moveSpeed = 15;
    public GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (gM.restart.enabled == false)
        {
            vInput = Input.GetAxis("Vertical");
            hInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime * vInput);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * hInput);
        }*/
    }
}
