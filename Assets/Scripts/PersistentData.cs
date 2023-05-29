using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] public int NewspaperCount;
    [SerializeField] public int NewsCount;
    [SerializeField] public int ScrapCount;
    [SerializeField] public int EndingCount;
    [SerializeField] string playerName;
    [SerializeField] float timeSpent = 0.0f;
    [SerializeField] bool npcCheck = false;
    [SerializeField] bool npcCheck2 = false;
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioClip BGM1;
    [SerializeField] AudioClip BGM2;
    

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (BGM == null) {
            BGM = BGM1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NewspaperCount = 0;
        NewsCount = 0;
        ScrapCount = 0;
        timeSpent = 0.0f;
        EndingCount = 0;
        playerName = "";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetAllValuesZero(){
        NewspaperCount = 0;
        NewsCount = 0;
        ScrapCount = 0;
        timeSpent = 0.0f;
        EndingCount = 0;
        playerName = "";
        npcCheck = false;
    }

    public void SetNewspaperCount(int amount)
    {
        NewspaperCount = amount;
    }
    public void SetNewsCount(int amount)    //this is for displaying newspaper ui
    {
        NewsCount = amount;
    }

    public void SetScrapCount(int amount)
    {
        ScrapCount = amount;
    }

    public void AdjustEndingCount(int amount)
    {
        EndingCount += amount;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void AddTimeSpent()
    {
        timeSpent += Time.timeSinceLevelLoad;
    }

    public void SetTimeSpentZero() {
        timeSpent = 0.0f;
    }

    public void SetBGM(int selection) {
        if (selection == 0) {
            BGM = BGM1;
        } else if (selection == 1) {
            BGM = BGM2;
        }
    }

    public void SetNpcCheck() {
        npcCheck = true;
    }

    public void SetNpcCheck2() {
        npcCheck2 = true;
    }

    public bool GetNpcCheck2() {
        return npcCheck2;
    }

    public bool GetNpcCheck() {
        return npcCheck;
    }

    public int GetNewpaperCount()
    {
        return NewspaperCount;
    }
    public int GetNewsCount()   //for news ui
    {
        return NewsCount;
    }

    public int GetScrapCount()
    {
        return ScrapCount;
    }

    public int GetEndingCount()
    {
        return EndingCount;
    }

    public string GetName()
    {
        return playerName;
    }

    public float GetTimeSpent()
    {
        return timeSpent;
    }

    public AudioClip GetBGM()
    {
        return BGM;
    }
}
