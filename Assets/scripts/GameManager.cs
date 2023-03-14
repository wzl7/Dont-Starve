using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> health;

    public Player player;
    public FloatingTextManager floatingTextManager;

    public int grassnum;
    // public int health;
    public FloatingText floatingText;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
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
