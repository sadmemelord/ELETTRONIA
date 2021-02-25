using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PhysicsGrabbable : Grabbable
{
    public static bool IsGrabbed = false;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private GameObject _gameobject;
    Grabbable grabbed_object;
    public GameObject _fpsCamera;
    public GameObject Body;
    public GameObject Hub_Empty, Mus_Empty1, Mus_Empty2, Lab_Empty1, Lab_Empty2, Lab_Empty3, Circuit_Empty1, Circuit_Empty2, Circuit_Empty3;



    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
       _gameobject = GetComponent<GameObject>();
       

    }

    //PROBLEMA: le variabili is snapped static cambiate in questo script cambiano per tutti gli oggetti anche se ne viene grabbato uno diverso
    //le variabili is snapped dei singoli script invece non si resettano e quindi possono generare problemi (vedi colore sfere interruttore)
    //questa cosa va risolta e il metodo più becero può essere creare uno script Physics Grabbable DIVERSO per ogni oggetto in modo da separare le interazioni

    public override void Grab(GameObject grabber)
    {

        IsGrabbed = true;
        Snapper.IsSnapped_static = false;
        LampSnapper.IsSnapped_static = false;
        _collider.enabled = true;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //_rigidbody.isKinematic = true; //permette movimento libero
        _rigidbody.useGravity = false;
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Hub_Empty.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Mus_Empty1.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Mus_Empty2.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Lab_Empty1.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Lab_Empty2.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Lab_Empty3.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Circuit_Empty1.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Circuit_Empty2.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(Body.GetComponent<Collider>(), Circuit_Empty3.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Hub_Empty.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Mus_Empty1.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Mus_Empty2.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Lab_Empty1.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Lab_Empty2.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Lab_Empty3.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Circuit_Empty1.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Circuit_Empty2.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Circuit_Empty3.GetComponent<Collider>(), true);



    }

    public override void Drop()
    {

        IsGrabbed = false;
        Snapper.IsSnapped_static = false;
        LampSnapper.IsSnapped_static = false;
        _collider.enabled = true;
        _rigidbody.constraints = RigidbodyConstraints.None;
        //_rigidbody.isKinematic = false; //lo fa tornare soggetto alla gravità
        _rigidbody.useGravity = true;

    }
}
