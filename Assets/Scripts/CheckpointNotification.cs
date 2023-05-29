using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointNotification : MonoBehaviour
{
    public TextMeshProUGUI cpNotify; 
    private bool hasCollided = false;
    void Start()
    {
        cpNotify.enabled = false;
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Checkpoint") && !hasCollided)
        {
            cpNotify.enabled = true;
            hasCollided = true;
            Invoke("DisablePanel", 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            hasCollided = false;
        }
    }
    private void DisablePanel()
    {
        cpNotify.enabled = false;
    }
}
