using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : seed
{
    private void Start()
    {
        targets = gManager.enemies;
    }
    void FixedUpdate()
    {
        if (!target || target == null)
        {
            targets = gManager.enemies;
            target = GetClosestTarget();
        };

        CheckDistance();

    }
}
