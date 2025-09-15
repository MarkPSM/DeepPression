using Unity.VisualScripting;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChestData : MonoBehaviour
{
    public int chestID;

    public Sprite closedSprite;
    public Sprite openedSprite;
    private SpriteRenderer spriteRenderer;
    public GameObject interactableEffect;

    public bool isOpened;

    public ItemsData[] items;
    public int rewardQuantity = 1;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = closedSprite;
    }

    private void Update()
    {
        if (isOpened)
        {
            spriteRenderer.sprite = openedSprite;
            interactableEffect.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = closedSprite;
            interactableEffect.SetActive(true);
        }
    }

    public void OpenChest()
    {
        foreach (var item in items)
        {
            item.quantity += rewardQuantity;
            Debug.Log($"Você adquiriu x{item.quantity} {item.name}");

//#if UNITY_EDITOR
//            EditorUtility.SetDirty(item);
//            AssetDatabase.SaveAssets();
//#endif
        }
    }

}
