using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	
	private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
		spawnPoint = transform.position;

	}

    // Update is called once per frame, walk when tap, stop when tap ends
    //void Update()
    //{
    //    if (Input.GetButton("Tap"))  //do something if tap starts
    //    {
    //        transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
    //    }
    //    if (Input.GetButtonUp("Tap")) // do something if tap ends
    //    {
    //        transform.position = transform.position;
    //    }

    //    if (transform.position.y < -18f) //if player fall out of plane, back to original point
    //    {
    //        transform.position = spawnPoint;
    //    }
    //}

    // Update is called once per frame, walk when swipe forward
    void Update()
    {
        if(Input.GetAxis("Mouse X") < 0)
        {
            transform.position = transform.position + Camera.main.transform.forward * 2f * Time.deltaTime;
        }
        if (transform.position.y < -15f) //if player fall out of plane, back to original point
        {
            transform.position = spawnPoint;
        }
      
    }
}
