using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 1;
    public bool debug = false;
    Animator aninmator;
    WallCollider wall;

    // Start is called before the first frame update
    void Start() {
        aninmator = GetComponent<Animator>();
        wall = GetComponent<WallCollider>();
    }

    // Update is called once per frame
    void Update() {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 collisionAveragePoint = Vector2.zero;

        if (wall.collision != null) {
            ContactPoint firstContact = wall.collision.contacts[0];
            Vector3 position = transform.position;

            foreach (ContactPoint contact in wall.collision.contacts) {
                Vector2 contact2 = new Vector2(contact.point.x - position.x, contact.point.z - position.z);
                contact2.Normalize();

                if (collisionAveragePoint != Vector2.zero) {
                    collisionAveragePoint = (collisionAveragePoint + contact2);
                } else {
                    collisionAveragePoint = contact2;
                }
            }

            collisionAveragePoint = Vector2.ClampMagnitude(collisionAveragePoint, 1f);
            Debug.Log(collisionAveragePoint);
        }

        if (horiz < 0 && collisionAveragePoint.x < 0) {
            horiz = 0;
        } else if (horiz > 0 && collisionAveragePoint.x > 0) {
            horiz = 0;
        }

        if (vert < 0 && collisionAveragePoint.y < 0) {
            vert = 0;
        } else if (vert > 0 && collisionAveragePoint.y > 0) {
            vert = 0;
        }

        Vector2 control = new Vector2(horiz, vert);

        if (control.magnitude > 1) {
            control.Normalize();
        }

        float angle = Vector2.SignedAngle(Vector2.up, control);

        if (debug) {
            Debug.Log(string.Format("x:{0} y:{1}, deg:{2} mag:{3}", horiz, vert, angle, control.magnitude));
        }

        if (aninmator != null) {
            aninmator.SetFloat("MoveSpeed", control.magnitude);
        }

        if (control.magnitude > 0) {
            Vector3 wallHit = new Vector3(-collisionAveragePoint.x, 0, -collisionAveragePoint.y) * speed;
            Vector3 movement = new Vector3(0, 0, control.magnitude);
            transform.eulerAngles = new Vector3(0, -angle, 0);
            transform.Translate((movement * speed) - (wallHit * 2));
        }
    }
}
