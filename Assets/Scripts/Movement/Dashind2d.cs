using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashind2d : MonoBehaviour
{
    public enum dashState
    {
        Ready,
        Dashing, 
        Cooldown
    }

    dashState state = dashState.Ready;

    Vector2 savedVel; //vel to restore original velocity after dashing
    Rigidbody2D rb;

    private float dashTimer=0; //intern variable, holds info about the time passed at the end of the dash and for the duration of the dash
    public float maxDashTime = 0.2f; //how long the dash is in sec
    public float dashCooldown = 0.2f; //how long we have to wait before we dash again (avoid spamming)
    public float dashSpeed = 7f; //speed of the dash
    public float availableDashs = 2f; //currently available dashs, decreases if we dash and fills up again with time
    public float maxNumOfDashs = 2f; //max number of available dashs
    public float dashReloadTime = 2f; //time needed for a dash to reload
    private float dashReloadTimer = 0; //intern variable for dash reloading
    

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //availableDashs = maxNumOfDashs;
    }


    private void Update()
    {
        dash();
    }

    private void dash()
    {
        switch (state)
        {
            case dashState.Ready: //initialize dash
                if (Input.GetKeyDown(KeyCode.Space) && StatManager.StatManagerInstance.GetNumberOfDashes() >0)//availableDashs>0)
                {
                    StatManager.StatManagerInstance.DecreaseNumberOfDashes(1);//availableDashs--;
                    savedVel = rb.velocity; //restore velocity after dashing
                    Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //get player input in order to correctly add velocity
                    rb.velocity = movement * dashSpeed; //actual dashing
                    state = dashState.Dashing;
                }
                else if (StatManager.StatManagerInstance.GetNumberOfDashes() < StatManager.StatManagerInstance.GetMaxNumberOfDashes())
                { //load up dashs change statmanager with "availableDashs"
                    dashReloadTimer += Time.deltaTime;
                    if(dashReloadTimer >= dashReloadTime)//reload a dash
                    {
                        StatManager.StatManagerInstance.IncreaseNumberOfDashes(1);//availableDashs++;
                        dashReloadTimer = 0;
                    }
                        
                }

                break;

            case dashState.Dashing: //stop dashing after max dashTime
                dashTimer += Time.deltaTime;
                if (dashTimer >= maxDashTime)//stop dash
                {
                    stopDash();
                }
                break;

            case dashState.Cooldown: //dash reset time to avoid spamming
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashReloadTimer = 0;
                    state = dashState.Ready;
                }
                break;
        }

    }

    public void stopDash()
    {
        dashTimer = dashCooldown; //setup for quick cooldown
        rb.velocity = savedVel;
        state = dashState.Cooldown;
    }

}
