using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
