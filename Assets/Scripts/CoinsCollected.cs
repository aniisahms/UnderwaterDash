using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCollected : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsCollectedText = null;
    [HideInInspector] public float coinsCount;

    // Start is called before the first frame update
    void Start()
    {
        coinsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinsCollectedText.text = coinsCount.ToString();
    }
}
