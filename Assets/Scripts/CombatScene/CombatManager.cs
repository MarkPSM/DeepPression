using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [Header("References")]
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

        int playerActualHealth = CharacterManager.Player.actualHP;
        int playerMaxHealth = CharacterManager.Player.maxHP;

        playerHealthText.text = $"{playerActualHealth}/{playerMaxHealth}";

        int playerActualMana = CharacterManager.Player.actualMP;
        int playerMaxMana = CharacterManager.Player.maxMP;

        playerManaText.text = $"{playerActualMana} / {playerMaxMana}";

        if (playerSpeedBar != null) {

            speedFillRate = CharacterManager.Player.Speed;

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
                    CharacterManager.Player.actualHP -= (enemySpawn.enemy.attack / CharacterManager.Player.Defense);
                    enemySpeedBar.value = 0;
                }
        } 
        else
        {
            Debug.Log("enemySpeedBar está nulo");
        }

        if (enemyHealthBar != null)
        {
            enemyHealthBar.value = enemyHealth;
            if (enemyHealthBar.value <= 0)
            {
                Debug.Log("Inimigo Derrotado");
                StartCoroutine(levelLoader.LoadPhase("FirstStage"));
                EnemyManager.Enemy.isDead = true;
            }
            else
            {
                EnemyManager.Enemy.isDead = false;
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
        enemyHealth -= (CharacterManager.Player.Attack / enemySpawn.enemy.defense);
    }

    public void FA()
    {
        CharacterManager.Player.Attack += CharacterManager.Player.Defense;
    }

    public void CVV()
    {
        CharacterManager.Player.mentalAttack *= 2;
    }

    public void Psique()
    {
        enemyHealth -= (CharacterManager.Player.mentalAttack / enemySpawn.enemy.defense);
    }

    public void Musica()
    {
        if (CharacterManager.Player.actualMP - 20 < 0)
        {
            return;
        }

        enemySpawn.enemy.defense -= CharacterManager.Player.mentalAttack;
        CharacterManager.Player.actualMP -= 20;
    }

    public void Exercicio()
    {
        if (CharacterManager.Player.actualMP - 10 < 0)
        {
            return;
        }

        CharacterManager.Player.Attack *= 2;
        CharacterManager.Player.actualMP -= 10;
    }

    public void Leitura()
    {
        CharacterManager.Player.actualMP += CharacterManager.Player.mentalAttack;
    }

    public void Conversa()
    {
        if (CharacterManager.Player.actualMP - 30 < 0)
        {
            return;
        }

        CharacterManager.Player.Defense += CharacterManager.Player.mentalAttack;
        CharacterManager.Player.actualMP -= 30;
    }

    public void Pocao()
    {
        CharacterManager.Player.actualHP += 20;
        if (CharacterManager.Player.actualHP > CharacterManager.Player.maxHP)
            CharacterManager.Player.actualHP = CharacterManager.Player.maxHP;
    }

    public void Joia()
    {
        CharacterManager.Player.actualMP += 10;
        if (CharacterManager.Player.actualMP > CharacterManager.Player.maxMP)
            CharacterManager.Player.actualMP = CharacterManager.Player.maxMP;
    }

    public void Realismo()
    {
        CharacterManager.Player.Speed += 10;
    }

    public void Pilula()
    {
        if (CharacterManager.Player.actualHP - (CharacterManager.Player.maxHP / 2) <= 0)
        {
            return;
        }

        CharacterManager.Player.actualHP -= (CharacterManager.Player.maxHP / 2);
        CharacterManager.Player.Speed *= 3;
    }

}
