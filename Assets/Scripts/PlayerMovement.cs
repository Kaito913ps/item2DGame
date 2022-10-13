using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;


    void Start()
    {
        
    }

   
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
    }
}
