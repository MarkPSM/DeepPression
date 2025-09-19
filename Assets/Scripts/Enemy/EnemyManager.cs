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

    public bool isBoss;

    public int actualID;

    void Start()
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

        Transform[] children = GetComponentsInChildren<Transform>(true);
        List<GameObject> objs = new List<GameObject>();

        foreach (Transform child in children)
        {
            if (child != this.transform)
                objs.Add(child.gameObject);
        }

        enemies = objs.ToArray();

        //foreach (GameObject enemy in enemies)
        //{
        //    if (enemy != null)
        //    {
        //        DontDestroyOnLoad(enemy);
        //    }
        //}

        if (enemies != null)
        {
            GameObject inimigoAtual = enemies[actualID];

            enemyController = GameObject.Find(inimigoAtual.name).GetComponent<EnemyController>();

            enemyController.isDead = isDead;

            if (isDead)
            {
                Debug.Log("Inimigo " + actualID + " morto");
            }
        } 
        else
        {
            Debug.Log("enemies null");
        }
    }



}
