using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Controller : MonoBehaviour {


    private Vector3 spawnPoint;
    RaycastHit whatIHit;
    public GameObject player;
    //public Text text;

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

        if (Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y")==0) //walk when swipe forward
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
                if (whatIHit.collider.gameObject.GetComponent<Objects>().whatObj == Objects.objects.key2)
                {
                    GetKey2();
                }
                if (whatIHit.collider.gameObject.GetComponent<Objects>().whatObj == Objects.objects.bed)
                {
                    DoorUnderBed();
                }

            }
            

        }


    }

    void PickUpCup()
    {
        Debug.Log("pickUpCup");
        player.GetComponent<Inventory>().hasCup = true; //set cup pick up 
        //player.GetComponent<DescriptionText>().descriptionText.text = "You picked up the cup. ";          //show text to tell player
        Destroy(whatIHit.collider.gameObject); //make cup disappear when pick up
    }

    void EmptyKettle()
    {
        Debug.Log("emptyKettle");
        if (player.GetComponent<Inventory>().hasCup)
        {
            player.GetComponent<Inventory>().emptyKettle = true; //set kettle empty
            player.GetComponent<Inventory>().hasKey1 = true;
            //show text to tell player
            Destroy(whatIHit.collider.gameObject); //make kettle disappear and show key1 underneath or in it
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
            Destroy(whatIHit.collider.gameObject); //make key1 disappear
        }
    }
    void UnlockNightstand() {
        Debug.Log("unlockNightstand");
        if (player.GetComponent<Inventory>().hasKey1)
        {
            player.GetComponent<Inventory>().unlockNighstand = true; //set nightstand unlocked
            player.GetComponent<Inventory>().hasKey2 = true;
            //show text
            Destroy(whatIHit.collider.gameObject); // make nightstand disappear and show key2
        }else
        {
            //show text the nightstand is locked
        }
    }
    void GetKey2()
    {
        Debug.Log("getKey2");
        if (player.GetComponent<Inventory>().unlockNighstand)
        {
            player.GetComponent<Inventory>().hasKey2 = true; //set has key2
            //show text
            Destroy(whatIHit.collider.gameObject); //make key2 disappear 
        }
    }
    void DoorUnderBed()
    {
        Debug.Log("tryEscape");
        if (player.GetComponent<Inventory>().hasKey2)
        {
            Destroy(gameObject);
            //show text, congratulations, you escape the cell
        }else
        {
            //show text a locked hidden door under bed, continue explore the cell
        }
    }
}
