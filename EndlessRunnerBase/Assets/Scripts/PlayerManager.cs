using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Variables
    public int health;
    public float maxY, minY, increment;
    public float speed;
    public GameObject bubbleEffect;

    private Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(-7.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CheckHealth();
    }

    // Check health
    void CheckHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    // Move
    void MovePlayer()
    {
        // Move
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Controls
        if (transform.position.y < maxY && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Instantiate(bubbleEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
            //transform.position = targetPos;
        } 
        else if (transform.position.y > minY && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            Instantiate(bubbleEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
            //transform.position = targetPos;
        }
    }
}
