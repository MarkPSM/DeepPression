using System.Collections.Generic;
using UnityEngine;

public class ChestManagement : MonoBehaviour
{
    public static ChestManagement chestManagement;

    public GameObject[] chests;
    public ChestData chestData;

    public int actualID;

    public ItemsData[] items;

    public bool isOpened;

    void Awake()
    {
        if (chestManagement == null)
        {
            chestManagement = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Transform[] children = GetComponentsInChildren<Transform>(true);
        List<GameObject> objs = new List<GameObject>();

        foreach (Transform child in children)
        {
            if (child != this.transform)
                objs.Add(child.gameObject);
        }

        chests = objs.ToArray();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (chests != null)
        {
            GameObject bauAtual = chests[actualID];

            //chestData = GameObject.Find(bauAtual.name).GetComponent<ChestData>();


            if (isOpened)
            {   
                Debug.Log("Baú " + actualID + " aberto = " + isOpened);

                chestData.OpenChest();

                chestData.isOpened = isOpened;
                
                bauAtual = null;

                isOpened = false;
            }
        }
        else
        {
            Debug.Log("chests null");
        }
    }
}
