using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Animator animator;

    public EquipController EquipCtrl;
    public static Player Instance;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
         Instance = this;
        }
    }

    
}
