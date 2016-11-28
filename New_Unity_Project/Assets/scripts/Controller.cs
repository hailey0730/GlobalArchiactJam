using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {


    private Vector3 spawnPoint;
    private enum States { wakeUp, checkedCup, gotKey1, unlockedNightstand, takeOutBrick, gotKey2 };
    private States myStates;
    RaycastHit whatIHit;


    // Use this for initialization
    void Start() {
        spawnPoint = transform.position;
        myStates = States.wakeUp;


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

    // Update is called once per fram 
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Input.GetAxis("Mouse X") < 0) //walk when swipe forward
        {
            transform.position = transform.position + Camera.main.transform.forward * 2f * Time.deltaTime;
        }
        if (transform.position.y < -15f) //if player fall out of plane, back to original point
        {
            transform.position = spawnPoint;
        }

        if (Physics.Raycast(transform.position, fwd, out whatIHit, 10) && Input.GetButtonUp("Tap")) //pick up object when raycast hit obj and tap
        {
            Debug.Log("I picked up a" +whatIHit.collider.gameObject.name);
            if(whatIHit.collider.tag == "Objects") {
                if (whatIHit.collider.gameObject.GetComponent<Objects>().whatObj == Objects.objects.cup)
                {
                    PickUpCup();
                }
            }
            
        }


    }

    void PickUpCup()
    {
       //set cup pick up and show text to tell player
        Destroy(whatIHit.collider.gameObject); //make cup disappear when pick up
    }
    
}
