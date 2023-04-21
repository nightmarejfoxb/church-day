/*Interfering with another script.  Us Character instead.
 * 
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour, IDamagable
{
    public enum Team
    {
        Player,
        Mess
    }

    public string DisplayName;
    public int CurHp;
    public int MaxHp;

    [SerializeField] protected Team team;

    [Header("Audio")]
    [SerializeField] protected AudioSource audioSource;
    

    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;

    public virtual void TakeDamage(int damageToTake)
    {
        CurHp -= damageToTake;


        onTakeDamage?.Invoke();

        if(CurHp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        
    }

    public Team GetTeam()
    {
        return team;
    }
    public virtual void Heal (int healAmount)
    {
        CurHp += healAmount;

        if(CurHp > MaxHp)
        {
            CurHp = MaxHp;
        }

        onHeal?.Invoke();
    }
}
*/