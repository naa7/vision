using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelName : MonoBehaviour
{
    [SerializeField] float displayTimer;
    public TextMeshProUGUI cityName; 
    void Start()
    {
        cityName.enabled = true;
        Invoke("DisablePanel", displayTimer);
    }

    private void DisablePanel()
    {
        cityName.enabled = false;
    }
}
