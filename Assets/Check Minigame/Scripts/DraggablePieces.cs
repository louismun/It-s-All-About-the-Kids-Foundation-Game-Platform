﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DraggablePieces : MonoBehaviour {

    public int thisPieceIndex;
    private bool draggable = true;

    private Vector3 mouseOffset;
    private Vector3 currPos;
    
    private GameObject draggedPiece;

    //on mouse down save reference to object
    //on mouse button down figures how much it moved in last frame. calculate distance and add that to location of reference you have.
    
	// Use this for initialization
	void Start () {

	  //currPos = this.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

	  //when the button is first pressed down
	  if (Input.GetMouseButtonDown(0)) {

	     //checks if the user is pressing on the draggable object
	     RaycastHit2D hit = Physics2D.Raycast(
	       Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

	     //if object is being pressed
	     if (hit && hit.collider.GetComponent<DraggablePieces>().draggable) {

	      //if the object can currently be dragged
	      if (draggable) {

	        //calculates location where object should be dragged
	        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;

	        //sets current object's position
            this.transform.position = newPosition;

            //updates current object position
	        currPos = this.transform.position;

	    //set the mouse offset from the center of the game object
	 /*   mouseOffset = currPos - Camera.main.ScreenToWorldPoint(
	      new Vector3(Input.mousePosition.x,
	                  Input.mousePosition.y,
	                  Input.mousePosition.z));*/


	  }

	  //while the mouse button is being held down
	  if (Input.GetMouseButton(0)) {


	      }
	    }
	  }

	  else {

	    mouseOffset = currPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
	                                                                       Input.mousePosition.y,
	                                                                       Input.mousePosition.z));

	  }
	}

	/*
	 * If the dragged object is within a check slot
	 */
	void OnTriggerStay2D (Collider2D slot) {

	  //variable for the slot that the object was dragged to
	  CheckSlots draggedSlot;

	  //sets the correct slot
      draggedSlot = slot.gameObject.GetComponent<CheckSlots>();

      //if the object was dragged to a slot
	  if (draggedSlot) {

	    //if the mouse button is not still being pressed
	    if (!Input.GetMouseButton(0)) {

	      //if the index of the slot matches the index of the piece
	      if (draggedSlot.getIndex() == thisPieceIndex) {

	        //snap the check piece into place
	        Snap(draggedSlot.gameObject.transform.position);

	      }
	    }
	  }
	}

	/*
	 * Snaps an object to a location
	 */
	void Snap(Vector2 location) {

	  //sets position
	  this.transform.position = location;

	  //makes object impossible to drag anymore.
	  draggable = false;

	}
}
