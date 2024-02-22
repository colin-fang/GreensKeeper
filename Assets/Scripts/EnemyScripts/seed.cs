using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : Entity
{

    public Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public GameManager gManager;
    protected List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EntityState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        targets = gManager.players;
    }
    
    void FixedUpdate()
    {
        if(!target || target == null)
        {
            target = GetClosestTarget();
        };
        CheckDistance();
        
    }
    public Transform GetClosestTarget()
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target.transform;
                }
            }
        }
        return closestTarget;
    }


public virtual void CheckDistance()
    {
        
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EntityState.idle || currentState == EntityState.walk && currentState != EntityState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
                ChangeState(EntityState.walk);
            }
        }
    }

    public void ChangeState(EntityState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
