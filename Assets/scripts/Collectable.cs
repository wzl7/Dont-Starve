using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;
    protected int bignum0=0;
    protected int bignum1= 0;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player"&& Input.GetKeyDown(KeyCode.Space))

            OnCollect();
    }
    protected virtual void OnCollect()
    {
        collected=true;

    }
}
