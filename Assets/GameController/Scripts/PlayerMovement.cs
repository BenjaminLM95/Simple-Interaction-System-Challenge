using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    private Vector2 moveDirection = Vector2.zero; 
    private float moveSpeed;    
       
    public GameObject spriteObject;
    public Animator _myAnimator;

    public bool isOnDialogue; 
 

    private void Awake()
    {
        moveSpeed = 2.5f;
        playerRigidbody = this.GetComponent<Rigidbody2D>();       
        Actions.MoveEvent += UpdateMoveVector;
        isOnDialogue = false;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isOnDialogue)
        HandlePlayerMovement();       
 
    }

    private void Update()
    {
        if (!isOnDialogue)
        {            
            _myAnimator.speed = 1; 

            HandleAnimation();
        }
        else
        {            
            _myAnimator.speed = 0;
        }


        
    }

    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveDirection = InputVector;       
    }

    public void HandlePlayerMovement() 
    {      
        playerRigidbody.MovePosition(playerRigidbody.position + moveDirection * Time.fixedDeltaTime * moveSpeed);
        
    }

    public void MoveFaster() 
    {        
       moveSpeed = 8f;
        _myAnimator.speed = 3;
    }

    public void ResumeSpeed() 
    {       
        moveSpeed = 2.5f;
        _myAnimator.speed = 1;
    }

    

    private void OnEnable()
    {
        Actions.SpaceBarAction += MoveFaster;
        Actions.ResumeSpeed += ResumeSpeed; 
    }

    private void OnDisable()
    {
        Actions.MoveEvent -= UpdateMoveVector; 
        Actions.SpaceBarAction -= MoveFaster;
        Actions.ResumeSpeed -= ResumeSpeed; 
    }

    private void HandleAnimation()
    {
        if (moveDirection.magnitude != 0)
        {
            _myAnimator.SetBool("isMoving", true);
            _myAnimator.SetFloat("Horizontal", moveDirection.x);
            _myAnimator.SetFloat("Vertical", moveDirection.y);
            _myAnimator.SetFloat("LastHorizontal", moveDirection.x);
            _myAnimator.SetFloat("LastVertical", moveDirection.y); 

        }
        else 
        {
            _myAnimator.SetBool("isMoving", false); 
            
        }


    }
}
