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
    public Slider[] enemiesSpeedBar;

    [Header("Health")]
    public Slider[] enemiesHealthBar;

    [Header("Textos")]
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerManaText;
    


    void Start()
    {
        for (int i = enemySpawn.quantity; i < enemySpawn.portraits.Length; i++)
        {
            enemySpawn.portraits[i].sprite = null;
            enemiesSpeedBar[i] = null;
            enemiesHealthBar[i] = null;
        }
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
            }
        }
        else
        {
            Debug.Log("playerSpeedBar está nulo!");
        }

        
    }
}
