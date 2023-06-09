using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public float triggerLength = 1;
    public float chaseLength = 300;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
    private Transform target;   //设置追踪目标的位置
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    public ContactFilter2D filter;


    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (chasing = Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                chasing = true;
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }

            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }


        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            if (hits[i].tag == "Fighter" && hits[i].name=="Player")
            {
                collidingWithPlayer = true;
            }
            hits[i] = null;
        }


    }
    protected override void Death()
    {
        Destroy(gameObject);
        //杀死敌人得到的东西
    }
}