using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    public bool correct_power;
    public bool correct_switch;
    public bool switch_snap;
    public bool lamp_snap;
    public static bool solved;
    public Renderer LampRenderer;
    public Material WireEmission;    
    RaycastHit hit;
    public Vector3 _center;
    public Vector3 _direction;
    public float _range;
    
    GameObject correct_res;
    GameObject pointed_object;
    

    // Start is called before the first frame update
    void Start()
    {
        LampRenderer.material.DisableKeyword("_EMISSION");
        _center = gameObject.transform.position;
       _direction = gameObject.transform.right;
        _range = 100;
        correct_res = GameObject.FindWithTag("res_small");
    }

    // Update is called once per frame
    void Update()
    {

        correct_power = GameObject.FindWithTag("generator").GetComponent<Generator>().Power;
        correct_switch = GameObject.FindWithTag("switch").GetComponent<Switch>().isClosed;
        switch_snap = GameObject.FindWithTag("switch").GetComponent<Switch_Snapper>().IsSnapped;
        lamp_snap = GameObject.FindWithTag("lamp").GetComponent<LampSnapper>().IsSnapped;

        Ray PuzzleCheckerRay = new Ray(_center, _direction);
        Debug.DrawRay(_center, _direction, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(PuzzleCheckerRay, out hit, _range))
        {
            pointed_object = hit.transform.gameObject;
            if ((pointed_object == correct_res) && (correct_power == true) && (correct_switch == true) && (switch_snap == true) && (lamp_snap == true) && solved == false)
            {
              
               // LampRenderer.material.EnableKeyword("_EMISSION");
               // WireEmission.EnableKeyword("_EMISSION");
                
                solved = true;
            }
            else if ((pointed_object != correct_res) || (correct_power == false) || (correct_switch == false) || (switch_snap == false) || (lamp_snap == false)) {

                //LampRenderer.material.DisableKeyword("_EMISSION");
                //WireEmission.DisableKeyword("_EMISSION");
                solved = false;
            }
        }
    }
}

