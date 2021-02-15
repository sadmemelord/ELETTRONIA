using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerHUB : Interactable
{
    public Dialogue dialogue;

    public override void Interact(GameObject caller)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
