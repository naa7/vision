using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option_Two : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject dialoguePanel2;
    public TextMeshProUGUI Textfield;

    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    public void SetText(string text)
    {
        dialoguePanel.SetActive(false);
        dialoguePanel2.SetActive(true);
        Textfield.text = text;
    }

    public void RemovePanel()
    {

        dialoguePanel2.SetActive(false);

    }





    // Start is called before the first frame update
}