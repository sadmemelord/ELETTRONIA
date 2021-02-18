﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMUS_2 : Interactable
{
    public Dialogue dialogue_mus_2;
    public AudioSource _audio;
    private bool _not_played_yet = true;

    public override void Interact(GameObject caller)
    {
        if (NPC_Behavior_FSM.current_substate == NPC_Behavior_FSM.SubState_type.Resistor_mus)
        {
            if (_not_played_yet == true)
            {
                _audio.Play();
                _not_played_yet = false;
            }
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_mus_2);
        }

    }
}
