using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

public class Tool : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    public int toolkind;
    private SpriteRenderer spriteRenderer;

    private float cooldown = 0.5f;
    private float lastSwing;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time-lastSwing>cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag=="Fighter")
        {
            if(coll.name!="player")
            {
              UnityEngine.Debug.Log(coll.name);
            }
            Damage dmg = new Damage()
            {
            damageAmount=damagePoint,
            origin = transform.position,
            pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
       
    }
    


    private void Swing()
    {
        UnityEngine.Debug.Log("swing");
    }
}
