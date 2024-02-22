using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabAnchor : Anchor
{
    public seed host;
    public override void FixedUpdate()
    {
        if (transform.position != target.position && host.currentState != EntityState.attack)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing);

        }
    }
}
