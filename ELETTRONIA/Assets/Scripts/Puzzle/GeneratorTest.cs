using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTest : Interactable
{
    public Renderer _renderer;
    public bool Power_Tester;
    public AudioSource PowerON;

    public override void Interact(GameObject caller)
    {
        Power_Tester = !Power_Tester;

        if (Power_Tester == false)
        {
            _renderer.material.DisableKeyword("_EMISSION");
        }

        else
        {
            _renderer.material.EnableKeyword("_EMISSION");
            PowerON.Play();
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        _renderer.material.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
