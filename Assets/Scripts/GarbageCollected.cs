using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GarbageCollected : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI garbageCollectedText = null;
    [HideInInspector] public float garbageCount;

    // Start is called before the first frame update
    void Start()
    {
        garbageCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        garbageCollectedText.text = garbageCount.ToString();
    }
}
