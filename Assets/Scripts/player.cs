using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D RBplayer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 8f;
    [SerializeField] private float xJump = 10f;
    [SerializeField] private float yJump = 15f;
    [SerializeField] private float wallSlidingspeed = 4f;
    [Header("variable")]
    private float _horizontal;
    private Vector3 _baseScale;
    private bool _CanDBjump = false;
    private bool _canwallsliding = false;



  
    private bool _isWallsliding;

    [Header("Collision info")]
    [SerializeField] private Transform Groundcheck;
    [SerializeField] private Transform wallcheck;
    [SerializeField] private LayerMask Groundlayer;
    [SerializeField] private float checkRadius;

    //comit test github

    private void Awake()
    {
      _baseScale = transform.localScale;    
    }
    private void Start()
    {
        RBplayer=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        RBplayer.velocity = new Vector2(_horizontal * speed, RBplayer.velocity.y);
        if (Input.GetButtonDown("Jump")) 
        {
            if(_canwallsliding)
            {
                JumpFromWall();
            }
            if (IsGround())
            {
                jump();
                _CanDBjump = true;
            }
            else
            {
                if (_CanDBjump)
                {
                    _CanDBjump = false;
                    jump();
                }
            }
        }
        if (!IsGround() && _horizontal == 0 && isWalldetected())
        {
            _canwallsliding = true;
        }
        else
        {
            _canwallsliding = false;    
        }
        setAnimation();
        flip();
    }
    private void FixedUpdate()
    {
        //move horizontal
           RBplayer.velocity  = new Vector2(_horizontal*speed, RBplayer.velocity.y);    

        //check animation
        if(_canwallsliding)
        {
            _isWallsliding = true;
            RBplayer.velocity = new Vector2(RBplayer.velocity.x, Mathf.Clamp(RBplayer.velocity.y, -wallSlidingspeed, float.MaxValue));
        }
        else
        {
            _isWallsliding = false;
        }
    }
    private void setAnimation()
    {
        var movement = Mathf.Abs(RBplayer.velocity.x) +Mathf.Abs(RBplayer.velocity.y);
        anim.SetFloat("movement", movement);
        anim.SetBool("isGround", IsGround());
        anim.SetFloat("yVelocity",RBplayer.velocity.x);
        anim.SetBool("isWalling", _isWallsliding);
    }
  
    private bool isWalldetected()
    {
        return Physics2D.OverlapCircle(wallcheck.position, checkRadius, Groundlayer);
    }
    private void jump()
    {

        RBplayer.velocity = new Vector2(RBplayer.velocity.x, jumpPower);
    }
  
    private bool IsGround()
    {
        return Physics2D.OverlapCircle(Groundcheck.position, checkRadius, Groundlayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Groundcheck.position, checkRadius);
        Gizmos.DrawWireSphere(wallcheck.position, checkRadius); 
    }
    private void JumpFromWall()
    {
        RBplayer.velocity = new Vector2(xJump * -_horizontal, yJump);
    }
    private void flip()
    {

        switch(_horizontal)
        {
            case > 0:
                transform.localScale = _baseScale;
                break;
            case < 0:
                var newx = -1f * _baseScale.x;
                transform.localScale = new Vector3(newx,_baseScale.y, _baseScale.z);
                    break;

        }
        
    }
}
