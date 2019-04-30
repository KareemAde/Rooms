using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : GameObjects
{
    protected override void CheckPass()
    {
        pass = space.gameObject.layer;
    }
}
