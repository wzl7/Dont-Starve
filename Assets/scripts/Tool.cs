using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

public class Tool : Collidable
{
    public int[] damagePoint = {1,1,3};
    public int toolkind=0;
    private SpriteRenderer spriteRenderer;


    private Animator anim;
    private float cooldown = 0.3f;
    private float lastSwing;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
        GameManager.instance.Tryswitchtool();
    }
    protected override void OnCollide(Collider2D coll)
    {

        if (coll.tag == "Fighter") //coll.tag == "Fighter"
        {
            if (coll.name == "enemy_0")
            {
                Damage dmg = new Damage()
                {
                    damageAmount = damagePoint[toolkind],
                    origin = transform.position,
                };
                coll.SendMessage("ReceiveDamage", dmg);
            }
        }

    }
     public void swichTool(int num)
    {
        spriteRenderer.sprite = GameManager.instance.toolSprites[num];
    }


    private void Swing()
    {
        anim.SetTrigger("Swing");
    }
}
