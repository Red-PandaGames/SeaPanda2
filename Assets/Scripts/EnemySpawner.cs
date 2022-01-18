using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    public GameObject player;

	public static float speed;
    // Start is called before the first frame update
    void Start()
    {
        // set speed at 10 on start / restart
		speed = 10f;

        // aysnchronous infinite enemy spawning
		StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies() {
		while (true) {

			// create a new enemy from prefab selection at right edge of screen
			Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(player.transform.position.x + 30, player.transform.position.y - 10, 1),
				Quaternion.identity);

            PlayerMovementSmall.isEnemyApproaching = true;

			// wait between 10-15 seconds for a new skyscraper to spawn
			yield return new WaitForSeconds(Random.Range(10, 15));
		}
	}
}
