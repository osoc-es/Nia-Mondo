using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Platformer.Mechanics;


public class shootSomething : MonoBehaviour
{

	public GameObject projectile;
	public Vector2 velocity;
	bool canShoot = true;
	public Vector2 offset = new Vector2(0.4f, 0.1f);
	//private float cooldown = 1f;



    public Transform weaponHolder;

    private Animator animator;


	private PlayerWeaponController weaponController;

	private bool hasWeapon = false;

	private GameObject player;
	private PlayerController playerController;

	private int lastDirection = 1;
	private int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        weaponController = GetComponent<PlayerWeaponController>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("arbo");
		playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(!hasWeapon){
    		checkWeapon();
    	}

    	updateDirection();


        if(playerController.controlEnabled && hasWeapon && Input.GetKeyDown(KeyCode.T) && canShoot)
		{
        	//ThrowSoap();
			animator.SetBool("shootingSoap", true);
        }


    }

    IEnumerator CanShoot()
    {
    	canShoot = false;
		yield return new WaitForSeconds(weaponController.GetWeapon().cooldown);
		canShoot = true;
		
    }
    

    void checkWeapon(){
    	if(weaponController.GetWeapon() != null){
    		hasWeapon = true;
    	}
    }

    void ThrowSoap()
    {   
    	
        GameObject go = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * direction, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x*direction, velocity.y);
        StartCoroutine(CanShoot());
    }

	void ThrowingSoapFinished(){
		animator.SetBool("shootingSoap", false);
	}

    void updateDirection()
    {
        direction = Math.Sign(playerController.velocity.x);
        	if(direction == 0){
        		direction = lastDirection;
        	}
		lastDirection = direction;

    }

}

