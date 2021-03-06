﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject level;
    public GameObject player;
    public GameObject spawner;
    public GameObject spawner2;
    public GameObject enemy;
    public GameObject weapon;
    public GameObject weapon2;

    public int enemyHealth;
    public int enemyDamage;
    public int playerHealth;
    public int playerDamage;
    public float spawnRate;

    float timer;

    // Use this for initialization
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.GetComponent<Controller>().health <= 0)
        {
            player.GetComponent<Controller>().death();
            spawner.GetComponent<Spawner>().restart();
            spawner2.GetComponent<Spawner>().restart();
            //enemy.GetComponent<EnemyController>().restart();
            for (int i = 0; i < spawner.GetComponent<Spawner>().listOfEnemies.Count; i++)
            {
                if (spawner.GetComponent<Spawner>().listOfEnemies[i] != null)
                {
                    Destroy(spawner.GetComponent<Spawner>().listOfEnemies[i]);
                    spawner.GetComponent<Spawner>().listOfEnemies.RemoveAt(i);
                }


            }
            for (int i = 0; i < spawner2.GetComponent<Spawner>().listOfEnemies.Count; i++)
            {
                if (spawner2.GetComponent<Spawner>().listOfEnemies[i] != null)
                {
                    Destroy(spawner2.GetComponent<Spawner>().listOfEnemies[i]);
                    spawner2.GetComponent<Spawner>().listOfEnemies.RemoveAt(i);
                }


            }

            timer += Time.deltaTime;
            if (timer >= 3)
            {
                player.gameObject.SetActive(true);
                player.GetComponent<Controller>().money = 0;
                player.GetComponent<Controller>().totalHealth = 30;

                weapon.GetComponent<Weapon>().damage = playerDamage;
                weapon2.GetComponent<Weapon>().damage = playerDamage;
                //enemy.SetActive(true);
                spawner.GetComponent<Spawner>().enemyCount = 0;
                spawner.gameObject.SetActive(true);
                spawner2.GetComponent<Spawner>().enemyCount = 0;
                spawner2.gameObject.SetActive(true);

                enemy.gameObject.SetActive(true);
                enemy.GetComponent<EnemyController>().health = enemyHealth;
                enemy.GetComponent<EnemyController>().damage = enemyDamage;

                level.GetComponent<PlayerLevel>().exp = 0;
                level.GetComponent<PlayerLevel>().level = 1;
                level.GetComponent<PlayerLevel>().expLeft = 1000;
                spawner.GetComponent<Spawner>().spawnInt = spawnRate;
                //enemy.GetComponent<EnemyController>().health = enemyHealth;
                player.GetComponent<Controller>().health = playerHealth;
                timer = 0;
            }
        }
    }
}
