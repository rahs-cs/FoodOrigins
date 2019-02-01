using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {
    public bool isColliding = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (!isColliding) {
            isColliding = true;
        }
        Debug.Log(collision);
    }

    private void OnCollisionStay(Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.yellow);
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (isColliding) {
            isColliding = false;
        }
        Debug.Log(collision);
    }
}
