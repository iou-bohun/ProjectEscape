using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Inventory inven;
    public LayerMask itmeLayer;
    private void OnCollisionEnter(Collision collision)
    {
        if (itmeLayer.value == (itmeLayer.value | (1<< collision.gameObject.layer)))
        {
            inven.GetItem(collision.gameObject.GetComponent<Item>());
            Destroy(collision.gameObject);
        }
    }
}
