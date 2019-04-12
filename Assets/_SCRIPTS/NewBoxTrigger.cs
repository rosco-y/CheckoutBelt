using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBoxTrigger : MonoBehaviour
{
    Vector3 startPos;
    //public Transform _boxPrefab;
    /*
     *  0.049, 1.048, 0
     */
    private void Awake()
    {
        startPos = new Vector3(0.049f, 1.048f, 0f);
    }

    private void Start()
    {
        SpawnBox();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // spawn a new box
            //Instantiate(_boxPrefab, startPos, Quaternion.identity);    
            SpawnBox();

        }
    }

    void SpawnBox()
    {
        //=> Instantiate(_boxPrefab, startPos, Quaternion.identity);
        MoveBox box = BoxPool.Instance.Get();
        box.transform.position = startPos;
        box.transform.rotation = Quaternion.identity;
        box.gameObject.SetActive(true);
    }

}
