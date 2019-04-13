using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    Vector3 startPos;
    SortedList<int, decimal> _priceList;
    public float newPackageInterval = 3f;
    public float dropHeight = .1f;
    float _interval = 0f;
    public int NumBoxes = 10;
    PriceManager _priceManager;
    decimal _total = 0;
    [SerializeField]
    private MoveBox _moveBoxPrefab;

    public static BoxPool Instance { get; private set; }

    private Queue<MoveBox> _movingBoxes = new Queue<MoveBox>();

    private void Awake()
    {
        _priceList = new SortedList<int, decimal>();
        _priceManager = gameObject.AddComponent<PriceManager>();
        startPos = new Vector3(0.049f, 1.048f + dropHeight, 0f);
        Instance = this;
        SpawnBox();
    }

    public MoveBox Get()
    {

        if (_movingBoxes.Count == 0)
        {
            AddBoxes(1);
        }

        return _movingBoxes.Dequeue();
    }

    private void Update()
    {
        if (_interval > newPackageInterval)
        {
            _interval = 0f;
            SpawnBox();
        }
        _interval += Time.deltaTime;
    }

    void AddBoxes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            MoveBox box = Instantiate(_moveBoxPrefab);
            box.gameObject.SetActive(false);
            _movingBoxes.Enqueue(box);
        }
    }

    int _boxProcessedNo = 0;

    public void ReturnToPool(MoveBox box)
    {
        _total += box.Price;
        if (++_boxProcessedNo > NumBoxes)
        {
            printReceipt();
            Destroy(box.gameObject);
            _priceList.Clear();
            _movingBoxes.Clear();
            Application.Quit();
            return;
        }
        _priceList.Add(_boxProcessedNo, box.Price);
        box.gameObject.SetActive(false);
        _movingBoxes.Enqueue(box);
    }

    int boxCount = 0;
    void SpawnBox()
    {
        boxCount++;
            

        MoveBox box = Get();
        box.transform.position = startPos;
        box.transform.rotation = Quaternion.identity;        
        box.gameObject.SetActive(true);
    }

    int itemNo = 1;
    void printReceipt()
    {
        IList<decimal> prices = _priceList.Values;

        print("=================");
        print("PRICE LIST START");
        print("=================");
        foreach (var price in prices)
        {
            print($"Item No{itemNo++}: {price:C}");
        }
        print("=================");
        print($"TOTAL PRICE {_total:C}");
        print("=================");

    }
}
