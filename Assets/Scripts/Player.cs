using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    [Header("Speeds")]
    public float WalkSpeed = 3;
    public float JumpForce = 10;

    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animatorController;
    private float _walkTime = 0, _walkCooldown = 0.2f;
    
    private RaycastHit2D[] hits;


    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
    }

    private void Update()
    {

        if (_moveState == MoveState.Jump && CheckGround())
        {
            if (_rigidbody.velocity == Vector2.zero)
            {
                Idle();
            }
        }
        else if (_moveState == MoveState.Walk && CheckGround())
        {
            _rigidbody.velocity = ((_directionState == DirectionState.Right ? Vector2.right : -Vector2.right)
                                    * WalkSpeed * Time.deltaTime);
            _walkTime -= Time.deltaTime;
            if (_walkTime <= 0)
            {
                Idle();
            }
        }
    }

    public void MoveRight()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Left)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Right;
            }
            _walkTime = _walkCooldown;
            _animatorController.Play("WalkRight");
        }
    }

    public void MoveLeft()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Right)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Left;
            }
            _walkTime = _walkCooldown;
            _animatorController.Play("WalkRight");
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _rigidbody.velocity = (Vector3.up * JumpForce * Time.deltaTime);
            _moveState = MoveState.Jump;
        }
    }

    private void Idle()
    {
        _moveState = MoveState.Idle;
        _animatorController.Play("Idle");
    }

    private bool CheckGround()
    {
        hits = Physics2D.RaycastAll(transform.position, transform.position + new Vector3(0, -1, 0));
        //bool isGround = hits.Any(s => s.transform.name.Equals("Tilemap"));
        bool isGround = hits.Any(s => s.transform.tag.Equals("Ground"));
        return isGround;
    }
    enum DirectionState
    {
        Right,
        Left
    }

    enum MoveState
    {
        Idle,
        Walk,
        Jump
    }

    // Bounds bounds = GetComponent<Collider2D>().bounds;
    //Vector2 point = bounds.center;


    //void OnDrawGizmosSelected()
    //{
    //Gizmos.color = Color.yellow;
    //Gizmos.DrawSphere(gameObject.transform.position, 5);
    //Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -1, 0));
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log(other.tag);
    //    if (other.tag == "Ground")
    //    {
    //        Debug.Log("Ground");
    //        //playerMovement.detachment();

    //    }
    //}

    //void OnCollisionEnter2D(Collision2D obj)
    //{
    //Debug.Log(obj.transform.name);
    //Destroy(obj.gameObject);

    //}
}
