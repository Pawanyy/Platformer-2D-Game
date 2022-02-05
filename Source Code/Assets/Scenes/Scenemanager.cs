using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemanager : MonoBehaviour
{
    Transform SpawnPoint;
    PlayerController player;
    public bool dontDestroy = false;
    public bool load_ = false;
    public int h = 0;
    public int c=0;
    public string l="";
    public Vector3 pos = new Vector3(0,0,0);
    void Update()
    {
        if (dontDestroy)
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("SC"));
        }
        if (load_)
        {
            DB dB;
            dB = GameObject.FindGameObjectWithTag("SC").GetComponent<DB>();
            dB.dbRead();
            Debug.Log("load");
            h = dB.h;
            c = dB.c;
            l = dB.l;
            pos = dB.pos;
            if (load_)
            {
                SceneManager.LoadScene(l);
                load_ = false;
            }
        }
    }
    public void load()
    {
        
        SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        player.health = h;
        player.coin = c;
        player.transform.position = pos; 
        Debug.Log("loaded");
        Destroy(gameObject);

    }
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name != "mainmenu")
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            load();
        }
        
    }

}
