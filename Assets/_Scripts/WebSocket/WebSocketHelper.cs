using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using WebSocketSharp;
using UnityEngine.UI;

public class WebSocketHelper : MonoBehaviour
{
    [SerializeField] private Image connectionImage;

    public float GetCurrentValue
    {
        get => currentValue;
        set { currentValue = value; }
    }

    private float currentValue = 00000.00f;

    private WebSocket ws;

    [HideInInspector] public UnityEvent<float> OnValueChange;

    void Awake()
    {
        Observable.Interval(TimeSpan.FromSeconds(3))
            .TakeWhile(_ => gameObject != null)
            .Subscribe(_ =>
            {
                ws = new WebSocket("ws://185.246.65.199:9090/ws");

                ws.OnMessage += EventMessege;

                ws.Connect();

                PingConnection();
            });
    }

    private void EventMessege(object sender, MessageEventArgs e)
    {
        var json = JsonUtility.FromJson<MyJsonClass>(e.Data);

        GetCurrentValue = json.value;
        Debug.Log("Получил ответ: " + json.value);
    }

    private void PingConnection()
    {
        if (ws.ReadyState == WebSocketState.Open)
        {
            Debug.Log("Соединение установлено");
            connectionImage.color = Color.green;
        }
        else
        {
            Debug.Log("Соединение потеряно");
            connectionImage.color = Color.red;
        }
    }

    void OnDestroy()
    {
        ws.Close();
    }

    // Пример класса для десериализации полученного json
    [System.Serializable]
    public class MyJsonClass
    {
        public float value;
    }
}