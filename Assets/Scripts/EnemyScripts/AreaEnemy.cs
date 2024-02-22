using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntity : seed
{
    public Collider2D boundary;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
            && boundary.bounds.Contains(target.transform.position))
        {
            if (currentState == EntityState.idle || currentState == EntityState.walk && currentState != EntityState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
                ChangeState(EntityState.walk);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius
            || !boundary.bounds.Contains(target.transform.position))
        {
            ChangeState(EntityState.idle);
        }
    }
}
