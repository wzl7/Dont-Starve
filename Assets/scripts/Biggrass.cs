using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class Biggrass : Collectable
{
    public Sprite empty1;
    public int biggrasskind;
    protected float lastcollect;

    
protected override void OnCollect()
    {
        if (Time.time - lastcollect > 0.9f)
        {
            lastcollect = Time.time;
            if (GameManager.instance.tool.toolkind == biggrasskind)
            {
                bignum0 += 1;
                if (bignum0 == 4)
                {
                    bignum0 = 0;
                    collected = true;
                    GetComponent<SpriteRenderer>().sprite = empty1;
                    UnityEngine.Debug.Log("Load");
                    if (biggrasskind==0)
                    {
                        GameManager.instance.woodnum += 10;
                    }
                    else if (biggrasskind==1) 
                    {
                        GameManager.instance.stonenum += 5;
                    }
                    Destroy(gameObject);
                    //     GameManager.instance.ShowText(grassnum+"flower", 20, Color.yellow,transform.position, Vector3.up * 30, 2.0f);
                }
            }

        }
        

    }
}
