using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        StartCoroutine(LoadPhase("FirstStage"));
    }

    public void GoToCheckpoint()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        Player.transform.position = GameManager.Instance.Checkpoint.position;
        Debug.Log("Player foi para o checkpoint");
        CharacterController characterController = Player.GetComponent<CharacterController>();
        characterController.canWalk = true;

        StartCoroutine(LoadPhase(GameManager.Instance.nextStage.ToString()));
    }

    public void BackToTitle()
    {

        StartCoroutine(LoadPhase("TitleScreen"));
        GameManager.Instance.DestroyEnemies();
    }

    public IEnumerator LoadPhase(string phaseName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(phaseName);
    }

    public IEnumerator LoadCombatScene()
    {
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("CombatScene");

    }
}
