using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {


    private Vector3 spawnPoint;
    RaycastHit whatIHit;
    public GameObject player;

    // Use this for initialization
    void Start() {
        spawnPoint = transform.position;
        player = GameObject.FindWithTag("Player");

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
                if (whatIHit.collider.gameObject.GetComponent<Objects>().whatObj == Objects.objects.kettle)
                {
                   EmptyKettle();
                }
                if (whatIHit.collider.gameObject.GetComponent<Objects>().whatObj == Objects.objects.key1)
                {
                    GetKey1();
                }
                if (whatIHit.collider.gameObject.GetComponent<Objects>().whatObj == Objects.objects.nightstand)
                {
                    UnlockNightstand();
                }

            }
            

        }


    }

    void PickUpCup()
    {
        Debug.Log("pickUpCup");
        player.GetComponent<Inventory>().hasCup = true; //set cup pick up 
                                                //show text to tell player
        Destroy(whatIHit.collider.gameObject); //make cup disappear when pick up
    }

    void EmptyKettle()
    {
        Debug.Log("emptyKettle");
        if (player.GetComponent<Inventory>().hasCup)
        {
            player.GetComponent<Inventory>().emptyKettle = true; //set kettle empty
            //show text to tell player
            Destroy(whatIHit.collider.gameObject.gameObject); //make kettle disappear and show key1 underneath or in it
        }
        else
        {
            //show text tell player there is water in the kettle
        }
    }
    void GetKey1()
    {
        Debug.Log("getKey1");
        if (player.GetComponent<Inventory>().emptyKettle)
        {
            player.GetComponent<Inventory>().hasKey1 = true; //set has key1
            //show text
            Destroy(whatIHit.collider.gameObject.gameObject); //make kettle disappear and show key1 underneath or in it
        }
    }
    void UnlockNightstand() {
        Debug.Log("unlockNightstand");
        if (player.GetComponent<Inventory>().hasKey1)
        {
            player.GetComponent<Inventory>().unlockNighstand = true; //set nightstand unlocked
            //show text

        }else
        {
            //show text the nightstand is locked
        }
    }
}
