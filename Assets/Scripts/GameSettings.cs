using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] InputField username;
    [SerializeField] Dropdown musicOptionDropdown;
    [SerializeField] int level;


    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;

        if (username == null && SceneManager.GetActiveScene().name == "Main Menu") {
            username = GameObject.Find("Name").GetComponent<InputField>();
            username.text = PersistentData.Instance.GetName();
            AudioListener.volume = .5f;
        }

        if (SceneManager.GetActiveScene().name == "Settings") {
            if (volumeSlider == null) {
                volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
            }

            if (musicOptionDropdown == null) {
                musicOptionDropdown = GameObject.Find("MenuMusicOption").GetComponent<Dropdown>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayGame()
    {
        string name = username.text;
        PersistentData.Instance.SetName(name);
        SceneManager.LoadScene("Cutscene1");
    }

    public void GoToControls() {
        SceneManager.LoadScene("Controls");
    }

    public void GoToMain() {
        PersistentData.Instance.SetAllValuesZero();
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToSettings() {
        SceneManager.LoadScene("Settings");
    }

    public void GoToCredits() {
        SceneManager.LoadScene("End Credits");
    }

    public void GoToUndergroundCity() {
        SceneManager.LoadScene("Underground City");
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
    }

    public void ChangeBGM() {
        PersistentData.Instance.SetBGM(musicOptionDropdown.value);
    }

    public void ResetLeaderboard() {
        PlayerPrefs.DeleteAll();
    }
}
