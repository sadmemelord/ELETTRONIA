using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerHUB : Interactable
{
    public Dialogue dialogue;
    public AudioSource _audio;
    private bool _not_played_yet = true;

    public override void Interact(GameObject caller)
    {
        if(NPC_Behavior_FSM.current_state == NPC_Behavior_FSM.State_type.HUB)
        {
            if (_not_played_yet == true)
            {
                _audio.Play();
                _not_played_yet = false;
            }
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        
    }
}
