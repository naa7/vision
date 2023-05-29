using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicOnLoad : MonoBehaviour
{
    [SerializeField] AudioSource GameMusic;
    // Start is called before the first frame update
    void Start()
    {
        GameMusic = GetComponent<AudioSource>();
        GameMusic.clip = PersistentData.Instance.GetBGM();
        GameMusic.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
