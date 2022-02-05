using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    PlayerController player;
    Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (player.dead || player.health == 0)
        {
            string scene=SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scene);
            SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            GameObject.FindGameObjectWithTag("Player").transform.position = SpawnPoint.position;
        }
        

    }
    public void save()
    {
        int h = player.health;
        int c = player.coin;
        string l = SceneManager.GetActiveScene().name;
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        bool s = true;
        DB dB;
        dB = GameObject.FindGameObjectWithTag("GM").GetComponent<DB>();
        dB.DBinsert(h,c,l,x,y,z,s);
    }
}
