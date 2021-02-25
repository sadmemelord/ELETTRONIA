﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Interactable
{
    public bool Power = false;
    public AudioSource PowerON;


    public Renderer _renderer;


    public override void Interact(GameObject caller)
    {
        Power = !Power;

        if (Power == false)
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
