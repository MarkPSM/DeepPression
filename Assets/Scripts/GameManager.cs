using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Combate")]
    public EnemySpawn.Stage nextStage;
    public bool nextIsBoss;
    public EnemyData nextEnemy;

    [Header("Save")]
    public Transform Checkpoint;

    public GameObject enemiesList;


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

        //enemiesList = GameObject.Find("Enemies").GetComponent<GameObject>();

        Cursor.visible = false;
    }

    public void PrepareCombat(EnemySpawn.Stage stage)
    {
        nextStage = stage;
    }

    public void DestroyEnemies()
    {
        if(enemiesList != null)
        {
            Destroy(enemiesList);
            Debug.Log("Lista de inimigos destruída");
        }
    }
}
