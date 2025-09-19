using NUnit.Framework;
using System;
using System.Collections;
using Unity.VisualScripting;
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

        if (dialogueSystem == null)
            dialogueSystem = GameObject.Find("DialogueManager").GetComponent<DialogueSystem>();


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
                Debug.Log("Collidindo cm Chest");
                chestData = interactedObject.GetComponent<ChestData>();

                if (chestData != null)
                {
                    ChestManagement.chestManagement.chestData = chestData;
                    ChestManagement.chestManagement.actualID = chestData.chestID;
                    action = AbrirBau;
                }
            }
            else if (other.CompareTag("Save"))
            {
                Debug.Log("Colidindo cm o Save: " + other.name);
                switch (other.name)
                {
                    case "FirstSave":
                        action = FirstSave;
                        break;

                    case "SecondSave":
                        action = SecondSave;
                        break;

                    case "ThirdSave":
                        action = ThirdSave;
                        break;

                    case "FourthSave":
                        action = FourthSave;
                        break;

                    case "FifthSave":
                        action = FifthSave;
                        break;
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

    void FirstSave()
    {
        if (!alreadyChating)
        {
            alreadyChating = true;
            characterController.canWalk = false;
            CharacterManager.Player.actualHP = CharacterManager.Player.maxHP;
            CharacterManager.Player.actualMP = CharacterManager.Player.maxMP;

            if (dataController != null)
                dataController.WhichData(0);
            dialogueSystem.Next();

            GameManager.Instance.Checkpoint = interactedObject.transform.Find("Checkpoint").GetComponent<Transform>();

            return;
        }
    }

    void SecondSave()
    {
        if (!alreadyChating)
        {
            alreadyChating = true;
            characterController.canWalk = false;
            CharacterManager.Player.actualHP = CharacterManager.Player.maxHP;
            CharacterManager.Player.actualMP = CharacterManager.Player.maxMP;

            if (dataController != null)
                dataController.WhichData(1);
            dialogueSystem.Next();

            GameManager.Instance.Checkpoint = interactedObject.transform.Find("Checkpoint").GetComponent<Transform>();

            return;
        }
    }

    void ThirdSave()
    {
        if (!alreadyChating)
        {
            alreadyChating = true;
            characterController.canWalk = false;
            CharacterManager.Player.actualHP = CharacterManager.Player.maxHP;
            CharacterManager.Player.actualMP = CharacterManager.Player.maxMP;

            if (dataController != null)
                dataController.WhichData(2);

            dialogueSystem.Next();

            GameManager.Instance.Checkpoint = interactedObject.transform.Find("Checkpoint").GetComponent<Transform>();

            return;
        }
    }

    void FourthSave()
    {
        if (!alreadyChating)
        {
            alreadyChating = true;
            characterController.canWalk = false;
            CharacterManager.Player.actualHP = CharacterManager.Player.maxHP;
            CharacterManager.Player.actualMP = CharacterManager.Player.maxMP;

            if (dataController != null)
                dataController.WhichData(3);

            dialogueSystem.Next();

            GameManager.Instance.Checkpoint = interactedObject.transform.Find("Checkpoint").GetComponent<Transform>();

            return;
        }
    }

    void FifthSave()
    {
        if (!alreadyChating)
        {
            alreadyChating = true;
            characterController.canWalk = false;
            CharacterManager.Player.actualHP = CharacterManager.Player.maxHP;
            CharacterManager.Player.actualMP = CharacterManager.Player.maxMP;

            if (dataController != null)
                dataController.WhichData(4);

            dialogueSystem.Next();

            GameManager.Instance.Checkpoint = interactedObject.transform.Find("Checkpoint").GetComponent<Transform>();

            return;
        }
    }
}