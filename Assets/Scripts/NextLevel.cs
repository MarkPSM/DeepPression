using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public LevelLoader LevelLoader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelLoader.LoadPhase("SecondStage");
    }
}
