using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashToTarget : RotateToTarget
{
    public float attackSpeed;
    private Quaternion rotation;
    public override void Update()
    {

        Vector2 direction = host.target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset - 90;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        StartCoroutine(SlashCoroutine());
    }
    IEnumerator SlashCoroutine()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        yield return new WaitForSeconds(attackSpeed);
    }
}
