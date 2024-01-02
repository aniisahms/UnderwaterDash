using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public GameObject fingerPoint;
    
    // [HideInInspector] public float coinsCount;

    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private GarbageCollected garbageCollected;
    [SerializeField] private CoinsCollected coinsCollected;

    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private float triggerCount;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // coinsCount = 0;
        triggerCount = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        // float directionY = Input.GetAxisRaw("Vertical");
        float directionY = fingerPoint.transform.position.y;
        // playerDirection = new Vector2(0, directionY).normalized;
        playerDirection = new Vector2(0, directionY);
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
            // Destroy(other.gameObject);

            if (triggerCount >= 3)
            {
                Destroy(this.gameObject);
                // triggerCount = 0;
                // Debug.Log("Trigger count: " + triggerCount);
            }
        }
        else if (other.tag == "Garbage")
        {
            garbageCollected.garbageCount += 1;
            // Destroy(other.gameObject);
            // Debug.Log("Garbage count: " + garbageCollected.garbageCount);
        }
        else if (other.tag == "Coins")
        {
            // coinsCount += 5;
            coinsCollected.coinsCount += 5;
            // Destroy(other.gameObject);
            // Debug.Log("Coins count: " + coinsCount);
        }
        else if (other.tag == "Energy")
        {
            energyBar.energy = energyBar.maxEnergy;
            // Destroy(other.gameObject);
            Debug.Log("Energy up to max: " + energyBar.energy);
        }
    }
}
