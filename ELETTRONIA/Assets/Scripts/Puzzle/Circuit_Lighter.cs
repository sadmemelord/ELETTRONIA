using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit_Lighter : MonoBehaviour

   
{
    public Animator Circuit_Light;
   public Material Wires;
   public Renderer Lamp;

    // Start is called before the first frame update
    void Start()
    {
        Wires.DisableKeyword("_EMISSION");
        //Lamp.material.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        if (PuzzleChecker.solved == true)
        {
            Wires.EnableKeyword("_EMISSION");
            Circuit_Light.SetBool("Circuit_Current", true);
            //Wires.EnableKeyword("_EMISSION");
            //Lamp.material.EnableKeyword("_EMISSION");
        }
        

        
    }
}
