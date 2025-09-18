using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Player;

    public int maxHP;
    public int actualHP;

    public int maxMP;
    public int actualMP;

    [Header("Atributos")]
    public int Attack;
    public int mentalAttack;
    public int Defense;
    public int Speed;

    [Header("Level")]
    public int Level;
    public int XP;
    public int nextLevelXP;
        
    private void Awake()
    { 
        if (Player == null)
        {
            Player = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        maxHP = 100;
        actualHP = 100;

        maxMP = 20;
        actualMP = 20;

        Attack = 10;
        mentalAttack = 0;
        Defense = 2;
        Speed = 25;

        Level = 0;
        nextLevelXP = 100;
    }

    public void FixedUpdate()
    {
        if (XP >= nextLevelXP)
        {
            var restante = XP - nextLevelXP;

            nextLevelXP *= 2;
            XP = restante;

            maxHP += 25;
            actualHP += 25;
            maxMP += 5;
            actualMP += 5;

            Attack *= 2;
            mentalAttack += Attack / 2 + 5;
            Defense += 1;
            Speed *= 1;
        }
    }
}
