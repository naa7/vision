using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NextScene() {
        if (SceneManager.GetActiveScene().name == "Good Ending"){
            yield return new WaitForSeconds(65f);
            SceneManager.LoadScene("End Credits");
        } else if (SceneManager.GetActiveScene().name == "Bad Ending"){
            yield return new WaitForSeconds(45f);
            SceneManager.LoadScene("End Credits");
        } else if (SceneManager.GetActiveScene().name == "End Credits"){
            yield return new WaitForSeconds(110f);
            SceneManager.LoadScene("Leaderboard");
        }
    }

    public void moveToLeaderboard() {
        SceneManager.LoadScene("Leaderboard");
    }
}
