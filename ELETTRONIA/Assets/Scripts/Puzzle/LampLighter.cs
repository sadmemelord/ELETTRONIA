using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLighter : MonoBehaviour
{
    public GameObject Lamp;
    public Color on_color;
    public Color off_color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PuzzleChecker.solved == true)
        {
            //cambio materiale
            Lamp.SetActive(true);
        }
        else
        {
            Lamp.SetActive(false);
        }
    }
}
