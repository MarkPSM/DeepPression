using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Scriptable Objects/Item")]
public class ItemsData : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    public string itemDescription;

    [Header("Effects")]
    public int healHP;
    public int healMP;
    public int increaseHP;
    public int increaseMP;
    public int increaseAttack;
    public int increaseMentalAttack;
    public int increaseDefense;
    public int increaseSpeed;

    [Header("Inventory")]
    public int quantity;
}
