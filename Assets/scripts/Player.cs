using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class Player : Mover
{
    public float sanpoint = 10;
    public float maxsanpoint = 10;
    public float satiety = 10;
    public float maxsatiety = 10;
   // private Vector3 offest;
    bool islive=true;
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (islive)
        {
            UpdateMotor(new Vector3(x, y, 0));

        }
    }
    protected override void Death()
    {
        islive = false;
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    //    EditorSceneManager.LoadScene("main");
    }
    public void Respawn()
    {
        Heal(maxHitpoint);
        islive = true;  
        lastImmune=Time.time;  
    }

    protected override void ReceiveDamage(Damage dmg )
    {
        if (!islive) { return; }
        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitpointChange();
    }
    public void Heal(int healingAmount)
    {
        hitpoint += healingAmount;
        if (hitpoint > maxHitpoint)
        {
            hitpoint=maxHitpoint;
            GameManager.instance.OnHitpointChange();
        }

    }

}
