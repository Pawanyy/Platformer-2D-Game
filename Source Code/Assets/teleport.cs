using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    PlayerController player;

    public int h = 0;
    public int c = 0;
    public Transform SpawnPoint;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            h = player.health;
            c = player.coin;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("l2");
            
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name.Equals("l2"))
        {
            SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            GameObject.FindGameObjectWithTag("Player").transform.position = SpawnPoint.position;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.health = h;
            player.coin = c;

            Destroy(gameObject);
        }
        
    }

}
