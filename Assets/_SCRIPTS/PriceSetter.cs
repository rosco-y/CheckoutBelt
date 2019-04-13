using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceSetter : MonoBehaviour
{

    public Text _priceTag;
    private decimal _price;
    // Update is called once per frame
    private void Start()
    {
        // SET RANDOM VALUE FOR TEST-VISULATION PURPOSES.
        Price = (decimal)Random.Range(0, (float).99) + Random.Range(1, 100);
    }
    void Update()
    {
        _priceTag.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    public decimal Price
    {
        set
        {
            _price = value;
            _priceTag.text = $"{_price:C}";
        }
        get
        {
            return _price;
        }
    }
}
