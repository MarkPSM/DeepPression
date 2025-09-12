using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "chest", menuName = "Scriptable Objects/Chest")]
public class ChestData : ScriptableObject
{
    public string chestID;

    public Sprite closedSprite;
    public Sprite openedSprite;

    public ItemsData[] items;
}
