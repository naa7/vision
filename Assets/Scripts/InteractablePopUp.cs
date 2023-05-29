using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractablePopUp : MonoBehaviour
{
    public TextMeshProUGUI PopUp; 
    private bool hasCollided = false;
    void Start()
    {
        PopUp.enabled = false;
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Interactable") && !hasCollided)
        {
            PopUp.enabled = true;
            hasCollided = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            PopUp.enabled = false;
            hasCollided = false;
        }
    }
}
