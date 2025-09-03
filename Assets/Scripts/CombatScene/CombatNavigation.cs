using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombatNavigation : MonoBehaviour
{
    [Header("References")]
    public CombatManager combatManager;

    [Header("Setup")]
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

            if (combatManager != null)
            {
                if (combatManager.playerSpeedBar.value == 100)
                {

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

                                case "btnFugir":
                                    combatManager.Fuga();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnCoragem":
                                    combatManager.Coragem();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnF&A":
                                    combatManager.FA();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnCVV":
                                    combatManager.CVV();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnPsique":
                                    combatManager.Psique();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnMúsica":
                                    combatManager.Musica();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnExercícios":
                                    combatManager.Exercicio();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnLeitura":
                                    combatManager.Leitura();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnConversa":
                                    combatManager.Conversa();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnPocao":
                                    combatManager.Pocao();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnJoia":
                                    combatManager.Joia();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnRealismo":
                                    combatManager.Realismo();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;

                                case "btnPilula":
                                    combatManager.Pilula();
                                    SetActiveSetup(initialSetup);
                                    combatManager.playerSpeedBar.value = 0;
                                    break;
                            }
                        }
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
