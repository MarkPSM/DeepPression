using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Action action;

    public CharacterController characterController;

    public DialogueSystem dialogueSystem;

    public DataController dataController;

    public GameObject interactedObject;

    private ChestData chestData;

    //[SerializeField] bool uiInteract;
    public bool alreadyChating;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && action != null)
        {
            action.Invoke();
        }

        if (dataController == null)
            dataController = GameObject.Find("DialogueManager").GetComponent<DataController>();
        else
            return;

        if (dialogueSystem == null)
            dialogueSystem = GameObject.Find("DialogueManager").GetComponent<DialogueSystem>();
        else
            return;

        if (alreadyChating && Input.GetKeyDown(KeyCode.X))
        {
            dialogueSystem.CancelDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            interactedObject = other.gameObject;

            if (other.CompareTag("Chest"))
            {
                Debug.Log("Collidindo cm um bau");
                chestData = interactedObject.GetComponent<ChestData>();

                if (chestData != null)
                {
                    ChestManagement.chestManagement.chestData = chestData;
                    ChestManagement.chestManagement.actualID = chestData.chestID;
                    action = AbrirBau;
                }
            }
            else
            {
                Debug.Log("Não sei o que está collidindo");
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
        if (!alreadyChating && !chestData.isOpened)
        {
            alreadyChating = true;
            characterController.canWalk = false;
            if (dataController != null)
                dataController.WhichData(ChestManagement.chestManagement.actualID);
            dialogueSystem.Next();

            ChestManagement.chestManagement.isOpened = true;
            return;
        }
    }
}