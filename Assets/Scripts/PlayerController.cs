using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
	// public, so we can control speed in Unity editor
  	public float speed = 0;

    // create variables for count text
    public TextMeshProUGUI countText;

    // create object for win text
    public GameObject winTextObject;

    // Rigidbody component allows object to be controlled by physics
    private Rigidbody rb;
    private int count;
    private float movementX;
  	private float movementY;

  	// Start is called before the first frame update
  	void Start()
  	{
        // rb holds reference to the player object's rigidbody component
		rb = GetComponent<Rigidbody>();

        // this will be the # of pickups collected
        count = 0;
        // send it to UI
        SetCountText();
        winTextObject.SetActive(false);
    }

    // arg comes from Unity's Input System, which we applied to the player object
    // this function triggers whenever it receives an input: pressing WASD or moving joystick
  	void OnMove(InputValue movementValue)
  	{
        // get movement input data from playerobject and store it in a Vector2 variable
		Vector2 movementVector = movementValue.Get<Vector2>();

        // store those values in separate variables
    	movementX = movementVector.x;
    	movementY = movementVector.y;
  	}

    // update count UI text to current count
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    // FixedUpdate is recommended place to apply forces and change Rigidbody settings
    // FixedUpdate - 50 calls per second (frame independent) vs. Update - called every frame
    // LateUpdate - called every frame, after all Updates are called
  	void FixedUpdate()
  	{
        // Create new Vector3 variable, using movement values from OnMove, with y as 0
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // this only accepts a Vector3 variable, which is why we made one
		rb.AddForce(movement * speed);
  	}

    // called by Unity when player collides into another object
    // arg is a reference to the object collider that's been touched
	void OnTriggerEnter(Collider other)
	{
        // only disable PickUp objects by checking it's tag
        if(other.gameObject.CompareTag("PickUp"))
        {
		    // disable pickup gameobject at collision so player doesn't bump into pickups
		    other.gameObject.SetActive(false);

            // player gets a point
            count++;
            //update UI
            SetCountText();
        }
	}
}
