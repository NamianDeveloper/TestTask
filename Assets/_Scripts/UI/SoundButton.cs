using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private GameObject soundObject;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private bool isActive = true;

    public void Click(bool deleteSound)
    {
        
        isActive = !isActive;

        _textMeshProUGUI.text = isActive ? "ON" : "OFF";

        if (deleteSound)
        {
            soundObject.SetActive(isActive);
        }
    }
}
