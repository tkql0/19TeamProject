using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick_Park : MonoBehaviour
{
    public int hitPoints;
    
    public GameObject ball;
    public GameObject bar;
    public Sprite[] crackSprites; // Assign the crack sprites in the Inspector
    public Text currentScore;
    private SpriteRenderer spriteRenderer;
    private ItemManager itemManager;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<GameObject>();
        bar = GetComponent<GameObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemManager = GetComponent<ItemManager>();
        
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
        else //hitpoints <= 0
        {
            itemManager.SpawnRandomItem(transform.position);
            this.gameObject.SetActive(false);

            int scoreToAdd = CalculateScoreByBrick();
            GameManager.Instance.currentScore += scoreToAdd;
            AudioManager.Instance.PlayBGM(AudioManager.AudioType.HammerBGM);
            //if bricks is null call game over methods from game manager
            if (FindObjectsOfType<Brick_Park>().Length == 0) // Assuming this is the last brick
            {
                GameManager.Instance.GameOver(true);
                currentScore.text = GameManager.Instance.currentScore.ToString();
            }

        }

        // Method to calculate score based on color and size
        int CalculateScoreByBrick()
        {
            int score = 0;

            // Base score for different colors
            switch (gameObject.tag)
            {
                case "PurpleBrick":
                case "RedBrick":
                    score = 30;
                    break;
                case "OrangeBrick":
                case "YellowBrick":
                    score = 20;
                    break;
                case "GreenBrick":
                case "BlueBrick":
                    score = 10;
                    break;
            }
            
            string spriteName = spriteRenderer.sprite.name;
            
            if (gameObject.name.Contains("Large"))
            {
                score += 20; // Add more points for large bricks
            }
            else if (gameObject.name.Contains("Medium"))
            {
                score += 10; // Add points for medium bricks
            }
            else if (gameObject.name.Contains("Small"))
            {
                score += 5; // Add fewer points for small bricks
            }

            return score;
        }
    }
}