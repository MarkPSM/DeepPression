using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public bool isBoss;

    [Header("Inimigos por Região")]
    public EnemyData[] fstStageEnemies;
    public EnemyData fstStageBoss;

    public EnemyData[] sndStageEnemies;
    public EnemyData sndStageBoss;

    public EnemyData[] trdStageEnemies;
    public EnemyData trdStageBoss;

    [Header("UI Portraits")]
    public Image[] portraits;

    [Header("Inimigos Spawnados")]
    public List<EnemyData> spawnedEnemies = new List<EnemyData>();
    public int quantity;

    public enum Stage
    {
        FirstStage,
        SecondStage,
        ThirdStage
    }

    public Stage actualStage;

    void Start()
    { 
        if (isBoss == false)
            NormalSpawn(actualStage);

        if (isBoss == true)
            BossSpawn(actualStage);
    }

    public void NormalSpawn(Stage stage)
    {
        EnemyData[] pool = null;

        switch (stage)
        {
            case Stage.FirstStage:
                pool = fstStageEnemies;
                break;

            case Stage.SecondStage:
                pool = sndStageEnemies;
                break;

            case Stage.ThirdStage:
                pool = trdStageEnemies;
                break;
        }

        if (pool == null || pool.Length == 0)
        {
            Debug.LogWarning("Nenhum inimigo configurado para essa região");
            return;
        }

        spawnedEnemies.Clear();

        quantity = Random.Range(1, 4);

        for (int i = 0; i < quantity; i++)
        {
            EnemyData enemy = pool[Random.Range(0, pool.Length)];
            spawnedEnemies.Add(enemy);

            if (i < portraits.Length)
                portraits[i].sprite = enemy.portrait;
        }

        for (int i = quantity; i < portraits.Length; i++)
        {
            portraits[i].sprite = null;
        }

        Debug.Log($"Spawnados {quantity} inimigos");
    }

    public void BossSpawn(Stage stage)
    {
        spawnedEnemies.Clear();

        var actualBoss = fstStageBoss;

        switch (stage)
        {
            case Stage.FirstStage:
                spawnedEnemies.Add(fstStageBoss);
                actualBoss = fstStageBoss;
                break;
            case Stage.SecondStage:
                spawnedEnemies.Add(sndStageBoss);
                actualBoss = sndStageBoss;
                break;
            case Stage.ThirdStage:
                spawnedEnemies.Add(trdStageBoss);
                actualBoss = trdStageBoss;
                break;
        }

        portraits[1].sprite = null;
        portraits[2].sprite = null;

        Debug.Log($"Boss {actualBoss} spawnado");
    }
}
