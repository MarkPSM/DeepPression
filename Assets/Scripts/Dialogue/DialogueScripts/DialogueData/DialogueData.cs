using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Dialogue
{
    public Sprite icon;
    public string name;
    [TextArea(2, 3)] public string text;
}

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/TalkScript")]
public class DialogueData : ScriptableObject
{
    public List<Dialogue> talkScript;
}
