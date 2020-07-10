using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSomething : MonoBehaviour
{

	public GameObject projectile;
	public Vector2 velocity;
	bool canShoot = true;
	public Vector2 offset = new Vector2(0.4f, 0.1f);
	//private float cooldown = 1f;
	float initialPos;
	float actualPos;
	float lastVel;

	public Transform weaponHolder;

	private PlayerWeaponController weaponController;
   
   
    // Start is called before the first frame update
    void Start()
    {
          initialPos=transform.position.x;
		  weaponController = GetComponent<PlayerWeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
    	int isRight = checkDirection();
    	float vel = velocity.x;
        if(Input.GetKeyDown(KeyCode.T) && canShoot)
		{
        	
        	if(isRight!=0){
        		vel = vel*isRight;
        	}else{
        		vel = lastVel;
        		}
        	GameObject go =  (GameObject)Instantiate(projectile, (Vector2)transform.position+offset*isRight, Quaternion.identity);
            go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (vel, velocity.y);
			StartCoroutine(CanShoot());
        }
        initialPos=actualPos;
        lastVel = vel;
    }

    IEnumerator CanShoot()
    {
    	canShoot = false;
    	yield return new WaitForSeconds(weaponController.GetWeapon().cooldown);
    	canShoot = true;
    }
    
    int checkDirection()
    {
    	actualPos = transform.position.x;
    	if (actualPos>initialPos){
    		return 1;
    	}else if(actualPos>initialPos){
    		return 0;
    	}else{
    		return -1;
    	}
    }

}
