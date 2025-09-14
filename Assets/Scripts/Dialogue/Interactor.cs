using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Interactor : MonoBehaviour
{
    public Action action;

    public CharacterController characterController;

    public DialogueSystem dialogueSystem;

    public DataController dataController;

    public GameObject interactedObject;

    [SerializeField] bool uiInteract;
    [SerializeField] bool alreadyChating;

    void Start()
    {
        uiInteract = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && action != null)
        {
            action.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            interactedObject = other.gameObject;

            if (other.CompareTag("Chest"))
            {
                ChestData chestData = interactedObject.GetComponent<ChestData>();
                if (chestData != null)
                {
                    action = AbrirBau;
                }
            }
        }
        else
        {
            Debug.Log("Collider não encontrado!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            if (other)
            {
                action = null;
                Debug.Log("Saiu do trigger");
            }
        }
    }

    void AbrirBau()
    {
        if (!alreadyChating)
        {
            alreadyChating = true;
            dataController.WhichData(ChestManagement.chestManagement.actualID);
            dialogueSystem.Next();
            uiInteract = false;

            ChestManagement.chestManagement.isOpened = false;
            return;
        }
    }
}