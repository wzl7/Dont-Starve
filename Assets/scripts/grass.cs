using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class grass : Collectable
{
    public Sprite empty1;
    public int grassnum = 1;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = empty1;
            UnityEngine.Debug.Log("Load");

            //    GameManager.instance.ShowText(grassnum+"flower", 20, Color.yellow,transform.position, Vector3.up * 30, 2.0f);
        }
    }
}
