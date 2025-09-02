using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [Header("References")]
    public CharacterManager characterManager;
    public EnemySpawn enemySpawn;

    [Header("Speed")]
    [SerializeField] private float speedFillRate;
    public Slider playerSpeedBar;
    public Slider enemySpeedBar;
    public Slider bossSpeedBar;
    [SerializeField] private float enemySpeed;
    public float bossSpeed;

    [Header("Health")]
    public Slider enemyHealthBar;
    public Slider bossHealthBar;
    public float enemyHealth;
    public float bossHealth;

    [Header("Textos")]
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerManaText;
    public TextMeshProUGUI playerSpeedText;

    [Header("Verificações")]
    private bool enemyBarIsRunning = true;
    


    void Start()
    {   
        enemySpeedBar.maxValue = 100;

        enemyHealthBar.maxValue = enemySpawn.enemy.maxHP;
        enemyHealthBar.value = enemySpawn.enemy.currentHP;

        enemyHealth = enemySpawn.enemy.maxHP;
    }

    void Update()
    {
        if (characterManager == null)
        {
            Debug.Log("CharacterManager não atribuído!");
            return;
        }

        int playerActualHealth = characterManager.actualHP;
        int playerMaxHealth = characterManager.maxHP;

        playerHealthText.text = $"{playerActualHealth}/{playerMaxHealth}";

        int playerActualMana = characterManager.actualMP;
        int playerMaxMana = characterManager.maxMP;

        playerManaText.text = $"{playerActualMana} / {playerMaxMana}";

        if (playerSpeedBar != null) {

            speedFillRate = characterManager.Speed;

            if (playerSpeedBar.value < 100)
            {
                playerSpeedBar.value += speedFillRate * Time.deltaTime;
                enemyBarIsRunning = true;
                DisableAllNavigation();
            }

            int intSpeedValue = (int)playerSpeedBar.value;

            playerSpeedText.text = $"{intSpeedValue}%";
        }
        else
        {
            Debug.Log("playerSpeedBar está nulo!");
        }

        if (enemySpeedBar != null)
        {
            enemySpeed = enemySpawn.enemy.speed;

                if (enemySpeedBar.value < 100 && enemyBarIsRunning == true)
                    enemySpeedBar.value += enemySpeed * Time.deltaTime;
        } 
        else
        {
            Debug.Log("enemySpeedBar está nulo");
        }

        if (enemyHealthBar != null && enemySpawn.enemy)
        {
            enemyHealthBar.value = enemySpawn.enemy.currentHP;
        }

        if(playerSpeedBar.value == 100)
        {
            enemyBarIsRunning = false;
            ActivateNavigation();
        }

    }

    public void SetupEnemyUI(EnemyData enemy)
    {
        enemyHealthBar.maxValue = enemy.maxHP;
        enemyHealthBar.value = enemy.currentHP;
        enemySpeed = enemy.speed;
        enemyHealth = enemy.currentHP;
    }

    void DisableAllNavigation()
    {
        foreach (var selectable in FindObjectsByType<Selectable>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            UnityEngine.UI.Navigation nav = selectable.navigation;
            nav.mode = UnityEngine.UI.Navigation.Mode.None;
            selectable.navigation = nav;
        }
    }

    void ActivateNavigation()
    {
        foreach (var selectable in FindObjectsByType<Selectable>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            UnityEngine.UI.Navigation nav = selectable.navigation;
            nav.mode = UnityEngine.UI.Navigation.Mode.Explicit;
            selectable.navigation = nav;
        }
    }
}
