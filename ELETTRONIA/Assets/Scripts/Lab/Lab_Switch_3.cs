using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Switch_3 : Interactable
{
    private int State;
    public Animator LabSwitch_SW;
    public Renderer Lamp;
    public ParticleSystem Sphere1;
    public ParticleSystem Sphere2;
    public ParticleSystem Sphere3;
    public ParticleSystem Sphere4;
    public override void Interact(GameObject caller)
    {
        if (State == 0)
        {
            LabSwitch_SW.SetInteger("State", 1);
            Lamp.material.EnableKeyword("_EMISSION");

            Sphere1.Play();
            Sphere2.Play();
            Sphere3.Play();
            Sphere4.Play();

            State = 1;
        }

        else if (State == 1)
        {
            LabSwitch_SW.SetInteger("State", 2);
            Lamp.material.DisableKeyword("_EMISSION");

            State = 0;
            Sphere1.Stop();
            Sphere2.Stop();
            Sphere3.Stop();
            Sphere4.Stop();
        }

        else
        {
            State = 0;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Sphere1.Stop();
        Sphere2.Stop();
        Sphere3.Stop();
        Sphere4.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
