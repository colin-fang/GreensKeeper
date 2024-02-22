using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public Transform teamPlayerParent;
    public string teamPlayerTag;
    public Transform teamEnemyParent;
    public string teamEnemyTag;


    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] playersTag = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] enemiesTag = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in playersTag)
        {
            players.Add(obj);
        }
        foreach (GameObject obj in enemiesTag)
        {
            enemies.Add(obj);
        }
    }
    
}
