using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    Vector3 startPos;

    public float newPackageInterval = 3f;
    public float dropHeight = .1f;
    float _interval = 0f;

    [SerializeField]
    private MoveBox _moveBoxPrefab;

    public static BoxPool Instance { get; private set; }

    private Queue<MoveBox> _movingBoxes = new Queue<MoveBox>();

    private void Awake()
    {
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
            SpawnBox();
            _interval = 0f;
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

    public void ReturnToPool(MoveBox box)
    {
        box.gameObject.SetActive(false);
        _movingBoxes.Enqueue(box);
    }

    void SpawnBox()
    {
        //=> Instantiate(_boxPrefab, startPos, Quaternion.identity);
        MoveBox box = Get();
        box.transform.position = startPos;
        box.transform.rotation = Quaternion.identity;
        box.gameObject.SetActive(true);
    }
}
