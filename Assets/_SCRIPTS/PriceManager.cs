using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PriceManager : MonoBehaviour
{

    public Text _priceTag;
    private decimal _price;

    // Update is called once per frame
    void Update()
    {
        _priceTag.transform.position = Camera.main.WorldToScreenPoint(transform.position);

        // INITIALIZE WITH A RANDOM PRICE FOR VISUALISATION PURPOSES
        _price =(decimal)(Random.Range(1, 10) + Random.Range((float).01, (float).99));
        Price = _price;
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
