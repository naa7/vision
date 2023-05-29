using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    public void ToMenu()
    {
        PersistentData.Instance.SetAllValuesZero();
        SceneManager.LoadScene("Main Menu");
    }
}
