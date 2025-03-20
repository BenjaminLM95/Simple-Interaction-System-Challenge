using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite oldSprite; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Actions.ChangeSprite += ChangeSprite;
        Actions.ReturnSprite += ReturnSprite; 
    }
    

    public void ChangeSprite() 
    {
        spriteRenderer.sprite = newSprite;
    }

    public void ReturnSprite() 
    {
        spriteRenderer.sprite = oldSprite;
    }

    private void OnDisable()
    {
        Actions.ChangeSprite -= ChangeSprite;
        Actions.ReturnSprite -= ReturnSprite;
    }


}
