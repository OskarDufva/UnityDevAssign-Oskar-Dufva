using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Rigidbody _characterRB;
    [SerializeField] public float moveSpeed, jumpForce;

    public Animator _animator;
    private Vector2 _move;

    private float _jumpTimeStamp = 0;
    public float minJumpInterval;

    private bool _isGrounded;

    public CharacterManager characterManager;

    void Awake()
    {
        _characterRB = gameObject.GetComponent<Rigidbody>(); 
        _animator = gameObject.GetComponentInChildren<Animator>();
        characterManager = GetComponent<CharacterManager>();
    }

    void Update()
    {
        MovePlayer();
    }


    public void OnWave(InputAction.CallbackContext actionContext)
    {
       

        if (characterManager.currentCharacterType == CharacterManager.CharacterTypes.Human)
        {
            _animator.SetBool("Wave", true);
            Debug.Log("OnWave is activated by a human character");

        }
        else if (characterManager.currentCharacterType == CharacterManager.CharacterTypes.Zombie)
        {            
            _animator.SetBool("Wave", true);
            Debug.Log("OnWave is activated by a zombie character.");
        }
        else if (characterManager.currentCharacterType == CharacterManager.CharacterTypes.Dog)
        {
            _animator.SetBool("Wave", true);
            Debug.Log("OnWave is activated by a dog character.");
        }
    }

    public void OnMove(InputAction.CallbackContext moveContext)
    {
        _move = moveContext.ReadValue<Vector2>();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0, _move.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        _animator.SetFloat("MoveSpeed", movement.magnitude);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }


    }


    // Jump input with a jump cooldown to prevent multiple jumps.
    public void OnJump(InputAction.CallbackContext jumpContext)
    {
        bool jumpCooldownOver = (Time.time - _jumpTimeStamp) >= minJumpInterval;

        if (jumpCooldownOver && _isGrounded)
        {
            _jumpTimeStamp = Time.time;
            _characterRB.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            _animator.SetBool("Grounded", false);
            _isGrounded = false;
        }
        
    }


   
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            _animator.SetBool("Grounded", true);

        }
    }
}
