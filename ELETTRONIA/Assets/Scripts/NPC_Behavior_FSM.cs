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
    public static bool end_dialogue;
    private GameObject Target_Hub;
    public Renderer kirchbot_bulb;

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
       Switch_lab, //7
       Lamp_lab //8
    }
    public static State_type current_state;
    public static SubState_type current_substate;

    // Start is called before the first frame update
    void Start()
    {
        current_substate = SubState_type.Current_mus; //can change to debug
        Target_Hub = GameObject.Find("Target_Hub");
        _range = 100;
        end_dialogue = false;
    }

    // Update is called once per frame
    void Update()
    {   //check what's underneath with a raycast
        _center = gameObject.transform.position;
        _direction = -gameObject.transform.up;
        Ray ray = new Ray(_center, _direction); // raycast generated under kirchbot
        Debug.DrawRay(_center, _direction, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _range))
        {
            pointed_object = hit.transform.gameObject;

            //update state according to tag
            
                if(pointed_object.tag == "hub_floor")
                {
                    current_state = State_type.HUB;
                    //Debug.Log("on HUB");
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
                    kirchbot_bulb.material.DisableKeyword("_EMISSION");
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                    {
                        TargetDistance = Shot.distance;
                        if (TargetDistance >= AllowedDistance)
                        {
                            NPCAnimator.SetBool("Idle", false);
                            Speed = 0.07f;

                            //animation  for follow
                            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, Speed);
                        }
                        else
                        {
                            Speed = 0f;
                            kirchbot_bulb.material.EnableKeyword("_EMISSION");
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
                            kirchbot_bulb.material.DisableKeyword("_EMISSION");
                            Pointed_target = GameObject.Find("Target_Mus_Current");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (end_dialogue == true)
                                    {
                                        current_substate = SubState_type.Resistor_mus;
                                        end_dialogue = false;
                                    }
                                }
                            }
                            break;

                        case SubState_type.Resistor_mus:
                            //npc go to script
                            kirchbot_bulb.material.DisableKeyword("_EMISSION");
                            Pointed_target = GameObject.Find("Target_Mus_Res");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (end_dialogue == true)
                                    {
                                        current_substate = SubState_type.Resistor_lab;
                                        //needs to teleport to LAB or to HUB
                                        gameObject.transform.position = Target_Hub.transform.position;
                                        end_dialogue = false;
                                    }
                                }
                            }
                            break;

                    }
                    break;
                }
            case State_type.LAB:
                {
                    Debug.Log("in LAB");
                    //check for substate
                    kirchbot_bulb.material.DisableKeyword("_EMISSION");
                    switch (current_substate)
                        {
                        case SubState_type.Resistor_lab: //goes to resistor table and waits in idle for end_dialogue
                            Pointed_target = GameObject.Find("Target_Lab_Res");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (end_dialogue == true)
                                    {
                                        current_substate = SubState_type.Switch_lab;
                                        end_dialogue = false;
                                    }
                                }
                            }
                            break;

                        case SubState_type.Switch_lab: //goes to switch table and waits in idle for end_dialogue
                            Pointed_target = GameObject.Find("Target_Lab_Switch");
                            kirchbot_bulb.material.DisableKeyword("_EMISSION");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (end_dialogue == true)
                                    {
                                        current_substate = SubState_type.Lamp_lab;
                                        end_dialogue = false;
                                    }
                                }
                            }
                            break;

                        case SubState_type.Lamp_lab:
                            Pointed_target = GameObject.Find("Target_Lab_Lamp");
                            kirchbot_bulb.material.DisableKeyword("_EMISSION");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (end_dialogue == true)
                                    {
                                        current_substate = SubState_type.Start_puz;
                                        end_dialogue = false;
                                        gameObject.transform.position = Target_Hub.transform.position;
                                    }
                                }
                            }
                            break;
                    }
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
                            kirchbot_bulb.material.DisableKeyword("_EMISSION");
                            //npc go to script
                            Pointed_target = GameObject.Find("Target_Puzzle_Start");
                            transform.LookAt(Pointed_target.transform);
                            AllowedDistance = 0.2f;
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (end_dialogue == true)
                                    {
                                        current_substate = SubState_type.Help_puz;
                                        end_dialogue = false;
                                    }
                                }
                            }
                            break;

                        case SubState_type.Help_puz:
                            Pointed_target = GameObject.Find("Target_Puzzle_Help");
                            kirchbot_bulb.material.DisableKeyword("_EMISSION");
                            transform.LookAt(Pointed_target.transform);
                            AllowedDistance = 0.2f;
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (PuzzleChecker.solved == true)
                                    {
                                        current_substate = SubState_type.Solved_puz;
                                        end_dialogue = false;
                                    }
                                }
                            }
                            break;

                        case SubState_type.Solved_puz:
                            Pointed_target = GameObject.Find("Target_Puzzle_Solved");
                            kirchbot_bulb.material.DisableKeyword("_EMISSION");
                            transform.LookAt(Pointed_target.transform);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                            {
                                TargetDistance = Shot.distance;
                                if (TargetDistance >= AllowedDistance)
                                {
                                    NPCAnimator.SetBool("Idle", false);
                                    Speed = 0.07f;

                                    //animation  for follow
                                    transform.position = Vector3.MoveTowards(transform.position, Pointed_target.transform.position, Speed);
                                }
                                else
                                {
                                    Speed = 0f;
                                    kirchbot_bulb.material.EnableKeyword("_EMISSION");
                                    transform.LookAt(ThePlayer.transform);
                                    NPCAnimator.SetBool("Idle", true);
                                    if (end_dialogue == true)
                                    {
                                        current_substate = SubState_type.Current_mus;
                                        end_dialogue = false;
                                        gameObject.transform.position = Target_Hub.transform.position;
                                    }
                                }
                            }
                            break;

                        
                           
                    }
                    break;
                }
        }

    }
}
