using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D rb;
    public float speed;
    public float movement = 0f;
    public int health;
    public float armor;
    public bool canMove = true;
    public LayerMask enemyLayer;
    private bool stunnedPlayer;
    public int gold;
    public float maxYVelocity;
    float damageCoolDownLeft;
    public float damageCoolDown;

    //GroundCheck
    [Header("GroundCheck")]
    public bool grounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    //Jump
    [Header("Jump")]
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier;
    public float jumpCoolDown;
    private float jumpCDL;
    public float coyoteTimer;
    private float coyoteTime;
    public int doubleJump = 2;
    public bool canDJ;
    private bool DJed;

    [Header("WallSlide")]
    //WallSlide & WallJump
    private bool isTouchingFront;
    public Transform frontCheck;
    public bool wallSliding;
    public float wallSlidingSpeed;
    public LayerMask wallLayer;
    public float wallSlidingCountdown;
    public float wallSlidingLeft;

    bool wallJumping;
    public float wallJumpX;
    public float wallJumpY;
    public float wallJumpDuration;


    [Header("Sprite")]
    public bool isFacingRight = true;
    public float startLocalScaleX;

    [Header("CamShake")]
    public CinemachineVirtualCamera cm_Cam;
    public float shakeTimer;
    public float shakeAmount;
    public GameObject landParticle;

    [Header("Animation")]
    private Animator animator;

    [Header("Sounds")]
    private AudioSource audSource;
    public AudioClip[] sfx;

    [Header("TimeSlow")]
    public float slowAmount;
    public float slowDuration;

    [Header("Evolve")]
    public float popoRadius;
    public bool doubleJumpAvailable;
    public bool groundSmash;
    public GameObject combatTwoAttack;
    public bool canMagnetGolds;
    public bool dontGetHitByProjectiles;
    public bool canWallSlide;
    public int evolveGot;

    public GameObject flEv;
    // Start is called before the first frame update
    void Start()
    {
        
        wallSlidingLeft = wallSlidingCountdown;
        DJed = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startLocalScaleX = transform.localScale.x;
        audSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Movement(movement);
        GroundCheck();

    }





    void Update()
    {

        
        movement = Input.GetAxis("Horizontal");
        animator.SetBool("grounded",grounded);

        //FLIP PLAYER IF NOT STUNNED
        if (!stunnedPlayer)
        {
            FlipSprite();
        }

        //DAMAGE COOLDOWN DECREASE
        damageCoolDownLeft -= Time.deltaTime;
      
        //CHECK Y VELOCITY
       if(rb.velocity.y < -maxYVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y,-maxYVelocity,float.MaxValue));
        }

        animator.SetFloat("speed", Mathf.Abs(movement));
        animator.SetFloat("verticalSpeed", rb.velocity.y);
        
        //JUMP
        jumpCDL -= Time.deltaTime;
        if (Input.GetButton("Jump"))
        {
            
            if(jumpCDL <= 0)
            {
                
                    Jump();
                    Debug.Log("J");
                    jumpCDL = jumpCoolDown;
                    
                
            }
        }
        if (Input.GetButtonUp("Jump") && !DJed)
        {
            canDJ = true;
        }
        if (doubleJumpAvailable) {
            if (Input.GetButtonDown("Jump") && canDJ)
            {
                DoubleJump();
                Debug.Log("DJ");
                canDJ = false;
                DJed = true;
            }
        }
        
        //GROUNDED
        if (grounded)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("DoubleJump"))
            {
                animator.SetTrigger("EndDouble");
            }
            wallSlidingLeft = wallSlidingCountdown;
        }
        if (grounded && rb.velocity.y <= 0)
        {
            coyoteTime = coyoteTimer;
            canDJ = false;DJed = false;
        }
        else
        {
            coyoteTime -= Time.deltaTime;
        }
        





        //JUMP MECHANICS
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            Debug.Log("a");
        }else if (rb.velocity.y > 0 && Input.GetButton("Jump"))
        {
            Debug.Log("b");
        }


        //GROUNDPUNCH
        if (Input.GetButtonDown("GroundLand"))
        {
            GroundLand();
        }

        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cbmcp = cm_Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cbmcp.m_AmplitudeGain = 0;

            }
        }

        //FLIP SPRITE
        
  
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, groundCheckRadius, wallLayer);

        if (canWallSlide)
        {

        
        //WallSliding & WallJump
        if(isTouchingFront && !grounded && movement != 0)
        {
            wallSlidingLeft -= Time.deltaTime;
            if(wallSlidingLeft <= 0)
            {
                wallSliding = true;
                Debug.Log("DUVAR");
            }
            
        }
        else
        {
            wallSliding = false;
        }
        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y,-wallSlidingSpeed, -wallSlidingSpeed));
        }
        else
        {
          
        }
        if(wallSliding && Input.GetButtonDown("Jump"))
        {
            wallJumping = true;
            animator.SetTrigger("Jump");
            
            Invoke("SetWalljumpingFalse",wallJumpDuration);
        }
        if (wallJumping)
        {
            Debug.Log("walljumped");
            rb.velocity = new Vector2(wallJumpX * -movement,wallJumpY);
            StartCoroutine(DisableInputs(0.5f));
        }
        }

        //Enemy Check
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, enemyLayer))
        {
            GameObject enemy = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, enemyLayer).gameObject;
            ShakeCamera(shakeAmount,0.05f);
            if (enemy.GetComponent<Enemy>() != null)
            {
                if (enemy.GetComponent<Enemy_Second>() == null)
                {
                    enemy.GetComponent<Enemy>().GetDamage(100);
                }
            }
              
            else
            {
                enemy.GetComponent<BossDamage>().GetDamage(50);
            }

        }
        
        
    }


    
    
    //FUNCTIONS


    private void ShakeCamera(float amount,float time)
    {

        CinemachineBasicMultiChannelPerlin cbmcp = cm_Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = amount;
        shakeTimer = time;
        
        Instantiate(landParticle,transform.position,Quaternion.identity);
    }


    private void Movement(float movement)
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(movement * speed, rb.velocity.y);
            // And then smoothing it out and applying it to the character
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
        
    }

    private void GroundCheck()
    {
        float lastVelocity = rb.velocity.y;
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            if(lastVelocity < -speed*2)
            {
                audSource.PlayOneShot(sfx[0],1f);
                ShakeCamera(shakeAmount,0.05f);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                doubleJump = 2;
                GroundSmash();
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("DoubleJump"))
                {
                    animator.SetTrigger("EndDouble");
                }
            }
            else if(lastVelocity < -speed)
            {
                audSource.PlayOneShot(sfx[2]);
                doubleJump = 2;
               

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("DoubleJump"))
                {
                    animator.SetTrigger("EndDouble");
                }
            }
            grounded = true;
        }

    }
    private void Jump()
    {
        if (coyoteTime > 0 && canMove)
        {
                rb.AddForce(Vector2.up * jumpForce);
                audSource.PlayOneShot(sfx[1]);
                animator.SetTrigger("Jump");      
                coyoteTime = 0;
        }
    }
    private void DoubleJump()
    {
        if (canMove && doubleJumpAvailable)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce);
           
            audSource.PlayOneShot(sfx[1]);
            animator.SetTrigger("DoubleJump");
            canDJ = false;
        }
    }

    private void GroundLand()
    {
        if (!grounded)
        {
            if(rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, 0);
            
            rb.AddForce(Vector2.down * jumpForce*1.5f);
        }

    }

    public void FlipSprite()
    {
        if (rb.velocity.x > 0 && transform.localScale.x != startLocalScaleX)
        {
            transform.localScale = new Vector2(startLocalScaleX, transform.localScale.y);
        }
        else if (rb.velocity.x < 0 && transform.localScale.x == startLocalScaleX)
        {
            transform.localScale = new Vector2(-startLocalScaleX, transform.localScale.y);
        }
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {

            Die();

        }
    }

    private void Die()
    {
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(2);
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(2);
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(2);
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(2);
        health = 4;
        SceneManager.LoadScene("Introduction");
        evolveGot++;
        gold = 0;
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDGold>().ChangeGoldTo(gold);
        
        evolveGot = 0;
        doubleJumpAvailable = false;
        canMagnetGolds = false;
        dontGetHitByProjectiles = false;
        canWallSlide = false;
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0;j < 3; j++)
            {
                if (transform.GetChild(i).transform.GetChild(j).gameObject.activeSelf)
                {
                    transform.GetChild(i).transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
        Invoke("createFirstEvolve", 0.2f);
        
    }

    private void createFirstEvolve()
    {
        Instantiate(flEv, transform.position, Quaternion.identity);
        GameObject.Find("Canvas_Intro").SetActive(false);

    }

    private void SetWalljumpingFalse()
    {
        wallJumping = false;
    }

    public void GetDamage(float damage,bool stunned = false)
    {
        if(damageCoolDownLeft<= 0)
        {
            health--;
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(-1);
            audSource.PlayOneShot(sfx[3]);
            if (stunned)
            {
                animator.SetTrigger("Stun");
                stunnedPlayer = true;
                StartCoroutine(DisableInputs(1f));
                ShakeCamera(shakeAmount, 0.05f);

            }
            else
            {
                ShakeCamera(shakeAmount, 0.05f);
                animator.SetTrigger("Hit");
                StartCoroutine(SlowDownTime());
            }
            CheckHealth();
            damageCoolDownLeft = damageCoolDown;
        }
       
    }
    public void IncreaseHealth()
    {
        if (health <= 2)
        {
            health += 2;
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(2);
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(2);

        }
        else if(health == 3)
        {
            health++;
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HealthBar>().ChangeHealth(1);
        }
    }
    private void ChangeHealth()
    {

    }

    IEnumerator SlowDownTime() {
        Time.timeScale = slowAmount;
        yield return new WaitForSeconds(slowDuration);
        Time.timeScale = 1f;
    }

    public IEnumerator DisableInputs(float duration)
    {
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;
        stunnedPlayer = false;
    }

    //SOUNDS
    public void FootStepOne()
    {
        audSource.PlayOneShot(sfx[Mathf.RoundToInt(Random.Range(4,5))]);
    }
    public void FlipSound()
    {
        audSource.PlayOneShot(sfx[6]);
    }


    public void GroundSmash()
    {
        if (groundSmash)
        {
            Debug.Log("Ground Smash");
            if (Physics2D.OverlapCircle(transform.position, popoRadius, enemyLayer))
            {
                Debug.Log("DUSMAN VURULDU");
                GameObject enemy = Physics2D.OverlapCircle(transform.position, popoRadius, enemyLayer).gameObject;
                enemy.GetComponent<Enemy>().GetDamage(100);
            }
            
        }
    }

    public void IncreaseGold(int amount)
    {
        audSource.PlayOneShot(sfx[7]);
        gold += amount;
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDGold>().ChangeGoldTo(gold);
    }
    public void DecreaseGold(int amount)
    {
        gold -= amount;
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDGold>().ChangeGoldTo(gold);
    }

    public void CombatTwoAttack()
    {
        GameObject inst = Instantiate(combatTwoAttack,transform.position,Quaternion.identity);
        inst.transform.parent = transform;
    }
}
