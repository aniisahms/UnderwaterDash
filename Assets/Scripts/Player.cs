using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;

    [HideInInspector] public float coinsCount = 0;
    [HideInInspector] public float garbageCount = 0;

    [SerializeField] private EnergyBar energyBar;

    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private float triggerCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }

    // Called once per physics frame
    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Obstacle")
        {
            triggerCount += 1;
            Destroy(other.gameObject);

            if (triggerCount >= 3)
            {
                Destroy(this.gameObject);
                triggerCount = 0;
            }
        }
        if (other.tag == "Garbage")
        {
            garbageCount += 1;
            Destroy(other.gameObject);
            Debug.Log("Garbage count: " + garbageCount);
        }
        if (other.tag == "Coins")
        {
            coinsCount += 5;
            Destroy(other.gameObject);
            Debug.Log("Coins count: " + coinsCount);
        }
        if (other.tag == "Energy")
        {
            energyBar.energy = energyBar.maxEnergy;
            Destroy(other.gameObject);
            Debug.Log("Energy up to max: " + energyBar.energy);
        }
    }
}
