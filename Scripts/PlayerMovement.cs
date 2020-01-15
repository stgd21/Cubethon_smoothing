using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Physics Component of player cube
    public Rigidbody rb;
    //Forces to set in inspector
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    [SerializeField] private bool fullMotion = false;

    // FixedUpdate is called evenly across framerates
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            //Move the player right when D key is pushed
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,
                ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            //Move the player left when A key is pushed
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,
                ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {
            //End the game if the player goes off the edge
            FindObjectOfType<GameManager>().EndGame();
        }

        if (fullMotion == true)
        {
            //Allow player more control for final demonstration stage
            if (Input.GetKey("w"))
            {
                //Move the player forward when D key is pushed
                rb.AddForce(0, 0, forwardForce * Time.deltaTime,
                    ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                //Move the player backward when S key is pushed
                rb.AddForce(0, 0, -forwardForce * Time.deltaTime,
                    ForceMode.VelocityChange);
            }
        }
        else
        {
            //Add force to propel player forward
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
    }
}
