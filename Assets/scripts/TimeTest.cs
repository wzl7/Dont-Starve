using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TimeEvent : UnityEvent<float> { }

public class TimeTest : MonoBehaviour
{
    public float timeInGame;//��Ϸ�ڵ�ʱ��,����Ϊ��λ
    private float timer;
    private float santimer=30;

    public int period=120;//����,����Ϊ��λ

    [Header("Hours per second")]//��Ϸ��ÿ���Ӧ��ʵ�ж���Сʱ
    private float perSec;

    [Header("Seconds per hour")]//��ʵ��ÿСʱ����Ϸ�������
    private float perHour;

    public float startTime;//�����ʱ��,��СʱΪ��λ

    public List<float> timePoints = new List<float>();
    public List<TimeEvent> timeEvents = new List<TimeEvent>();
    public int currentPos = 0;//���ڻ�ȡtimePoints��timeEvents�е�Ԫ�أ�������Ҫдif-else��

    void Start()
    {
        perSec = 24f / period;

        perHour = period / 24f;

        timer = startTime * (period / 24f);
        InitializeTimePoint();
    }

    void Update()
    {
        TimeFlow();
    }

    private void TimeFlow()//��ʱ��ѭ��
    {
        timer += Time.deltaTime;
        if (santimer < timer) 
        {
            santimer += 30f;
            GameManager.instance.Time2san();
            GameManager.instance.OnHitpointChange();
        }

        if (timer < period)//Ϊ�˱���timeInGame�����������ڣ��ڴ����ж�
        {
            timeInGame = timer;
        }
        else//��Ϸ��ʱ�䵽����һ��
        {
            timeInGame = 0f;//������Ϸ��ʱ��
            santimer = 30f;
            timer = 0f;//���ü�ʱ��

            currentPos = 0;//����i
        }
    }

    private void InitializeTimePoint()//Ҫ���Ԫ�ؾ��������
    {
        timePoints.Add(5f * perHour);//����ʱ��

        timePoints.Add(17f * perHour);

    }

}
