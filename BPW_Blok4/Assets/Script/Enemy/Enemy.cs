using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idel,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float enemyHealth;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    public LootTable thisLoot;

    private void Awake()
    {
        enemyHealth = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            MakeLoot();
            //if(roomSignal != null){roomSignal.Raise();}

            this.gameObject.SetActive(false);
        }
    }

    private void MakeLoot() // spawn loot wanneer enemy dood gaat
    {
        if(thisLoot != null)
        {
            Powerup current = thisLoot.LootPowerup();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    public IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idel;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
