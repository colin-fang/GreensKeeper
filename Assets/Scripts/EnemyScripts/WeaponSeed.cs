using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSeed : seed
{
    public GameObject activeWeapon;
     public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EntityState.idle || currentState == EntityState.walk || currentState == EntityState.attack && currentState != EntityState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
                ChangeState(EntityState.walk);
            }
        }else if(Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            Attack();
        }
    }
    public virtual void Attack()
    {
        if(currentState != EntityState.attack)
        {
            ChangeState(EntityState.attack);
        }


    }
}
