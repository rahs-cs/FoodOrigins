using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {
    public Collision collision;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (collision != null)
        {
            Debug.Log(collision.gameObject.name);
        }
    }

    void OnCollisionEnter(Collision newCollision) {
        collision = newCollision;
    }

    private void OnCollisionStay(Collision newCollision) {
        collision = newCollision;
        foreach (ContactPoint contact in newCollision.contacts) {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.yellow);
        }
    }

    private void OnCollisionExit() {
        collision = null;
    }
}
