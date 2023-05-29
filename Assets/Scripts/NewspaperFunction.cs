using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperFunction : MonoBehaviour
{
    [SerializeField] public NewsUIWindow newsUI;
    [SerializeField] public int newspaperToCollect;
    public int newspaperCount;
    private bool isOpened = false;

    void Update()
    {
        newspaperCount = PersistentData.Instance.GetNewsCount();
        if (newspaperCount == newspaperToCollect && !isOpened)
        {
            NewspaperOpen();
            isOpened = true;
        }
    }
    public void NewspaperOpen()
    {
        Debug.Log("Newspaper Open!");
        newsUI.gameObject.SetActive(true);
        newsUI.closeButton.onClick.AddListener(CloseButtonClicked);
    }
    public void CloseButtonClicked()
    {
        Debug.Log("Newspaper Close!");
        newsUI.gameObject.SetActive(false);
    }
}
