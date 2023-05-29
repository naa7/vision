using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScrapCollected : MonoBehaviour
{
   [SerializeField] GameObject FoodScrapTiggered;
    // Start is called before the first frame update
    void Start()
    {
        FoodScrapTiggered = GameObject.FindGameObjectWithTag("CollectController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D() {
        FoodScrapTiggered.GetComponent<CollectablesController>().IncreaseFoodScrapCount();
        this.gameObject.SetActive(false);
    }
}
