using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    protected State curState;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float chaseDistance;
    [SerializeField] private ItemData[] dropItems;

    private GameObject dropItemPrefab;

    protected GameObject target;

    protected float lastAttackTime;
    protected float targetDistance;
    protected float attackDistance;

    [Header("Components")]
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected virtual void Start ()
    {
        target = FindObjectOfType<Player>().gameObject;
    }

    protected virtual void Update ()
    {
        // Calculate the distance from us to the target.
        targetDistance = Vector2.Distance(transform.position, target.transform.position);

        // Flip the sprite to face the target.
        spriteRenderer.flipX = GetTargetDirection().x < 0;

        // State update.
        switch(curState)
        {
            case State.Idle: IdleUpdate(); break;
            case State.Chase: ChaseUpdate(); break;
            case State.Attack: AttackUpdate(); break;
        }
    }

    // Changes our current state.
    protected virtual void ChangeState (State newState)
    {
        curState = newState;
    }

    // Called every frame while in the "Idle" state.
    void IdleUpdate ()
    {
        if (targetDistance <= chaseDistance)
            ChangeState(State.Chase);
    }

    // Called every frame while in the "Chase" state.
    void ChaseUpdate()
    {
        if (InAttackRange())
            ChangeState(State.Attack);
        else if (targetDistance > chaseDistance)
            ChangeState(State.Idle);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    // Called every frame while in the "Attack" state.
    void AttackUpdate()
    {
        if (targetDistance > chaseDistance)
            ChangeState(State.Idle);
        else if (!InAttackRange())
            ChangeState(State.Chase);

        if (CanAttack())
        {
            lastAttackTime = Time.time;
            AttackTarget();
        }
    }

    protected virtual void AttackTarget ()
    {

    }

    protected virtual bool CanAttack ()
    {
        return false;
    }

    protected virtual bool InAttackRange ()
    {
        return false;
    }

    protected virtual Vector2 GetTargetDirection ()
    {
        return (target.transform.position - transform.position).normalized;
    }

    public override void Die ()
    {
        DropItems();
        Destroy(gameObject);
    }

    protected void DropItems ()
    {
        for(int i = 0; i < dropItems.Length; i++)
        {
            GameObject obj = Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
           // obj.GetComponent<WorldItem>().SetItem(dropItems[i]);
        }
    }
}