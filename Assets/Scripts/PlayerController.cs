using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody player;
    public bool grounded = true;
    public bool wall = false;
    KeyCode jump = KeyCode.UpArrow;

    [Range(1, 50)]
    public float speed;
    [Range(1, 10)]
    public float jumpVelocity;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log(moveHorizontal);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f) * Time.deltaTime * speed;
        player.AddForce(movement * speed);

        //player.transform.Translate(moveHorizontal * Time.deltaTime * speed, 0.0f, 0.0f);
        //player.MovePosition(transform.position + movement);

        if (Input.GetKeyDown(jump) && grounded) 
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
            grounded = !grounded;
        }

        if (Input.GetKeyDown(jump) && wall)
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }

        if (wall)
            moveHorizontal = moveHorizontal * -1;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            grounded = true;
        }

        if (other.collider.CompareTag("Wall") && !grounded) 
        {
            wall = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        /*if (other.collider.CompareTag("Floor"))
        {
            grounded = false;
        }*/

        if (other.collider.CompareTag("Wall"))
        {
            wall = false;
        }
    }
}
