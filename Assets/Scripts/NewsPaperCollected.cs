using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperCollected : MonoBehaviour
{
    [SerializeField] GameObject NewsPaperTiggered;

    void Start()
    {
        NewsPaperTiggered = GameObject.FindGameObjectWithTag("CollectController");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D() {
        NewsPaperTiggered.GetComponent<CollectablesController>().IncreaseNewspaperCount();
        this.gameObject.SetActive(false);
    }
}
