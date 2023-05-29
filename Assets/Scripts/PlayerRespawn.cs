using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint") || collision.CompareTag("BaseCheckpoint"))
        {
            Debug.Log("Checkpoint");
            respawnPoint = collision.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("KillZone"))
        {
            Debug.Log("Death");
            Respawn();
        }

        if (collision.collider.CompareTag("NextScene"))
        {
            if (SceneManager.GetActiveScene().name == "Underground City") {
                SceneManager.LoadScene("Sky City");
            } else if (SceneManager.GetActiveScene().name == "Sky City") {
                if (PersistentData.Instance.GetEndingCount() >= 0) {
                    SceneManager.LoadScene("Good Ending");
                } else if (PersistentData.Instance.GetEndingCount() < 0 ) {
                    SceneManager.LoadScene("Bad Ending");
                }
            }
            PersistentData.Instance.AddTimeSpent();
        }

        if (PersistentData.Instance.GetScrapCount() >= 5 && PersistentData.Instance.GetNpcCheck()) {
            if (collision.collider.name == "Inv Collider 2") {
                GameObject.Find("Inv Collider 2").SetActive(false);
            }
        }

        if (PersistentData.Instance.GetNpcCheck2()) {
            if (collision.collider.name == "Inv Collider 1") {
                GameObject.Find("Inv Collider 1").SetActive(false);
            }
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
