using Mono.Cecil.Cil;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombatNavigation : MonoBehaviour
{
    public Button[] botoes;

    private Dictionary<(int, KeyCode), int> navigationMap;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(botoes[0].gameObject);

        navigationMap = new Dictionary<(int, KeyCode), int>
        {
            {(0, KeyCode.RightArrow), 1 },
            {(0, KeyCode.DownArrow), 2 },
            {(1, KeyCode.DownArrow), 3},
            {(1, KeyCode.LeftArrow), 0 },
            {(2, KeyCode.UpArrow), 0 },
            {(2, KeyCode.RightArrow), 3 },
            {(3, KeyCode.UpArrow), 1 },
            {(3, KeyCode.LeftArrow), 2 }
        };
    }

    void Update()
    {   
        if (EventSystem.current.currentSelectedGameObject == null) return;

        int currentIndex = System.Array.IndexOf(botoes, EventSystem.current.currentSelectedGameObject.GetComponent<Button>());
        if (currentIndex < 0) return;

        foreach (KeyCode key in new KeyCode[] {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow})
        {
            if (Input.GetKeyDown(key) && navigationMap.TryGetValue((currentIndex, key), out int nextIndex))
            {
                EventSystem.current.SetSelectedGameObject(botoes[nextIndex].gameObject);
                break;   
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject objectSelected = EventSystem.current.currentSelectedGameObject;

            if (objectSelected != null)
            {
                Button btn = objectSelected.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }
        }
    }


}
