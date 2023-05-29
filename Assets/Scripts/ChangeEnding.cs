using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChangeEnding : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (director == null) {
            director = GameObject.Find("ChaseSequence").GetComponent<PlayableDirector>();
        }
        if (player == null) {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeEndingValue(int value) {
        PersistentData.Instance.AdjustEndingCount(value);
    }

    public void PlayChaseSequence () {
        if (player.transform.localScale.x <0) {
            Vector3 temp = player.transform.localScale;
            temp.x *= -1f;
            player.transform.localScale = temp;
        }
        director.Play();
    }
}
