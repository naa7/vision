using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC2MOVEI2 : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
    //public GameObject option1;
    //public GameObject option2;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";

    }
    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        //option1.SetActive(false);
        dialoguePanel.SetActive(false);

    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);


        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
            //ShowChoices();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!dialoguePanel.activeInHierarchy)
                {
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());
                }
                else if (dialogueText.text == dialogue[index])
                {
                    NextLine();
                }

            }
            if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
            {
                RemoveText();
            }

            if (dialogueText.text == dialogue[index])
            {
                contButton.SetActive(true);

            }
        }
    

}
