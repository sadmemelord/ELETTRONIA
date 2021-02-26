using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Opener : Interactable
{
    public Renderer Button_Renderer;
    public GameObject _button;
    public Animator _animatorL;
    public Animator _animatorR;
    public AudioSource _button_sound;
    public AudioSource _button_closed;
    public AudioSource _doorL_sound;
    public AudioSource _doorR_sound;
    public Color Open_Color;
    public Color Closed_Color;
    public Light Button_Light;
    // Start is called before the first frame update
    void Start()
    {
        Button_Light.color = Closed_Color;
        Button_Renderer.material.SetColor("_EmissionColor", Closed_Color);
    }

    // Update is called once per frame
    void Update()
    {
        if (NPC_Behavior_FSM.Unlock_Puzzle == true)
        {
            Button_Light.color = Open_Color;
            Button_Renderer.material.SetColor("_EmissionColor", Open_Color);

        }
        else
        {
            Button_Light.color = Closed_Color;
            Button_Renderer.material.SetColor("_EmissionColor", Closed_Color);
        }


    }
    public override void Interact(GameObject caller)
    {
        if (NPC_Behavior_FSM.Unlock_Puzzle == true)
        {

            if ((_animatorL.GetBool("Slider") && _animatorR.GetBool("Slider")) == false) //door is closed interaction will open
            {
                _animatorL.SetBool("Slider", true);
                _animatorR.SetBool("Slider", true);
                _button_sound.Play();
                _doorL_sound.Play();
                _doorR_sound.Play();
            }

            else //door is open interaction will close
            {
                _animatorL.SetBool("Slider", false);
                _animatorR.SetBool("Slider", false);
                _button_sound.Play();
                _doorL_sound.Play();
                _doorR_sound.Play();
            }

        }

        else
        {
            _button_closed.Play();
        }

    }
}
