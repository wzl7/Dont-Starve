using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    public List<Sprite> playerSprites;
    public List<Sprite> toolSprites;
    public List<int> health;

    public Player player;
    public FloatingTextManager floatingTextManager;
    public Tool tool;
    public RectTransform hitpointBar;
    public Animator deathMenuAnim;
    public RectTransform sanpointBar;
    public RectTransform satietyBar;

    //背包    
    public int grassnum=0;
    public int woodnum = 0;
    public int stonenum = 0;
    public int flowernum = 0;
            
    // public int health;
    public FloatingText floatingText;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public  void OnHitpointChange()
    {
        float ratio0 = (float)player.hitpoint / player.maxHitpoint;
        hitpointBar.localScale=new Vector3(1, ratio0, 1);
        float ratio1 = (float)player.sanpoint / player.maxsanpoint;
        sanpointBar.localScale = new Vector3(1, ratio1, 1);
        float ratio2 = (float)player.satiety / player.maxsatiety;
        satietyBar.localScale = new Vector3(1, ratio2, 1);
    }

    public void Respawn()
    {
        deathMenuAnim.SetTrigger("Hide");
        player.Respawn();
        UnityEngine.Debug.Log("Load");

        SceneManager.LoadScene("main");


    }
    public void Time2san()
    {
        player.sanpoint -= 1;
        player.satiety -= 1;   
    }
    //public int toolkind()
    //{
    //    if (tool.toolkind ==0)
    //    {
    //        return 1;
    //    }
    //}

    public void Tryswitchtool()
    {
        if (Input.GetKey("1"))//切换条件
        {
            tool.toolkind = 0; //切换结果
            UnityEngine.Debug.Log("1");

        }
        else if (Input.GetKey("2"))//切换条件
        {
            tool.toolkind = 1;//切换结果
        }
        else if (Input.GetKey("3"))//切换条件
        {
            tool.toolkind = 2;//切换结果
        }
        tool.swichTool(tool.toolkind);

    }


    public void SaveState()
    {
        UnityEngine.Debug.Log("Save");
    }
    public void LoadState()
    {
        UnityEngine.Debug.Log("Load");
    }
}
