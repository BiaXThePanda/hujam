using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float health;
    public float damage;

    private float distance;
    private GameObject player;

    public float range;
    public bool isRushing;
    public bool isFiring;

    public bool isFlipped = false;
    public float activateRange;
    public bool isActive;
    Animator animator;
    public Vector2 startLocalScaleX;

    public float shootingCooldown = 1f;
    public float shootingCooldownLeft;

    public float shootForce;

    public GameObject projectile;
    
    public Transform projectileExitingPos;


    public float getDamageCooldownLeft;
    public float getDamageCooldown;
    public AudioSource audSrc;
    public AudioClip[] sfx;
    public AudioSource Music;
    bool deathSoundPlayed;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        getDamageCooldownLeft = getDamageCooldown;
        startLocalScaleX = transform.localScale;
        isActive = false;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        audSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check Death Sound
        if(health <= 0&& !deathSoundPlayed)

        {
            Music.Stop();
            audSrc.PlayOneShot(sfx[1]);
            deathSoundPlayed = true;
            Invoke("DestroyPlatform", 2f);
        }

        animator.SetFloat("Health", health);
        distance = Vector2.Distance(player.transform.position,transform.position);

        if(distance<= activateRange && animator.GetCurrentAnimatorStateInfo(0).IsName("Dead") == false)
        {
            if (!isActive && health > 0)
            {
                isActive = true;
                Debug.Log("caliyor");
                Music.Play();
                animator.SetTrigger("Start");
            }
            
        }
        
        if (isActive)
        {
            if (isRushing == false && isFiring == false)
            {
                TurnToPlayer();
            }
            if (distance >= range)
            {
                if(shootingCooldownLeft<= 0)
                {
                    isRushing = false;
                    isFiring = true;
                    shootingCooldownLeft = shootingCooldown;
                }
                else
                {
                    shootingCooldownLeft -= Time.deltaTime;
                }
                

            }
            
            else
            {
                isRushing = true;
                isFiring = false;
            }

          
            animator.SetBool("Rushing", isRushing);
            animator.SetBool("Firing", isFiring);
        }

        //Decrease get damage cooldown
        getDamageCooldownLeft -= Time.deltaTime;
    }
    public void TurnToPlayer()
    {
        if(transform.position.x > player.transform.position.x && transform.localScale.x != startLocalScaleX.x)
        {
            transform.localScale = new Vector2(startLocalScaleX.x,transform.localScale.y);
        }
        else if (transform.position.x < player.transform.position.x && transform.localScale.x == startLocalScaleX.x)
        {
            transform.localScale = new Vector2(-startLocalScaleX.x, transform.localScale.y); ;
        }
    }
   public void Shoot()
   {
        audSrc.PlayOneShot(sfx[0]);
        GameObject inst = Instantiate(projectile, projectileExitingPos.position, Quaternion.identity);
        float direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        inst.GetComponent<Rigidbody2D>().AddForce(new Vector2(-direction*shootForce,shootForce/10));
   }
    public void GetDamage(float amount)
    {
        
        Debug.Log("dovdun");
        if (getDamageCooldownLeft <= 0)
        {
            health -= amount;
            animator.SetTrigger("Hit");
            audSrc.PlayOneShot(sfx[2]);
            
            getDamageCooldownLeft = getDamageCooldown;

        }
        float direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up*300,ForceMode2D.Force);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.right* 300*-direction, ForceMode2D.Force);
        StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DisableInputs(0.5f));
        
    }
    void DestroyPlatform()
    {
        Destroy(platform);
        Destroy(gameObject);
    }

}
