using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public float speed;
    public float angleOffset;
    public seed host;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        
            Vector2 direction = host.target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        
        
    }
}
