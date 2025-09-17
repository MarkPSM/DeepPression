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
    }
}
