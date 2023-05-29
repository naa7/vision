using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public const int NUM_HIGH_SCORES = 5;
    public const string NAME_KEY = "HSPlayerName";
    public const string COLLECTABLE_KEY = "CollectableAmount";
    public const string TIME_KEY = "FastestRun";
    [SerializeField] string playerName;
    [SerializeField] int collectableCount;
    [SerializeField] float playerTimeSpent;

    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] collectableTexts;
    [SerializeField] Text[] timeTexts;
    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        collectableCount = PersistentData.Instance.GetNewpaperCount() + PersistentData.Instance.GetScrapCount();
        playerTimeSpent = PersistentData.Instance.GetTimeSpent();

        if (playerTimeSpent != 0) {
            SavePlayerScore();
        }
        DisplayHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerScore() {
        for (int i = 1; i <= NUM_HIGH_SCORES; i++) {
            string currentNameKey = NAME_KEY + i;
            string currentCollectableKey = COLLECTABLE_KEY + i;
            string currentTimeKey = TIME_KEY + i;

            if (PlayerPrefs.HasKey(currentTimeKey)) {
                float currentTime = PlayerPrefs.GetFloat(currentTimeKey);
                if (playerTimeSpent < currentTime) {
                    float tempTime = currentTime;
                    string tempName = PlayerPrefs.GetString(currentNameKey);
                    int tempCollectable = PlayerPrefs.GetInt(currentCollectableKey);


                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentCollectableKey, collectableCount);
                    PlayerPrefs.SetFloat(currentTimeKey, playerTimeSpent);

                    playerName = tempName;
                    collectableCount = tempCollectable;
                    playerTimeSpent = tempTime;
                }
            }
            else {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentCollectableKey, collectableCount);
                PlayerPrefs.SetFloat(currentTimeKey, playerTimeSpent);
                return;
            }              
        }
    }

    public void DisplayHighScores() {
        for (int i = 0; i < NUM_HIGH_SCORES; i++) {
            nameTexts[i].text = "Player: " + PlayerPrefs.GetString(NAME_KEY + (i+1));
            collectableTexts[i].text = "Total Collectables: " + PlayerPrefs.GetInt(COLLECTABLE_KEY + (i+1)).ToString() + "/21";
            timeTexts[i].text = "Time Spent: " + (Mathf.Round(PlayerPrefs.GetFloat(TIME_KEY + (i+1)))).ToString() + " Seconds";
        }
    }
}
