using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    public Button[] botoes;
    private int index = 0;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(botoes[0].gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index = (index + 1) % botoes.Length;
            EventSystem.current.SetSelectedGameObject(botoes[index].gameObject);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index = (index - 1 + botoes.Length) % botoes.Length;
            EventSystem.current.SetSelectedGameObject(botoes[index].gameObject);
        }
    }
}
