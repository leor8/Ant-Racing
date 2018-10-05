using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

  public float speed = 1.5f;

     void Update ()
     {
         if (Input.GetKey("a"))
         {
             transform.position += Vector3.left * speed * Time.deltaTime;
         }
         if (Input.GetKey("d"))
         {
             transform.position += Vector3.right * speed * Time.deltaTime;
         }
         if (Input.GetKey("w"))
         {
             transform.position += Vector3.up * speed * Time.deltaTime * 6;
         }
         if (Input.GetKey("w"))
         {
             transform.position += Vector3.down * speed * Time.deltaTime;
         }
     }

}