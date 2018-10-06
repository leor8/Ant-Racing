using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {
  private Inventory inventory;
  private Inventory inventory2;
  public GameObject itemButton;
  private GameObject newItem;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    inventory2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Inventory>();
	}

	// Update is called once per frame
	void Update () {

	}

  void OnTriggerEnter2D(Collider2D coll) {
    if(coll.CompareTag("Player")) {
      for(int i = 0; i < inventory.slots.Length; i++) {
        if(!inventory.isFull[i]){
          newItem = Instantiate(itemButton, inventory.slots[i].transform);
          newItem.transform.localScale += new Vector3(1.5F, 1F, 0);
          newItem.transform.position = new Vector2(newItem.transform.position.x + 0.7f, newItem.transform.position.y + 0.9f);
          inventory.isFull[i] = true;
          Destroy(gameObject);
          break;
        }
      }
    } else if (coll.CompareTag("Player2")){
      for(int i = 0; i < inventory2.slots.Length; i++) {
        if(!inventory2.isFull[i]){
          newItem = Instantiate(itemButton, inventory2.slots[i].transform);
          newItem.transform.localScale += new Vector3(1.5F, 1F, 0);
          newItem.transform.position = new Vector2(newItem.transform.position.x + 0.7f, newItem.transform.position.y + 0.9f);
          inventory2.isFull[i] = true;
          Destroy(gameObject);
          break;
        }
      }
    }

  }
}
