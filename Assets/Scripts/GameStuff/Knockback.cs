using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockDuration;
    public float damage;

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("breakable"))
        //{
        //    other.GetComponent<pot>().Smash();
        //}
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    hit.GetComponent<Entity>().currentState = EntityState.stagger;
                    other.GetComponent<Entity>().Knock(hit, knockDuration, damage);
                }
                if (other.gameObject.CompareTag("Player") && other.isTrigger)
                {
                    /*if(other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockDuration, damage);
                    }*///For EVE
                    hit.GetComponent<Entity>().currentState = EntityState.stagger;
                    other.GetComponent<Entity>().Knock(hit, knockDuration, damage);
                }

                
            }
        }
    }
}
