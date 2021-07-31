using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Method)]
public class GE : Attribute
{
    public int ID;

    public GE(int ID)
    {
        this.ID = ID;
    }

}
