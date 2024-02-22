using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityState
{
    idle,
    walk,
    attack,
    stagger
}

public class Entity : MonoBehaviour
{
    public EntityState currentState;
    public FloatValue maxHealth;
    public float health;
    public string EntityName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;



    public void Knock(Rigidbody2D myRigidbody, float knockDuration, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockDuration));
        TakeDamage(damage);
    }


    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathEffect();
            Destroy(this.gameObject);
        }
    }

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockDuration)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockDuration);
            myRigidbody.velocity = Vector2.zero;
            currentState = EntityState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
