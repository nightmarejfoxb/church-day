using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercr : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Animator animator;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer sr;


    public GameManager gM;
    private Vector2 moveInput;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       if (gM.restart.enabled == false)
        {
            moveSpeed = 5;
        }
        else
        {
            moveSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = moveInput * moveSpeed;
            rig.velocity = velocity;
            animator.SetFloat("move", Mathf.Abs(velocity.magnitude));
        

    }

    public void OnMoveInput (InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
