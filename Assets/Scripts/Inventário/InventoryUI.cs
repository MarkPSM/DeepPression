using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("References")]
    public Transform itemListParent;   // onde os botões vão aparecer
    public GameObject itemButtonPrefab;

    [Header("Detail Panel")]
    public Image detailIcon;
    public TMP_Text detailName;
    public TMP_Text detailDescription;
    public Sprite nulo;

    [Header("Data")]
    public List<ItemsData> playerItems = new List<ItemsData>();

    public bool hasBeenRefreshed;

    private void Start()
    {
        hasBeenRefreshed = false;

        //Debug.Log(hasBeenRefreshed);
    }

    private void Update()
    {
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        if (hasBeenRefreshed == false)
        { 
            foreach (Transform child in itemListParent)
            {
                Destroy(child.gameObject);
                //Debug.Log("crianças destruidas");
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
                    InventoryButtonUI buttonUI = buttonGO.GetComponent<InventoryButtonUI>();
                    buttonUI.Setup(item, this);
                    //Debug.Log(item.name);
                }
            }


            ClearDetails();

            hasBeenRefreshed = true;
            //Debug.Log(hasBeenRefreshed);
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
}
