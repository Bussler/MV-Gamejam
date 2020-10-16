using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //movement
    private void FixedUpdate()
    {
        float moveSide = Input.GetAxis("Horizontal");
        float moveUp = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveSide, moveUp);
        float amtToMove = moveSpeed * Time.deltaTime;

        transform.Translate(movement*amtToMove, Space.World);

    }
}
