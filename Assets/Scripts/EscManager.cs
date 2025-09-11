using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EscManager : MonoBehaviour
{
    public static EscManager Esc;

    [Header("References")]
    public CharacterController characterController;

    [Header("OptionsTabs")]
    public bool isPaused;
    public bool inventory = false;
    public bool status = false;
    public bool habilities = false;
    public bool options = false;

    [Header("Tabs")]
    public Canvas canvasPause;
    public Canvas canvasInventory;

    [Header("Navigation")]
    public GameObject firstPauseButton;
    public GameObject firstInventoryButton;


    void Awake()
    {
        if (Esc == null)
        {
            Esc = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canvasPause = GameObject.Find("CanvasPause").GetComponent<Canvas>();
        canvasInventory = GameObject.Find("CanvasInventario").GetComponent<Canvas>();

        canvasPause.enabled = false;
        canvasInventory.enabled = false;

        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
            canvasPause.enabled = isPaused;

            if (inventory)
                inventory = false;

            if (isPaused)
            {
                characterController.canWalk = false;

                if (firstPauseButton != null)
                    EventSystem.current.SetSelectedGameObject(firstPauseButton);
            }
            else
            {
                characterController.canWalk = true;

                EventSystem.current.SetSelectedGameObject(null);
            }
        }

        canvasInventory.enabled = inventory;

        if (canvasInventory != null && inventory == true && isPaused)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                inventory = false;
                canvasPause.enabled = true;

                if (firstPauseButton != null)
                    EventSystem.current.SetSelectedGameObject(firstPauseButton);
            }
        }
    }

    public void Inventory()
    {
        inventory = true;
        canvasPause.enabled = false;

        StartCoroutine(SelectFirstInventoryButton());
    }

    public IEnumerator SelectFirstInventoryButton()
    {
        yield return null;
        if (firstInventoryButton != null && firstInventoryButton.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstInventoryButton);
            Debug.Log("Primeiro botão do inventário selecionado");
        }
    }
}
