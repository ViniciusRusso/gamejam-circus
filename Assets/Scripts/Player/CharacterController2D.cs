using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings

	[SerializeField] private float dashCooldown = 0.5f;
	[SerializeField] private float DashForce;
	[SerializeField] private float dashDistance;

	private Animator anim;	

	const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector2 m_Velocity = Vector2.zero;

	public bool isDashing = false;
	private bool canDoubleJump;
	private float nextDash;
	

	[HideInInspector] public int health;
	public bool canBeDamaged = true;
	[HideInInspector] public PowerUpController puController;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{ 
		anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		puController = GetComponent<PowerUpController>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}

	private void Start(){
		health = 1;
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject.tag == "Map")
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
				//If on ground and after dash cooldown passes, the player can dash again.
				if (Time.time > nextDash){
					isDashing = false;
					anim.SetBool("IsDashingRight", false);
					anim.SetBool("IsDashingLeft", false);
				}
				canDoubleJump = true;
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool jump, bool dash)
	{
		anim.SetBool("IsGrounded", m_Grounded);
		anim.SetBool("IsJumping", jump);
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			
			// Move the character by finding the target velocity
			Vector2 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			if (move > 0 || move < 0) 
			{
				anim.SetBool("IsWalking", true);
			}
			else 
			{
				anim.SetBool("IsWalking", false);
			}

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
				anim.SetBool("IsDashingLeft", false);
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
				anim.SetBool("IsDashingRight", false);
			}
		}
		
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			//m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

			Vector2 targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		}
		else if (!m_Grounded && jump && canDoubleJump && GetComponent<TrailRenderer>().enabled) //Double Jump
		{
			canDoubleJump = false;
			Vector2 targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
		}
		//If the player can dash
		else if (!isDashing && dash) 
		{	
			
			isDashing =  true;
			nextDash = Time.time + dashCooldown;
			//Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			//dashDirection = dashDirection.normalized;
			//Vector2 nullDirection = new Vector2(0f,0f);
			//if (dashDirection == nullDirection){
			Vector2 dashDirection;
			if(m_FacingRight){
				dashDirection =  new Vector2 (1f + dashDistance, 0f);
				anim.SetBool("IsDashingRight", true);
			}
			else{
				dashDirection =  new Vector2 (-1f - dashDistance, 0f);
				anim.SetBool("IsDashingLeft", true);
			}
			//}
			
			//Debug.Log("Dashing at : " + dashDirection);

			m_Rigidbody2D.velocity = Vector2.Lerp(m_Rigidbody2D.velocity, dashDirection, DashForce * Time.deltaTime);
			//m_Rigidbody2D.AddForce(dashDirection);
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void TakeDamage(){
		if (puController.balloonUp){
			puController.balloonUp = false;
			puController.balloon.SetActive(false);
			StartCoroutine(Invencibility(1f));
			StartCoroutine(puController.BalloonCooldown());
		}
		else if(canBeDamaged) {
			//Death
			Debug.Log("Dead");
			SceneManager.LoadScene("Boss" + (PlayerPrefs.GetInt("Level") + 1));
		}
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Enemy"){
			TakeDamage();
		}
		
	}

	public IEnumerator Invencibility(float timer)
    {
		canBeDamaged = false;
		yield return new WaitForSeconds(timer);
		canBeDamaged = true;
    }
}
