using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    Rigidbody _rb;
    public float _speed = 4f;
    Vector3 _move;
    bool boost = true;
    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
        _move = new Vector3(2f, 0f, 0f);
    }

    private void Update()
    {



        _rb.velocity = new Vector3(_speed, 0f);
        //if (boost)
        //{
        //    _rb.AddForce(_move * _speed * Time.deltaTime);
        //    boost = false;
        //}
        //else
        //{
        //    _rb.AddForce(_move * _speed * Time.deltaTime);
        //}

        print($"Velocity = {_rb.velocity}");
        
    }

}
