﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerPUZ_Start : Interactable
{
    public Dialogue dialogue_puz_0;
    public AudioSource _audio;
    private bool _not_played_yet = true;

    public override void Interact(GameObject caller)
    {
        if (NPC_Behavior_FSM.current_substate == NPC_Behavior_FSM.SubState_type.Start_puz)
        {
            if (_not_played_yet == true)
            {
                _audio.Play();
                _not_played_yet = false;
            }
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_puz_0);
        }

    }
}