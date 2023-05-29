using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public GameObject background;
    public Sprite newSprite;
    public GameObject continueButton;
    public GameObject returnButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(true);
        returnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change() {
        background.GetComponent<SpriteRenderer>().sprite = newSprite; 
        continueButton.SetActive(false);
        returnButton.SetActive(true);
    }
}
