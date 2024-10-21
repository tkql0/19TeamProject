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
        switch (gameObject.tag)
        {
            case "PurpleBrick":
            case "RedBrick":
                hitPoints = 3;
                break;
            case "OrangeBrick":
            case "YellowBrick":
                hitPoints = 2;
                break;
            case "GreenBrick":
            case "BlueBrick":
                hitPoints = 1;
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D inCollision)
    {
        if (inCollision.gameObject.layer == 7)
        {
            TakeDamage();
        }
    }
    
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
        else // hitpoints <= 0
        {
            Destroy(gameObject);//setactive(false)
            
            //Add score
            GameManager.Instance.currentScore += 10;

            //if bricks is null call gave over methods from game manager
            if (FindObjectsOfType<Brick_Park>().Length == 1) // Assuming this is the last brick
            {
                GameManager.Instance.GameOver(true);
            }
            
            //player 1, player 2 get different score
            
        }
    }
}