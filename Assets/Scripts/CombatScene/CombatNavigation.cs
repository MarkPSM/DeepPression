using Mono.Cecil.Cil;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombatNavigation : MonoBehaviour
{
    public GameObject initialSetup;
    public GameObject enfrentarSetup;
    public GameObject hobbySetup;
    public GameObject itensSetup;

    public Button[] botoes;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(botoes[0].gameObject);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject objectSelected = EventSystem.current.currentSelectedGameObject;

            if (objectSelected != null)
            {
                Button btn = objectSelected.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.Invoke();

                    switch (btn.name)
                    {
                        case "btnEnfrentar":
                            SetActiveSetup(enfrentarSetup);
                            break;

                        case "btnHobby":
                            SetActiveSetup(hobbySetup);
                            break;

                        case "btnItens":
                            SetActiveSetup(itensSetup);
                            break;
                    }
                }
            }
        }
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Voltou");
                SetActiveSetup(initialSetup);
            }

    }

    private void SetActiveSetup(GameObject setup)
    {
        initialSetup.SetActive(false);
        enfrentarSetup.SetActive(false);
        hobbySetup.SetActive(false);
        itensSetup.SetActive(false);

        setup.SetActive(true);

        botoes = setup.GetComponentsInChildren<Button>();

        if (botoes.Length > 0)
            EventSystem.current.SetSelectedGameObject(botoes[0].gameObject);
    }


}
