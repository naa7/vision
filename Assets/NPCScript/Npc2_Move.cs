
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Npc2_Move : MonoBehaviour
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
    [SerializeField] GameObject myplayer;



    void Start()
    {
        dialogueText.text = "";
        //option1.SetActive(false);
        //option2.SetActive(false);

        if (myplayer == null)
        {
            myplayer = GameObject.FindGameObjectWithTag("Player");
        }

        playerIsClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
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

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        //option1.SetActive(false);
        dialoguePanel.SetActive(false);

    }
    //public void ShowChoices()
    //{
    //    option1.SetActive(true);
    //    option2.SetActive(true);
    //}


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

    public void GuardIteraction() {
        PersistentData.Instance.SetNpcCheck();
    }

    public void GuardIteraction2() {
        PersistentData.Instance.SetNpcCheck2();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
        
        }
    }
}