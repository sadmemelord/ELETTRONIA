using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting_Edison : Interactable
{
    public Dialogue dialogue_painting_Edison;

    public override void Interact(GameObject caller)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue_painting_Edison);
    }
}