using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    private Vector3 originalsize;
    protected BoxCollider2D boxCollider;

    protected Vector3 moveDelta;

    protected RaycastHit2D hit;
    protected float ySpeed = 1.0f;
    protected float xSpeed = 1.0f;


    protected virtual void Start()
    {
        originalsize = transform.localScale;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 inpuy)
    {
        moveDelta =new Vector3(inpuy.x*xSpeed,inpuy.y*ySpeed,0);

        if (moveDelta.x > 0)
            transform.localScale = originalsize;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(originalsize.x*-1, originalsize.y, originalsize.z);
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }



    }

}
