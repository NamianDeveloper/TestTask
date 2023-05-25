using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MenuButtonClick : MonoBehaviour
{
    [SerializeField] private WebSocketHelper _webSocketHelper;
    [SerializeField] private GameObject menuWindow;

    [SerializeField] private bool isStart;
    private void Start()
    {
        if(!isStart)
            return;

        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            _webSocketHelper.OnValueChange.Invoke(_webSocketHelper.GetCurrentValue);
        });
    }

    public void Click(bool active)
    {
        menuWindow.SetActive(active);
    }
}