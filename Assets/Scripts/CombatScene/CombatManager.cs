using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [Header("References")]
    public CharacterManager characterManager;
    public EnemySpawn enemySpawn;
    public LevelLoader levelLoader;
    public EnemyController enemyController;

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

            if (playerSpeedBar.value == 100)
            {
                enemyBarIsRunning = false;
                ActivateNavigation();
            }
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

                if (enemySpeedBar.value == 100)
                {
                    characterManager.actualHP -= (enemySpawn.enemy.attack / characterManager.Defense);
                    enemySpeedBar.value = 0;
                }
        } 
        else
        {
            Debug.Log("enemySpeedBar está nulo");
        }

        if (enemyHealthBar != null && enemySpawn.enemy)
        {
            enemyHealthBar.value = enemyHealth;
            if (enemyHealthBar.value <= 0)
            {
                Debug.Log("Inimigo Derrotado");
                StartCoroutine(levelLoader.LoadPhase("FirstStage"));
                enemyController.isDead = true;
            }
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

    public void Fuga()
    {
        System.Random rnd = new System.Random();

        int chance = rnd.Next(1, 3);

        if (chance == 1)
        {
            Debug.Log("Não escapou");
        }
        else if (chance == 2)
        {
            Debug.Log("Escapou");
            StartCoroutine(levelLoader.LoadPhase(enemyController.thisStage.ToString()));
        }
    }

    public void Coragem()
    {
        enemyHealth -= (characterManager.Attack / enemySpawn.enemy.defense);
    }

    public void FA()
    {
        characterManager.Attack += characterManager.Defense;
    }

    public void CVV()
    {
        characterManager.mentalAttack *= 2;
    }

    public void Psique()
    {
        enemyHealth -= (characterManager.mentalAttack / enemySpawn.enemy.defense);
    }

    public void Musica()
    {
        if (characterManager.actualMP - 20 < 0)
        {
            return;
        }

        enemySpawn.enemy.defense -= characterManager.mentalAttack;
        characterManager.actualMP -= 20;
    }

    public void Exercicio()
    {
        if (characterManager.actualMP - 10 < 0)
        {
            return;
        }

        characterManager.Attack *= 2;
        characterManager.actualMP -= 10;
    }

    public void Leitura()
    {
        characterManager.actualMP += characterManager.mentalAttack;
    }

    public void Conversa()
    {
        if (characterManager.actualMP - 30 < 0)
        {
            return;
        }

        characterManager.Defense += characterManager.mentalAttack;
        characterManager.actualMP -= 30;
    }

    public void Pocao()
    {
        characterManager.actualHP += 20;
        if (characterManager.actualHP > characterManager.maxHP)
            characterManager.actualHP = characterManager.maxHP;
    }

    public void Joia()
    {
        characterManager.actualMP += 10;
        if (characterManager.actualMP > characterManager.maxMP)
            characterManager.actualMP = characterManager.maxMP;
    }

    public void Realismo()
    {
        characterManager.Speed += 10;
    }

    public void Pilula()
    {
        if (characterManager.actualHP - (characterManager.maxHP / 2) <= 0)
        {
            return;
        }

        characterManager.actualHP -= (characterManager.maxHP / 2);
        characterManager.Speed *= 3;
    }

}
