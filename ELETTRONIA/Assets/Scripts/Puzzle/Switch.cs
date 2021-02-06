using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public bool isClosed;
    public Animator _switch_animator;
    public Renderer sphere_1;
    public Renderer sphere_2;
    public Material SpheresMat;
    public bool switch_snapped;
    public AudioSource _switch_sound;
    public Color on_color;
    public Color off_color;
    public Color disconnected_color;
    // Start is called before the first frame update

    public override void Interact(GameObject caller)
    {
       if (_switch_animator.GetBool("Close") == false)
        {
            _switch_animator.SetBool("Close", true);
            isClosed = true;
        }

       else
        {

            _switch_animator.SetBool("Close", false);
            isClosed = false;
        }
    }
    void Start()
    {
        _switch_animator.SetBool("Close", false);
        isClosed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //PROBLEMA: Il cambio del colore ha un certo delay rispetto all'animazione conviene quindi farlo tramite animator e non tramite script

        switch_snapped = GameObject.FindGameObjectWithTag("switch").GetComponent<Switch_Snapper>().IsSnapped;
        if (switch_snapped == false)
        {
            SpheresMat.DisableKeyword("_EMISSION");
            SpheresMat.SetColor("_EMISSION", disconnected_color);

        }

        else
        {
            if (isClosed == true) 
            {
               SpheresMat.EnableKeyword("_EMISSION");
                SpheresMat.SetColor("_EmissionColor", on_color);
            }

            else
            {
                SpheresMat.EnableKeyword("_EMISSION");
                SpheresMat.SetColor("_EmissionColor", off_color);

            }

        }
        
    }
}
