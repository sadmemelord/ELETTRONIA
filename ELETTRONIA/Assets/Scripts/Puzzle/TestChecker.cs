using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChecker : MonoBehaviour
{
    RaycastHit hit;
    public Vector3 _center;
    public Vector3 _direction;
    public float _range;
    private bool _power_test;

    GameObject res_big;
    GameObject res_medium;
    GameObject res_small;
    GameObject pointed_object;
    public Material Wires;
    public Renderer _renderer_center;
    public Renderer _renderer_ring1;
    public Renderer _renderer_ring2;
    public Color color_big;
    public Color color_medium;
    public Color color_small;


    // Start is called before the first frame update
    void Start()
    {
        _center = gameObject.transform.position;
        _direction = gameObject.transform.right;
        _range = 100;
        
        res_big = GameObject.FindWithTag("res_big");
        res_medium = GameObject.FindWithTag("res_medium");
        res_small = GameObject.FindWithTag("res_small");
       
    }

    // Update is called once per frame
    void Update()
    {
        _power_test = GameObject.FindWithTag("generator_test").GetComponent<GeneratorTest>().Power_Tester;
        Ray ray = new Ray(_center, _direction);
        Debug.DrawRay(_center, _direction, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _range))
            {
                pointed_object = hit.transform.gameObject;
                if(pointed_object == res_big && _power_test == true)
                    {
                        _renderer_ring1.material.EnableKeyword("_EMISSION");
                        _renderer_ring2.material.EnableKeyword("_EMISSION");
                        _renderer_center.material.SetColor("_EmissionColor", color_big);
                        _renderer_center.material.EnableKeyword("_EMISSION");
                        Wires.EnableKeyword("_EMISSION");
                    }
               else if (pointed_object == res_medium && _power_test == true)
                    {
                        _renderer_ring1.material.EnableKeyword("_EMISSION");
                        _renderer_ring2.material.EnableKeyword("_EMISSION");
                        _renderer_center.material.SetColor("_EmissionColor", color_medium);
                        _renderer_center.material.EnableKeyword("_EMISSION");
                        Wires.EnableKeyword("_EMISSION");
            }
              else  if (pointed_object == res_small && _power_test == true)
                    {
                        _renderer_ring1.material.EnableKeyword("_EMISSION");
                        _renderer_ring2.material.EnableKeyword("_EMISSION");
                        _renderer_center.material.SetColor("_EmissionColor", color_small);
                        _renderer_center.material.EnableKeyword("_EMISSION");
                         Wires.EnableKeyword("_EMISSION");
            }

              else
            {
                _renderer_ring1.material.DisableKeyword("_EMISSION");
                _renderer_ring2.material.DisableKeyword("_EMISSION");
                _renderer_center.material.DisableKeyword("_EMISSION");
                Wires.DisableKeyword("_EMISSION");

            }

        }

        }
}
