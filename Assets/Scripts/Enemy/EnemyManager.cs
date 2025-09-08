using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Enemy;

    public GameObject[] enemies;

    public EnemyController enemyController;

    public bool isDead;

    public int actualID;

    void Awake()
    {
        if (Enemy == null)
        {
            Enemy = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        enemies = Enemy.GetComponentsInChildren<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                DontDestroyOnLoad(enemy);
            }
            else
            {
                Destroy(enemy);
            }
        }

        if (enemies != null)
        {
            GameObject inimigoAtual = enemies[actualID];

            enemyController = GameObject.Find(inimigoAtual.name).GetComponent<EnemyController>();

            enemyController.isDead = isDead;
        }
    }



}
