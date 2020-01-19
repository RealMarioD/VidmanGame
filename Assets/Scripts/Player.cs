using System;
using Prime31;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Script {

    // movement config
    public float gravity = -25f;
    public float runSpeed = 8f;
    public float groundDamping = 20f; // how fast do we change direction? higher means faster
    public float inAirDamping = 5f;
    public float jumpHeight = 3f;

    private float normalizedHorizontalSpeed = 0;

    private Prime31Controller _controller;
    //private Animator _animator;
    private RaycastHit2D _lastControllerColliderHit;
    private Vector3 velocity;

    #region ResetVars
    private static readonly float resetY = -6.84f; //Below this coordinate the level will reset
    private int levelNum => gm.levelNum;

    #endregion


    protected override void Awake() {
        base.Awake();
        //_animator = GetComponent<Animator>();
        _controller = GetComponent<Prime31Controller>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name.Contains("Coin")) {
            gm.coins += 1;
            gm.OnCoinsChangeEvent(gm.coins);
            // TODO play some sound
            Destroy(other.gameObject);
        }
    }

    // the Update loop contains a very simple example of moving the character around and controlling the animation
    void Update() {
        
        if (_controller.isGrounded)
            velocity.y = 0;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            normalizedHorizontalSpeed = 1;
            if (transform.localScale.x < 0f)
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            //if (_controller.isGrounded)
            //_animator.Play(Animator.StringToHash("Run"));
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            normalizedHorizontalSpeed = -1;
            if (transform.localScale.x > 0f)
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            //if (_controller.isGrounded)
            //_animator.Play(Animator.StringToHash("Run"));
        }
        else {
            normalizedHorizontalSpeed = 0;

            //if (_controller.isGrounded)
            //_animator.Play(Animator.StringToHash("Idle"));
        }


        // we can only jump whilst grounded
        if (_controller.isGrounded && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))) {
            velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
            //_animator.Play(Animator.StringToHash("Jump"));
        }


        // apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
        var smoothedMovementFactor =
            _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        velocity.x = Mathf.Lerp(velocity.x, normalizedHorizontalSpeed * runSpeed,
            Time.deltaTime * smoothedMovementFactor);

        // apply gravity before moving
        velocity.y += gravity * Time.deltaTime;

        // if holding down bump up our movement amount and turn off one way platform detection for a frame.
        // this lets us jump down through one way platforms
        if (_controller.isGrounded && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) {
            velocity.y *= 3f;
            _controller.ignoreOneWayPlatformsThisFrame = true;
        }

        _controller.move(velocity * Time.deltaTime);

        // grab our current velocity to use as a base for all calculations
        velocity = _controller.velocity;

        if(transform.position.y<resetY){
            SceneManager.LoadScene($"Level{levelNum}");
            gm.OnCoinsChangeEvent(0);
        }
    }
}