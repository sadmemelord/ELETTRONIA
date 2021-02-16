using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior_FSM : MonoBehaviour
{
    //variables and objs
    public GameObject ThePlayer;
    public GameObject Pointed_target;
    public Animator NPCAnimator;
    private float TargetDistance;
    public float AllowedDistance;
    public GameObject TheNPC;
    private float Speed;
    public RaycastHit Shot;

    GameObject pointed_object;
    RaycastHit hit;
    public Vector3 _center;
    public Vector3 _direction;
    public float _range;

    /*private void OnTriggerStay(Collider col)
    {
        Debug.Log("Collided!");
        if (col.tag == "hub_floor")
        {
            Debug.Log("on HUB");
        }
    }*/

    //STATES
    public enum State_type
    {
        HUB, //0
        MUSEUM, //1
        LAB, //2
        PUZZLE //3
    }
    public enum SubState_type
    {
        Start_puz, //0
        Help_puz, //1
        Solved_puz, //2
        Current_mus, //3
        Resistor_mus, //4
       // Inventors_mus, //5
       Resistor_lab, //6
       Switch_lab //7
    }
    State_type current_state;
    SubState_type current_substate;

    // Start is called before the first frame update
    void Start()
    {
        current_substate = SubState_type.Current_mus;
        _range = 100;
    }

    // Update is called once per frame
    void Update()
    {   //check what's underneath with a raycast
        _center = gameObject.transform.position;
        _direction = -gameObject.transform.up;
        Ray ray = new Ray(_center, _direction);
        Debug.DrawRay(_center, _direction, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _range))
        {
            pointed_object = hit.transform.gameObject;

            //update state according to tag
            
                if(pointed_object.tag == "hub_floor")
                {
                    current_state = State_type.HUB;
                    Debug.Log("on HUB");
                }
                if (pointed_object.tag == "museum_floor")
                {
                    current_state = State_type.MUSEUM;
                }
                if (pointed_object.tag == "lab_floor")
                {
                    current_state = State_type.LAB;
                }
                if (pointed_object.tag == "puzzle_floor")
                {
                    current_state = State_type.PUZZLE;
                }
            }
            switch (current_state)
        {
            case State_type.HUB:
                {
                    //npc follow script
                    transform.LookAt(ThePlayer.transform);
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                    {
                        TargetDistance = Shot.distance;
                        if (TargetDistance >= AllowedDistance)
                        {
                            NPCAnimator.SetBool("Idle", false);
                            Speed = 0.065f;

                            //animation  for follow
                            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, Speed);
                        }
                        else
                        {
                            Speed = 0f;
                            NPCAnimator.SetBool("Idle", true);

                        }
                    }
                    //Debug.Log("HUB");
                    break;
                }
            case State_type.MUSEUM:
                {
                    //Debug.Log("MUSEUM");
                    //check for substate
                    switch (current_substate)
                    {
                        case SubState_type.Current_mus:
                            Debug.Log("in museum");
                            //npc go to script
                            Pointed_target = GameObject.Find("Empty_Mus_Current");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.065f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                }
                            }
                            break;
                    }
                    break;
                }
            case State_type.LAB:
                {
                    //Debug.Log("LAB");
                    //check for substate
                    break;
                }
            case State_type.PUZZLE:
                {
                    Debug.Log("PUZZLE");
                    //check for substate

                    switch (current_substate)
                    {
                        case SubState_type.Start_puz:
                            Debug.Log("puzzle start");
                            //npc go to script
                            Pointed_target = GameObject.Find("Empty_Puzzle_Start");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.065f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);

                                }
                            }
                            break;

                        
                           
                    }
                    break;
                }
        }

    }
}
