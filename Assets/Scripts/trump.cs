using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trump : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed = 1f;
    [SerializeField] private float _brakePower = 2f;
    private Animator _animator;
    private Rigidbody2D _body;
    private bool _isWalking = false;
    private float _dirX = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _isWalking = _dirX != 0;
        _animator.SetBool("Walking",_isWalking);
        float scaleX=transform.localScale.x;
        if (_dirX > 0)
        {
            scaleX = -1f;
        }
        else if (_dirX < 0) {
            scaleX = 1f;
        }
        transform.localScale=new Vector3(scaleX,1,1);

    }
    private void FixedUpdate()
    {
        if (_isWalking) { 
        _body.velocity=new Vector2(_dirX*_walkingSpeed,_body.velocity.y);
        }
        else
        {
            _body.velocity=new Vector2(Mathf.Lerp(_body.velocity.x,0,_brakePower*Time.deltaTime),0);
        }

    }
}
