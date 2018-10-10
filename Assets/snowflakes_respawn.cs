using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_player : MonoBehaviour {
  private Transform spawnPos;
  public GameObject snowflake;
  private GameObject[] snowflakes;
  private int timer = 10;//1800;
  private int spawnTimer = 120;

	// Update is called once per frame
	void Update () {
    timer--;
    if(timer <= 0) {
      spawnTimer--;
      if(spawnTimer <= 0) {
        SpawnRandom();
        spawnTimer = 120;
      }
    }
	}

  void SpawnRandom() {
    spawnPos.position = new Vector2(Random.Range(-23, 25), Random.Range(280, 390));
    for(int i = snowflakes.Length; i < snowflakes.Length + 15; i++) {
      snowflakes[i] = Instantiate(snowflake, spawnPos.position, spawnPos.rotation);
    }
  }
}
