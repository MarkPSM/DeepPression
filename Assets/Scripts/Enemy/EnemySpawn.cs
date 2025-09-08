using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public bool isBoss;

    public EnemyData enemy;

    [Header("Refer�ncias")]
    public CombatManager combatManager;

    [Header("Inimigos por Regi�o")]
    public EnemyData[] fstStageEnemies;
    public EnemyData fstStageBoss;

    public EnemyData[] sndStageEnemies;
    public EnemyData sndStageBoss;

    public EnemyData[] trdStageEnemies;
    public EnemyData trdStageBoss;

    [Header("UI Portraits")]
    public Image portrait;
    public Image bossPortrait;

    public enum Stage
    {
        FirstStage,
        SecondStage,
        ThirdStage
    }

    public Stage actualStage;

    void Awake()
    {
        actualStage = GameManager.Instance.nextStage;
        isBoss = GameManager.Instance.nextIsBoss;

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
            Debug.LogWarning("Nenhum inimigo configurado para essa regi�o");
            return;
        }

        enemy = pool[Random.Range(0, pool.Length)];
        portrait.sprite = enemy.portrait;

        combatManager.SetupEnemyUI(enemy);

        Debug.Log($"{enemy.name} spawnado!");
    }

    public void BossSpawn(Stage stage)
    {
        var actualBoss = fstStageBoss;

        switch (stage)
        {
            case Stage.FirstStage:
                actualBoss = fstStageBoss;
                break;
            case Stage.SecondStage:
                actualBoss = sndStageBoss;
                break;
            case Stage.ThirdStage:
                actualBoss = trdStageBoss;
                break;
        }

        combatManager.SetupEnemyUI(enemy);

        Debug.Log($"Boss {actualBoss} spawnado!");
    }
}
