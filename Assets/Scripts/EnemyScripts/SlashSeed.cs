using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSeed : WeaponSeed
{
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
        }
        else if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            Attack();
        }
    }
    public override void Attack()
    {
        if (currentState != EntityState.attack)
        {
            ChangeState(EntityState.attack);
            try
            {
                activeWeapon.GetComponent<SlashToTarget>().angleOffset *= -1;
            }
            catch { };
        }


    }
}
