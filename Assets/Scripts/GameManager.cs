using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Combate")]
    public EnemySpawn.Stage nextStage;
    public bool nextIsBoss;
    public EnemyData nextEnemy;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PrepareCombat(EnemySpawn.Stage stage)
    {
        nextStage = stage;
    }
}
