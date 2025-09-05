using UnityEngine;

public class CharacterManager : MonoBehaviour
{
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
        maxHP = 100;
        actualHP = 100;

        Debug.Log($"actualHP:{actualHP} / maxHP:{maxHP}");

        maxMP = 20;
        actualMP = 20;

        Attack = 5;
        mentalAttack = 1;
        Defense = 1;
        Speed = 20;
    }
}
