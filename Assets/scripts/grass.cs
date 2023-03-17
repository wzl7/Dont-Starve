using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class grass : Collectable
{
    public Sprite empty1;
    public int grasskind;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = empty1;
           // UnityEngine.Debug.Log("Load");
            if(grasskind == 0 ) { GameManager.instance.grassnum += 1; }
            if (grasskind == 1) { GameManager.instance.flowernum += 1; }
            if (grasskind == 2) { GameManager.instance.stonenum += 1; }

            //     GameManager.instance.ShowText(grassnum+"flower", 20, Color.yellow,transform.position, Vector3.up * 30, 2.0f);
        }
    }
}
