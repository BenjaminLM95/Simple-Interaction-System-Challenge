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
 

    private void Awake()
    {
        moveSpeed = 2.5f;
        playerRigidbody = this.GetComponent<Rigidbody2D>();       
        Actions.MoveEvent += UpdateMoveVector;      
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePlayerMovement();       
 
    }

    private void Update()
    {
        HandleAnimation();


        
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
    }

    public void ResumeSpeed() 
    {       
        moveSpeed = 2.5f;        
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
