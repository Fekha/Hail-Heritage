using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    #region Singleton
    public static PlayerControl instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Player found!");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
        swordCol = GameObject.Find("rightHand").GetComponent<Collider2D>();
        swordCol.enabled = false;
        DontDestroyOnLoad(transform.gameObject);
    }

    #endregion
    [HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
    public int sceneSpawnLocation = 0;

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.

    public int currentScene = 1;
	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private RaycastHit2D itemFound;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.

    Collider2D swordCol;
	//void Awake()
	//{
	//	// Setting up references.
	//	groundCheck = transform.Find("groundCheck");
	//	anim = GetComponent<Animator>();
 //       swordCol = GameObject.Find("rightHand").GetComponent<Collider2D>();
 //       swordCol.enabled = false;
 //       DontDestroyOnLoad(transform.gameObject);
 //   }
	void Update()
	{
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        //

        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
        itemFound = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Pickups"));
        if (itemFound.collider != null)
        {
            Interactable interactable = itemFound.collider.GetComponent<Interactable>();
            interactable.OnFocused(transform);
        }
        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump") && grounded)
			jump = true;

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Attack");
        }
	}


	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		// If the input is moving the player right and the player is facing left...
		if((h > 0 && !facingRight) || (h < 0 && facingRight))
			Flip();

		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			// Play a random jump audio clip.
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    void Attack ()
	{
        swordCol.enabled = true;
	}
    void NoAttack ()
	{
        swordCol.enabled = false;
        anim.ResetTrigger("Attack");
	}
}
