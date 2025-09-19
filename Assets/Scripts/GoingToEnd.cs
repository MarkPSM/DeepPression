using UnityEngine;

public class GoingToEnd : MonoBehaviour
{
    public LevelLoader LevelLoader;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LevelLoader.LoadPhase("EndScreen"));
        }

    }
}
