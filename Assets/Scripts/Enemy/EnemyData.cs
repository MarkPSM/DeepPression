using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Scriptable Objects/Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Info")]
    public string enemyName;
    public Sprite portrait;

    [Header("Stats")]
    public int maxHP;
    public int currentHP;
    public int attack;
    public int defense;
    public int speed;
}
