﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerHUB : Interactable
{
    public Dialogue dialogue;

    public override void Interact(GameObject caller)
    {
        if(NPC_Behavior_FSM.current_state == NPC_Behavior_FSM.State_type.HUB)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        
    }
}
