using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    float _horizontalMove;

    private void FixedUpdate()
    {
        _horizontalMove = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, _horizontalMove) * movementSpeed;  
    }
}
