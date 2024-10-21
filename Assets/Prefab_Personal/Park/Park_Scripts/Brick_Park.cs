using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Park : MonoBehaviour
{
    public int hitPoints;
    
    public GameObject ball;
    public GameObject bar;
    public Sprite[] crackSprites; // Assign the crack sprites in the Inspector
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<GameObject>();
        bar = GetComponent<GameObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Assign hitPoints based on brick color
        switch (gameObject.tag) // Assume you have tagged bricks by their color
        {
            case "PurpleBrick":
            case "RedBrick":
                hitPoints = 3; // 3 hits for purple and red bricks
                break;
            case "OrangeBrick":
            case "YellowBrick":
                hitPoints = 2; // 2 hits for orange and yellow bricks
                break;
            case "GreenBrick":
            case "BlueBrick":
                hitPoints = 1; // 1 hit for green and blue bricks
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D inCollision)
    {
        if (inCollision.gameObject.layer == 7)
        {
            this.gameObject.SetActive(false);
        }
        else if (inCollision.gameObject == bar)
        {
            //게임 ??
        }
    }
    
    // Call this method when the ball hits the brick
    public void TakeDamage()
    {
        hitPoints--;

        if (hitPoints > 0)
        {
            // Only update sprite for bricks with more than 1 HP (purple, red, orange, yellow)
            if (crackSprites.Length > 0 && (gameObject.tag == "PurpleBrick" || gameObject.tag == "RedBrick" ||
                                            gameObject.tag == "OrangeBrick" || gameObject.tag == "YellowBrick"))
            {
                spriteRenderer.sprite = crackSprites[hitPoints - 1]; // Show appropriate cracked sprite
            }
        }
        else
        {
            // Destroy the brick when HP reaches 0
            Destroy(gameObject);
        }
    }
}