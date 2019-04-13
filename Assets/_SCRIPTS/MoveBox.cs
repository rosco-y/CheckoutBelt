using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveBox : MonoBehaviour
{

    public TextMeshPro _textMesh;
    decimal _price;
    Rigidbody _rb;
    public float _speed = 0.1f;
    Vector3 _move;
    public int _maxDollars;
    public int _maxQuarters;
    public int _maxDimes;


    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
        _move = new Vector3(2f, 0f, 0f);
    }

    private void Update()
    {

        _rb.velocity = new Vector3(_speed, 0f);
        //print($"Velocity = {_rb.velocity}");
        
    }

    private void OnEnable()
    {
        SetPrice();
    }

    public decimal Price
    {
        set
        {
            _price = value;
            _textMesh.text = $"{_price:C}";
        }
        get
        {
            return _price;
        }
    }

    public void SetPrice()
    {
        Price = (decimal)(Random.Range(1, 23) + Random.Range((float).01f, (float).99f));
    }

}
