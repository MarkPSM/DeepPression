using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Action action;

    public CharacterController characterController;

    public DialogueSystem dialogueSystem;

    public DataController dataController;

    public GameObject interactedObject;

    //[SerializeField] bool uiInteract;
    [SerializeField] bool alreadyChating;

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            interactedObject = other.gameObject;

            if (other.CompareTag("Chest"))
            {
                Debug.Log("Collidindo cm um bau");
                ChestData chestData = interactedObject.GetComponent<ChestData>();

                if (chestData != null)
                {
                    ChestManagement.chestManagement.chestData = chestData;
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
        if (!alreadyChating)
        {
            alreadyChating = true;
            dataController.WhichData(ChestManagement.chestManagement.actualID + 1);
            dialogueSystem.Next();
            //uiInteract = false;

            ChestManagement.chestManagement.isOpened = true;
            return;
        }
    }
}