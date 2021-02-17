using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMUS_1 : Interactable
{
    public Dialogue dialogue;

    public override void Interact(GameObject caller)
    {
        if (NPC_Behavior_FSM.current_substate == NPC_Behavior_FSM.SubState_type.Current_mus)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }
}

