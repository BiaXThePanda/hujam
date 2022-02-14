using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSecond : MonoBehaviour
{
    public float health;
    public float damage;

    private float distance;
    private GameObject player;


    public float verticalRange;
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
    public bool canShoot;

    public GameObject projectile;

    public Transform[] projectileExitingPos;

    //Blade
    public Transform blade;
    public float bladeRange;
    public LayerMask playerLayer;
    public float bladeCoolDownleft;
    public float bladeCoolDown;

    public float getDamageCooldownLeft;
    public float getDamageCooldown;

    AudioSource audSrc;
    public AudioClip[] sfx;
    public bool deadSoundPlayed;
    public AudioSource Music;

    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
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
        //DeathSound
        if (health <= 0 && !deadSoundPlayed)
        {
            audSrc.PlayOneShot(sfx[1]);
            deadSoundPlayed = true;
            Invoke("DestroyPlatform", 2f);
        }

        bladeCoolDownleft -= Time.deltaTime;
        animator.SetFloat("Health", health);
        distance = Vector2.Distance(player.transform.position, transform.position);
        float verticalDistance = player.transform.position.y - transform.position.y;
        Debug.DrawRay(blade.position,Vector2.right*bladeRange);
        Debug.DrawRay(transform.position, Vector2.up*verticalRange);

        if (distance <= activateRange && animator.GetCurrentAnimatorStateInfo(0).IsName("Dead") == false)
        {
            isActive = true;
        }

        if (isActive)
        {
            if (isRushing == false)
            {
                TurnToPlayer();
            }
            if (distance >= range || verticalDistance >= verticalRange)
            {
                if (shootingCooldownLeft <= 0 && canShoot)
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
            if(health > 0)
            {
                Music.Play();
            }

            animator.SetBool("Rushing", isRushing);
            animator.SetBool("Firing", isFiring);
        }

        //Decrease get damage cooldown
        getDamageCooldownLeft -= Time.deltaTime;

        
    }
    public void TurnToPlayer()
    {
        if (transform.position.x > player.transform.position.x && transform.localScale.x != startLocalScaleX.x)
        {
            transform.localScale = new Vector2(startLocalScaleX.x, transform.localScale.y);
        }
        else if (transform.position.x < player.transform.position.x && transform.localScale.x == startLocalScaleX.x)
        {
            transform.localScale = new Vector2(-startLocalScaleX.x, transform.localScale.y); ;
        }
    }
    public void Shoot()
    {
        canShoot = false;
        isFiring = false;
        float x = 0.7f;
        for (int i = 0;i<4;i++)
        {
           
            GameObject inst = Instantiate(projectile, projectileExitingPos[i].position, Quaternion.identity);
            if(inst != null)
            {  
                if(inst.GetComponent<BossSecondProjectile>()!= null)
                {
                    StartCoroutine(inst.GetComponent<BossSecondProjectile>().Shoot(player.transform, shootForce, x, this));
                }

            }
            x += 0.7f;
        }
        StartCoroutine(CanShootActivate(2.4f));
     
        
    }
    public void Attack()
    {
        if (Physics2D.OverlapCircle(blade.position, bladeRange,playerLayer))
        {
            audSrc.PlayOneShot(sfx[0]);
            if (bladeCoolDownleft < 0)
            {
                
                GameObject player = Physics2D.OverlapCircle(blade.position, bladeRange, playerLayer).gameObject;
                player.GetComponent<Player>().GetDamage(damage);
                float direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
                StartCoroutine(player.GetComponent<Player>().DisableInputs(0.3f));
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-direction*300,300), ForceMode2D.Force);
                bladeCoolDownleft = bladeCoolDown;
            }
           

        }
    }

    public void GetDamage(float amount)
    {

        
        if (getDamageCooldownLeft <= 0)
        {
            Debug.Log("dovdun");
            health -= amount;
            animator.SetTrigger("Hit");


            getDamageCooldownLeft = getDamageCooldown;

        }
        float direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200, ForceMode2D.Force);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200 * -direction, ForceMode2D.Force);
        StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DisableInputs(0.5f));

    }
    void DestroyPlatform()
    {
        Destroy(platform);
        Destroy(gameObject);
    }

    IEnumerator CanShootActivate(float amount)
    {
        yield return new WaitForSeconds(amount);
        canShoot = true;
    }
}
