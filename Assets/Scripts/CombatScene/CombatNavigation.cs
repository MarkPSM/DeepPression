using Mono.Cecil.Cil;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    [Serializable]
    public class Botao
    {
        public GameObject button;
        public GameObject Setup;
        public string Function;
    }

    public List<Botao> buttons;

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

                    if (!string.IsNullOrEmpty(buttons[0].Function))

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
                            //Fuga();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnCoragem":
                            //Coragem();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnF&A":
                            //F&A();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnCVV":
                            //CVV();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnPsique":
                            //Psique();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnMúsica":
                            //Musica();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnExercícios":
                            //Exercicio();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnLeitura":
                            //Leitura();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnConversa":
                            //Conversa();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnPocao":
                            //Pocao();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnJoia":
                            //Joia();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnRealismo":
                            //Realismo();
                            SetActiveSetup(initialSetup);
                            break;

                        case "btnPilula":
                            //Pilula();
                            SetActiveSetup(initialSetup);
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
