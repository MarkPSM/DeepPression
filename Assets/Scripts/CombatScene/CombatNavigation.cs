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

    private bool HasItem(string itemName)
    {
        foreach (var item in inventoryUI.playerItems)
        {
            if (item.itemName == itemName && item.quantity > 0)
                return true;
        }
        return false;
    }


    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(botoes[0].gameObject);
    }


    void Start()
    {
        UpdateButtonAvaliability();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject objectSelected = EventSystem.current.currentSelectedGameObject;

            if (combatManager != null && combatManager.playerSpeedBar.value == 100 && objectSelected != null)
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
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnF&A":
                    canUse = HasItem("F&A");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnCVV":
                    canUse = HasItem("CVV");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnPsique":
                    canUse = HasItem("Psique");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnMúsica":
                    canUse = HasItem("Música");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnExercícios":
                    canUse = HasItem("Exercícios");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnLeitura":
                    canUse = HasItem("Leitura");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnConversa":
                    canUse = HasItem("Conversa");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;

                case "btnPocao":
                    canUse = HasItem("Poção");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;
                case "btnJoia":
                    canUse = HasItem("Joia");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;
                case "btnRealismo":
                    canUse = HasItem("Realismo");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;
                case "btnPilula":
                    canUse = HasItem("Pílula");
                    if (!canUse)
                        btn.enabled = false;
                    else
                        btn.enabled = true;
                    break;
            }
        }
    }
}
