using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMUS_Panel_2 : Interactable
{
    public Dialogue dialogue_panel_2;

    public override void Interact(GameObject caller)
    {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_panel_2);
    }
}
