using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [Header("References")]
    public EnemySpawn enemySpawn;
    public LevelLoader levelLoader;
    public EnemyController enemyController;
    public CharacterController characterController;

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

    [Header("XP")]
    public Slider xpBar;
    bool canDropXP = true;

    [Header("Textos")]
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerManaText;
    public TextMeshProUGUI playerSpeedText;
    public TextMeshProUGUI playerXPText;
    public TextMeshProUGUI playerLVLText;


    [Header("Verificações")]
    public bool enemyBarIsRunning = true;
    
    

    void Start()
    {   
        if (enemySpawn.isBoss == false)
        {
            enemySpeedBar.maxValue = 100;

            enemyHealthBar.maxValue = enemySpawn.enemy.maxHP;
            enemyHealthBar.value = enemySpawn.enemy.currentHP;

            enemyHealth = enemySpawn.enemy.maxHP;
        }
        else
        {
            bossSpeedBar.maxValue = 100;

            bossHealthBar.maxValue = enemySpawn.boss.maxHP;
            enemyHealthBar.value = enemySpawn.boss.currentHP;

            bossHealth = enemySpawn.boss.maxHP;
        }

        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();


    }

    void Update()
    {

        int playerActualHealth = CharacterManager.Player.actualHP;
        int playerMaxHealth = CharacterManager.Player.maxHP;

        playerHealthText.text = $"{playerActualHealth}/{playerMaxHealth}";

        int playerActualMana = CharacterManager.Player.actualMP;
        int playerMaxMana = CharacterManager.Player.maxMP;

        playerManaText.text = $"{playerActualMana} / {playerMaxMana}";

        if (playerActualHealth <= 0){
            StartCoroutine(levelLoader.LoadPhase("DeathScreen"));
            EnemyManager.Enemy.playerDied = true;
            Debug.Log(EnemyManager.Enemy.playerDied);
        }
        else
        {
            EnemyManager.Enemy.playerDied = false;
        }

        if (xpBar != null)
        {
            xpBar.maxValue = CharacterManager.Player.nextLevelXP;
            xpBar.value = CharacterManager.Player.XP;
            if (playerXPText != null && playerLVLText != null)
            {
                playerXPText.text = $"{xpBar.value}/{xpBar.maxValue}";
                playerLVLText.text = $"LVL {CharacterManager.Player.Level}";
            }
        }

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

        if (enemySpawn.isBoss == false) 
        {
            bossHealthBar.gameObject.SetActive(false);
            bossSpeedBar.gameObject.SetActive(false);   

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
                enemySpeedBar.enabled = false;
            }

            if (enemyHealthBar != null)
            {
                enemyHealthBar.value = enemyHealth;
                if (enemyHealthBar.value <= 0)
                {
                    
                    StartCoroutine(levelLoader.LoadPhase(GameManager.Instance.nextStage.ToString()));
                    EnemyManager.Enemy.isDead = true;
                    if (canDropXP)
                        CharacterManager.Player.XP += enemySpawn.enemy.xpDrop;
                    canDropXP = false;
                }
                else
                {
                    EnemyManager.Enemy.isDead = false;
                }
            }
            else
            {
                enemyHealthBar.enabled = false;
            }
        }

        if (enemySpawn.isBoss == true)
        {
            if (bossHealthBar != null)
            {
                bossHealthBar.value = bossHealth;

                if (bossHealthBar.value <= 0)
                {
                    Debug.Log("Boss derrotado!");
                    StartCoroutine(levelLoader.LoadPhase(GameManager.Instance.nextStage.ToString()));
                    EnemyManager.Enemy.isDead = true;
                    if (canDropXP)
                        CharacterManager.Player.XP += enemySpawn.boss.xpDrop;
                    canDropXP = false;
                }
                else
                {
                    EnemyManager.Enemy.isDead = false;
                }
            }
            else
            {
                bossHealthBar.enabled = false;
            }

            if (bossSpeedBar != null)
            {
                bossSpeed = enemySpawn.boss.speed;

                if (bossSpeedBar.value < 100 && enemyBarIsRunning == true)
                    bossSpeedBar.value += bossSpeed * Time.deltaTime;

                if (bossSpeedBar.value == 100)
                {
                    CharacterManager.Player.actualHP -= (enemySpawn.boss.attack / CharacterManager.Player.Defense);
                    bossSpeedBar.value = 0;
                }
            }
            else
            {
               bossSpeedBar.enabled = false;
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

    public void SetupBossUI(EnemyData boss)
    {
        bossHealthBar.maxValue = boss.maxHP;
        bossHealthBar.value = boss.currentHP;
        bossSpeed = boss.speed;
        bossHealth = boss.currentHP;
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
        if (GameManager.Instance.nextIsBoss == false)
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
        else
        {
            Debug.Log("Luta contra Boss!");
            return;
        }
    }

    public void Coragem()
    {
        if (enemySpawn.isBoss == false)
            enemyHealth -= (CharacterManager.Player.Attack / enemySpawn.enemy.defense);
        else
            bossHealth -= (CharacterManager.Player.Attack / enemySpawn.boss.defense);
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
        if (enemySpawn.isBoss == false)
            enemyHealth -= (CharacterManager.Player.mentalAttack / enemySpawn.enemy.defense);
        else
            bossHealth -= (CharacterManager.Player.mentalAttack / enemySpawn.boss.defense);
    }

    public void Musica()
    {
        if (CharacterManager.Player.actualMP - 20 < 0)
        {
            return;
        }

        if (enemySpawn.isBoss == false)
            enemySpawn.enemy.defense -= CharacterManager.Player.mentalAttack;
        else
            enemySpawn.boss.defense -= CharacterManager.Player.mentalAttack;

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
