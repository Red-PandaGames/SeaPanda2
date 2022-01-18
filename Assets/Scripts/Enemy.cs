using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public static bool isAttacking;

    public Animator animator;

    private float positionOnStart;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        positionOnStart = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // despawn when past left edge of the screen (camera)
		if (transform.position.x < positionOnStart - 50) {
			Destroy(gameObject);
		}
		else {
            if (transform.position.x < positionOnStart - 10 && transform.position.x > positionOnStart - 30 && SubmarineMovement.isOn) {
                 isAttacking = true;
            }
            else if (transform.position.x < positionOnStart - 30) {
                 PlayerMovementSmall.isEnemyApproaching = false;
            }
			// scroll based on EnemySpawner static variable, speed
			transform.Translate(-EnemySpawner.speed * Time.deltaTime, EnemySpawner.speed / 2 * Time.deltaTime, 0);
		}
	}

    // void FixedUpdate() {
    //     if (Enemy.isAttacking) {
    //         if (transform.position.x <= positionOnStart - 30) {
    //             EnemySpawner.speed = 0;
    //             animator.SetBool("isAttacking", isAttacking);
    //         }
    //     }
    // }
}
