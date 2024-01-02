using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public float maxEnergy;

    [HideInInspector] public float energy;

    [SerializeField] private Slider energyBar = null;
    [SerializeField] private GameObject player;
     
    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (energy > 0)
        {
            energy -= Time.deltaTime;
            // Debug.Log("Energy: " + energy);
        }
        else if (energy <= 0)
        {
            Destroy(player.gameObject);
        }

        energyBar.value = energy / maxEnergy;
    }
}
