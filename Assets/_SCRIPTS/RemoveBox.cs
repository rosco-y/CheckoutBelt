using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            MoveBox box = other.GetComponent<MoveBox>();            
            BoxPool.Instance.ReturnToPool(box);
        }
    }


}
