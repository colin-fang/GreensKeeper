using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSeed : seed
{

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EntityState.idle || currentState == EntityState.walk && currentState != EntityState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
                //ChangeState(EntityState.walk);
            }
        }else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }
            
        }
    }

    private void ChangeGoal()
    {
        if(currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }

}
