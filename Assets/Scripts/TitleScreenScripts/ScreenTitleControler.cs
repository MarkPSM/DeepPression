using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTitleControler : MonoBehaviour
{

    public Animator transition;

    public GameObject LevelLoader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DeleteLoader());
    }

    // Update is called once per frame
    void Update()
    {
        string ActualScene = SceneManager.GetActiveScene().name;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        if (LevelLoader != null)
            LevelLoader.SetActive(true);
        StartCoroutine(LoadPhase("GameScene"));
        LevelLoader.SetActive(true);
    }

    public IEnumerator LoadPhase (string phaseName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(phaseName);
    }

    private IEnumerator DeleteLoader()
    {
        yield return new WaitForSeconds(1f);

        if (LevelLoader != null)
        {
            LevelLoader.SetActive(false);

            Debug.Log("Loader deleted");
        }
    }
}
