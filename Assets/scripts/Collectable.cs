using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player"&& Input.GetKey("e"))

            OnCollect();
    }
    protected virtual void OnCollect()
    {
        collected=true;
    }
}
