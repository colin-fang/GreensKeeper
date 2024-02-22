using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabToTarget : RotateToTarget
{
    public float attackSpeed;
    public float stabSpeed;
    public Rigidbody2D myRigidBody;
    public override void Update()
    {
        
            Vector2 direction = host.target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        if(host.currentState == EntityState.attack)
        {
            StartCoroutine(StabCoroutine());
        }

    }
    IEnumerator StabCoroutine()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, host.target.transform.position, stabSpeed * Time.deltaTime);
        myRigidBody.MovePosition(temp);
        yield return new WaitForSeconds(attackSpeed);
    }
}
