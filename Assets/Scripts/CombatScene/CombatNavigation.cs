using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombatNavigation : MonoBehaviour
{
    [Header("References")]
    public CombatManager combatManager;
    public InventoryUI inventoryUI;

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
                        UpdateButtonAvaliability();
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

    private void UpdateButtonAvaliability()
    {
        foreach (Button btn in botoes)
        {

            bool canUse = true;
            switch (btn.name)
            {
                case "btnEnfrentar":
                    canUse = HasItem("Enfrentar");
                    break;

                case "btnF&A":
                    canUse = HasItem("F&A");
                    break;

                case "btnCVV":
                    canUse = HasItem("CVV");
                    break;

                case "btnPsique":
                    canUse = HasItem("Psique");
                    break;

                case "btnMúsica":
                    canUse = HasItem("Música");
                    break;

                case "btnExercícios":
                    canUse = HasItem("Exercícios");
                    break;

                case "btnLeitura":
                    canUse = HasItem("Leitura");
                    break;

                case "btnConversa":
                    canUse = HasItem("Conversa");
                    break;

                case "btnPocao":
                    canUse = HasItem("Poção");
                    break;
                case "btnJoia":
                    canUse = HasItem("Joia");
                    break;
                case "btnRealismo":
                    canUse = HasItem("Realismo");
                    break;
                case "btnPilula":
                    canUse = HasItem("Pílula");
                    break;
            }
        }
    }

    private bool HasItem(string itemName)
    {
        foreach (var item in inventoryUI.playerItems)
        {
            if (item.itemName == itemName && item.quantity > 0)
                return true;
        }
        return false;
    }
}
