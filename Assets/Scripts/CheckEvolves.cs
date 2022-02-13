using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvolves : MonoBehaviour
{


    public GameObject[] Backs;
    public GameObject[] Combats;
    public GameObject[] Heads;

    public Player player;

    public float jumpForce;
    public float speed;

    public float combatTwoMax;public float combatTwoMin;
    public float combatTimer;

    public float slowAmount;
    public float slowDuration;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        jumpForce = player.jumpForce * 1.4f;
        speed = player.speed * 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Backs[0].activeSelf)
        {
            if (player.groundSmash == false)
            {
                player.groundSmash = true;
            }

        }
        else if (Backs[1].activeSelf)
        {

        }
        else if (Backs[2].activeSelf)
        {
            if(player.doubleJumpAvailable == false)
            {
                player.doubleJumpAvailable = true;
            }
        }
        //----------------------------------------------------------
        if (Combats[0].activeSelf)
        {
            if (player.jumpForce != jumpForce)
            {
                player.jumpForce = jumpForce;
            }
            if(player.speed != speed)
            {
                player.speed = speed;
            }
            
            
        }
        else if (Combats[1].activeSelf)
        {
            combatTimer -= Time.deltaTime;
            if (combatTimer <= 0)
            {
                player.CombatTwoAttack();
                combatTimer = Random.Range(combatTwoMin,combatTwoMax);

            }
        }
        else if (Combats[2].activeSelf)
        {
            if(player.canWallSlide == false)
            {
                player.canWallSlide = true;
            }
        }
        //----------------------------------------------------------
        if (Heads[0].activeSelf)
        {
           if(player.canMagnetGolds == false)
            {
                player.canMagnetGolds = true;
            }
           
        }
        else if (Heads[1].activeSelf)
        {
            if (player.dontGetHitByProjectiles == false)
            {
                player.dontGetHitByProjectiles = true;
            }
        }
        else if (Heads[2].activeSelf)
        {
            if(player.slowAmount != slowAmount)
            {
                player.slowAmount = slowAmount;
            }
            if (player.slowDuration != slowDuration)
            {
                player.slowDuration = slowDuration;
            }
        }
    }
}
