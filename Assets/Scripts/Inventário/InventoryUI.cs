using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("References")]
    public Transform itemListParent;
    public GameObject itemButtonPrefab;
    public InventoryButtonUI inventoryButtonUI;
    public CharacterManager characterManager;

    [Header("Detail Panel")]
    public Image detailIcon;
    public TMP_Text detailName;
    public TMP_Text detailDescription;
    public Sprite nulo;

    [Header("Data")]
    public List<ItemsData> playerItems = new List<ItemsData>();

    private List<GameObject> buttons = new List<GameObject>();

    public bool hasBeenRefreshed;

    private void Start()
    {
        hasBeenRefreshed = false;

        characterManager = GameObject.Find("Player").GetComponent<CharacterManager>();
    }

    private void Update()
    {
        RefreshInventory();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject objectSelected = EventSystem.current.currentSelectedGameObject;
            if (objectSelected != null)
            {
                Debug.Log("Clicou no botão no inventário");
                foreach (var button in buttons)
                {
                    ItemsData item = inventoryButtonUI.itemData;

                    Button btn = button.GetComponent<Button>();

                    if (btn != null)
                    {
                        btn.onClick.Invoke();
                        switch (item.itemName)
                        {
                            case "Força!":
                                Forca();
                                break;
                        }
                    }
                }
            }
            EscManager.Esc.SelectFirstInventoryButton();
        }
    }

    public void RefreshInventory()
    {
        if (hasBeenRefreshed == false)
        {
            foreach (Transform child in itemListParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var item in playerItems)
            {
                if (item.quantity <= 0)
                {
                    continue;
                }
                else
                {
                    GameObject buttonGO = Instantiate(itemButtonPrefab, itemListParent);
                    inventoryButtonUI = buttonGO.GetComponent<InventoryButtonUI>();
                    inventoryButtonUI.Setup(item, this);
                    buttons.Add(buttonGO);
                    EscManager.Esc.SelectFirstInventoryButton();
                }
            }


            ClearDetails();

            hasBeenRefreshed = true;
        }
    }

    public void ShowDetails(ItemsData item)
    {
        detailIcon.sprite = item.icon;
        detailName.text = item.itemName;
        detailDescription.text = item.itemDescription;
    }

    private void ClearDetails()
    {
        detailIcon.sprite = nulo;
        detailName.text = "";
        detailDescription.text = "";
    }

    public void Forca()
    {
        ItemsData item = playerItems.Find(i => i.itemName == "Força!");

        if (item != null)
        {
            item.quantity -= 1;
            characterManager.Attack += item.increaseAttack;
            Debug.Log("Ataque aumentado em " + item.increaseAttack);
        }
    }
}
