using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private Rigidbody2D RBplayer;
    [SerializeField] private LayerMask Groundcheck;
    [SerializeField] private bool _isGround;
    [SerializeField]   private float jumpPower = 0.0f;
    [SerializeField] PhysicsMaterial2D BounceMat,normalMat;
    [SerializeField] private Animator animator;
   
    
    private bool _canjump = true;
    private float _horizontal;
    private Vector3 _baseScale;
    private void Awake()
    {
        _baseScale = transform.localScale;
    }

    private void OnEnable()
    {
        Heath.PlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        Heath.PlayerDead -= OnPlayerDead;
    }

    private void Start()
    {
        RBplayer = GetComponent<Rigidbody2D>(); 
    }
  
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        RBplayer.velocity =  new Vector2 ( _horizontal * walkSpeed, RBplayer.velocity.y );
        _isGround = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.4f), 0f, Groundcheck);

        if(jumpPower==0f&&_isGround)
        {
            RBplayer.velocity = new Vector2(_horizontal*walkSpeed,RBplayer.velocity.y );
        }
        if (Input.GetKey("space") && _isGround && _canjump) 
        {
            jumpPower += 0.1f;
        }
        if(jumpPower > 0f)
        {
            RBplayer.sharedMaterial = BounceMat;
        }
        else
        {
            RBplayer.sharedMaterial = normalMat;
        }
        if(jumpPower >=20f && _isGround) 
        {
            float tempx= _horizontal * walkSpeed;
            float tempy = jumpPower;
            RBplayer.velocity = new Vector2 (tempx , tempy);
            Invoke("resetvalue", 0.2f);
        }
        if(Input.GetKeyDown("space")&& _isGround && _canjump)
        {
            RBplayer.velocity =new Vector2(0f,RBplayer.velocity.y);
        }
        if(Input.GetKeyUp("space"))
        {
            if(_isGround)
            {
                RBplayer.velocity = new Vector2(_horizontal * walkSpeed,jumpPower);
                jumpPower = 0f;
            }
            _canjump = true;
        }
        Setanimation();
        FLip();
    }
    private void FixedUpdate()
    {
        RBplayer.velocity= new Vector2(_horizontal* walkSpeed,RBplayer.velocity.y);
    }
    public void resetvalue()
    {
        _canjump = false;
        jumpPower = 0.0f;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y * -0.5f), new Vector2(0.9f, 0.2f));
    }
    
    private void Setanimation()
    {
        var movement = Mathf.Abs(RBplayer.velocity.x) * Mathf.Abs(RBplayer.velocity.y);
        animator.SetFloat("movement", movement);
    }
    private void FLip()
    {
        switch (_horizontal)
        {
            case > 0:
                transform.localScale = _baseScale;
                break;
            case < 0:
                var newx = -4f * _baseScale.x;
               transform.localScale= new Vector3(newx,_baseScale.y,_baseScale.z);
                break;

        }
    }

    private void OnPlayerDead()
    {
        enabled = false;
    }
}
