using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement
    private void FixedUpdate()
    {
        float moveSide = Input.GetAxis("Horizontal");
        float moveUp = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveSide, moveUp);
        float amtToMove = (float)StatManager.StatManagerInstance.GetPlayerSpeed() * Time.deltaTime;

        transform.Translate(movement*amtToMove, Space.World);

    }
}
