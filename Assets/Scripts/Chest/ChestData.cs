using Unity.VisualScripting;
using UnityEngine;

public class ChestData : MonoBehaviour
{
    public int chestID;

    public Sprite closedSprite;
    public Sprite openedSprite;
    private SpriteRenderer spriteRenderer;
    public GameObject interactableEffect;

    public bool isOpened;

    public ItemsData[] items;

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

}
