using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [TextArea]
    public string Notes = "Specifies a platform that can move in one of the x,y,z directions";

    public bool active = false;

    public bool horizontal;
    public bool vertical;
    public bool lateral;
    public bool movingForward = true;

    public float speed = 1;
    //how far it will move forwards
    public float forwardDistance = 10;
    //how far it will move backwards
    public float reverseDistance = 10;
    //time platform will wiat before changing direction
    public float stopTime = 60;
    
    private Vector3 starterPosition;
    private float countdown;

    // Use this for initialization
    void Start() {
        countdown = stopTime;
        starterPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (active) {
            if (countdown < 0) {
                if (horizontal) {
                    //move forward
                    if (movingForward == true) {
                        if (this.transform.position.x <= starterPosition.x + forwardDistance) {
                            this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
                        } else {
                            //we are beyond our end point
                            movingForward = !movingForward;
                            countdown = stopTime;
                        }
                    } else {
                        if (this.transform.position.x >= starterPosition.x - reverseDistance) {
                            this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
                        } else {
                            //we are beyond our end point
                            movingForward = !movingForward;
                            countdown = stopTime;
                        }
                    }
                } else if (vertical) {
                    //move vertical
                    if (movingForward == true) {
                        if (this.transform.position.y <= starterPosition.y + forwardDistance) {
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime, this.transform.position.z);
                        } else {
                            //we are beyond our end point
                            movingForward = !movingForward;
                            countdown = stopTime;
                        }
                    } else {
                        if (this.transform.position.y >= starterPosition.y - reverseDistance) {
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed * Time.deltaTime, this.transform.position.z);
                        } else {
                            //we are beyond our end point
                            movingForward = !movingForward;
                            countdown = stopTime;
                        }
                    }
                } else if (lateral) {
                    //move forward
                    if (movingForward == true) {
                        if (this.transform.position.z <= starterPosition.z + forwardDistance) {
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + speed * Time.deltaTime);
                        } else {
                            //we are beyond our end point
                            movingForward = !movingForward;
                            countdown = stopTime;
                        }
                    } else {
                        if (this.transform.position.z >= starterPosition.z - reverseDistance) {
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
                        } else {
                            //we are beyond our end point
                            movingForward = !movingForward;
                            countdown = stopTime;
                        }
                    }
                }
            } else {
                countdown--;
            }
        }
    }


    public void OnTriggerStay(Collider col) {
        if (col.gameObject.tag == "Player") {
            col.transform.parent = transform;
        }
    }

    public void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            col.transform.parent = null;

        }
    }


    public void Toggle(){
        active = !active;
    }
}
