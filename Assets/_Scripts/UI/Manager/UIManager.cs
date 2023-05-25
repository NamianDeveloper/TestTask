using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ChangeTextAnimation[] counters;
    [SerializeField] private WebSocketHelper helper;

    [SerializeField] private TextMeshPro test;

    private float currentValue;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        helper.OnValueChange.AddListener(ChangeCounters);
    }

    public void ChangeCounters(float value)
    {
        if (value == 0) return;
        for (int i = 0; i < counters.Length; i++)
        {
            if (i > 5)
            {
                if (value.ToString().Length <= i)
                {
                    counters[i].StartAnimation("0"); 
                    continue;
                }
            }

            string charValue = value.ToString()[i].ToString();
            counters[i].StartAnimation(charValue);
        }
    }
}