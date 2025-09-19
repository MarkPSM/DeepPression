using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public LevelLoader LevelLoader;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.DestroyEnemies();
            StartCoroutine(LevelLoader.LoadPhase("SecondStage"));
        }

    }
}
