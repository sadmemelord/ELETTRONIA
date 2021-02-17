using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMUS_Panel_1 : Interactable
{
    public Dialogue dialogue_panel_1;

    public override void Interact(GameObject caller)
    {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_panel_1);
    }
}

