using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CowBoy_Animation : MonoBehaviour
{
    private Animator myAnimator;
    public SpriteRenderer spriteRenderer;
    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite LeftSprite;
    public Sprite RightSprite;
    private Vector2 moveVector = new Vector2();
    PlayerMovement myPlayerMovements = new PlayerMovement(); 

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void changeSprite(float x, float y) 
    {
        if(x > 0) 
        {
            spriteRenderer.sprite = RightSprite;  
        }
        else if(x < 0) 
        {
            spriteRenderer.sprite = LeftSprite; 
        }
        else 
        {
            spriteRenderer.sprite = DownSprite; 
        }

        if(y > 0) 
        {
            spriteRenderer.sprite = UpSprite;
        }
        else if (y <= 0) 
        {
            spriteRenderer.sprite = DownSprite;
        }

    }

}
