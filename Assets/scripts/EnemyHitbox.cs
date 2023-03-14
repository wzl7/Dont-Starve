using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int damage;
    public int damagePoint = 1;

    public float pushForce;
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag=="Fighter"&&coll.name=="Player")
        {
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
