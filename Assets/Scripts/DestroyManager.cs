using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            if (audioSource != null)
            {
                audioSource.Play();
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.GetComponent<CircleCollider2D>().enabled = false;
                StartCoroutine(DestoryInactiveObject());
            }
            else
            {
                Debug.Log("No audio source found.");
            }
        }
    }

    IEnumerator DestoryInactiveObject()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
