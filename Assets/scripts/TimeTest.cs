using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TimeEvent : UnityEvent<float> { }

public class TimeTest : MonoBehaviour
{
    public float timeInGame;//游戏内的时间,以秒为单位
    private float timer;
    private float santimer=30;

    public int period=120;//周期,以秒为单位

    [Header("Hours per second")]//游戏里每秒对应现实中多少小时
    private float perSec;

    [Header("Seconds per hour")]//现实中每小时是游戏里多少秒
    private float perHour;

    public float startTime;//最初的时间,以小时为单位

    public List<float> timePoints = new List<float>();
    public List<TimeEvent> timeEvents = new List<TimeEvent>();
    public int currentPos = 0;//用于获取timePoints和timeEvents中的元素，本来是要写if-else的

    void Start()
    {
        perSec = 24f / period;//计算游戏里一秒对应现实里多少小时

        perHour = period / 24f;//计算现实里一小时对应游戏里多少秒

        timer = startTime * (period / 24f);//注意startTime以小时为单位

        InitializeTimePoint();
    }

    void Update()
    {
        TimeFlow();
 
       // SendTimeEvent();
    }

    private void TimeFlow()//计时并循环
    {
        timer += Time.deltaTime;
        if (santimer < timer) 
        {
            santimer += 30f;
            GameManager.instance.Time2san();
            GameManager.instance.OnHitpointChange();
        }

        if (timer < period)//为了避免timeInGame超出所设周期，在此做判断
        {
            timeInGame = timer;
        }
        else//游戏内时间到了下一天
        {
            timeInGame = 0f;//重置游戏内时间
            santimer = 30f;
            timer = 0f;//重置计时器

            currentPos = 0;//重置i
        }
    }

    //private void SendTimeEvent()
    //{
    //    if (currentPos < timePoints.Count && timeInGame > timePoints[currentPos])
    //    {
    //        timeEvents[currentPos].Invoke(perHour);

    //        currentPos++;
    //    }
    //}

    private void InitializeTimePoint()//要添加元素就在这里加
    {
        timePoints.Add(5f * perHour);//传入时间

        timePoints.Add(17f * perHour);

    }

}
