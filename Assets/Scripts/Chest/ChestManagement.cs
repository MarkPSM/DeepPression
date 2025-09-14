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

        if (chests != null)
        {
            GameObject inimigoAtual = chests[actualID];

            chestData = GameObject.Find(inimigoAtual.name).GetComponent<ChestData>();

            chestData.isOpened = isOpened;

            if (isOpened)
            {
                Debug.Log("Baú " + actualID + " aberto");
            }
        }
        else
        {
            Debug.Log("chests null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
