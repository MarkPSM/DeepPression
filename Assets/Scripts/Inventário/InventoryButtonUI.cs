using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButtonUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemName;
    public TMP_Text quantityText;

    public ItemsData itemData;
    private InventoryUI inventoryUI;

    public void Setup(ItemsData data, InventoryUI ui)
    {
        itemData = data;
        inventoryUI = ui;

        icon.sprite = itemData.icon;
        itemName.text = itemData.itemName;
        quantityText.text = $"x{itemData.quantity}";
    }

    public void OnSelect(BaseEventData eventData)
    {
        inventoryUI.ShowDetails(itemData);
        Debug.Log("Mostrou itens");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryUI.ShowDetails(itemData);
    }
}
