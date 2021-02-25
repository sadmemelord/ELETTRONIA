using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting_Franklin : Interactable
{
    public Dialogue dialogue_painting_Franklin;

    public override void Interact(GameObject caller)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue_painting_Franklin);
    }
}