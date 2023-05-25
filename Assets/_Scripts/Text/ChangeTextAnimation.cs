using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ChangeTextAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newValueTMPro;
    [SerializeField] private TextMeshProUGUI currentValueTMPro;
    [SerializeField] private Transform parentTransform;
    
    private int currentValue = 0;
    private int newValue = 0;

    public void StartAnimation(string newValueChar)
    {
        if (newValueChar == ",")
            return;

        int newValue = Convert.ToInt32(newValueChar);

        if (currentValue == newValue)
            return;
        
        this.newValue = newValue;
        
        newValueTMPro.text = newValue.ToString();


        parentTransform.DOLocalMove(new Vector3(0, -200), 1)
            .OnComplete(() =>
            {
                parentTransform.localPosition = new Vector3();
                currentValue = newValue;
                currentValueTMPro.text = currentValue.ToString();
            });
    }
    
}