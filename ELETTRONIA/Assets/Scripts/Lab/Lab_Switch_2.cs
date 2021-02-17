using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Switch_2 : Interactable
{
    private int State;
    public Animator LabSwitch_SW;
    public Animator Switch;
    public Animator Current;
    public ParticleSystem Sphere1;
    public ParticleSystem Sphere2;
    public ParticleSystem Sphere3;
    public ParticleSystem Sphere4;
    public override void Interact(GameObject caller)
    {
        if (State == 0)
        {
            LabSwitch_SW.SetInteger("State", 1);
            Current.SetInteger("Current_State", 1);

            Sphere1.Play();
            Sphere2.Play();
            Sphere3.Play();
            Sphere4.Play();

            State = 1;
        }

        else if (State == 1)
        {
            LabSwitch_SW.SetInteger("State", 2);
            Current.SetInteger("Current_State", 2);
            Switch.SetBool("Switch", true);
            State = 2;
        }

        else if (State == 2)
        {
            LabSwitch_SW.SetInteger("State", 3);
            Current.SetInteger("Current_State", 0);
            Switch.SetBool("Switch", false);
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
