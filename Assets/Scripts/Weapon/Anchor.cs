using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (transform.position != target.position)
        {
          transform.position = Vector3.Lerp(transform.position, target.position, smoothing);

        }
    }
}
