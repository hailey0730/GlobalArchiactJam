using UnityEngine;
using System.Collections;

public class Cup : MonoBehaviour {

    
    public enum States
    {
        pickUp,
        drop
    };

    public States state;

	// Use this for initialization
	void Start () {
        state = Cup.States.drop;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnRayCastEnter()
    {
        Debug.Log("Enter");
    }

    public void OnRayCastExit()
    {
        Debug.Log("Exit");
    }

    public void OnTapUp()
    {
        Debug.Log("Up");
        if(state == Cup.States.drop)
        {
            PickUp();
        }
        else
        {
            Drop();
        }
    }

    private void PickUp() {
        state = Cup.States.pickUp;
        //show text telling player picked up
    }

    private void Drop() {
        state = Cup.States.drop;
        //show text telling player dropped obj
    }

}
