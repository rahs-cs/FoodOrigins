using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 1;
    public bool debug = false;
    Animator aninmator;
    WallCollider wall;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start() {
        aninmator = GetComponent<Animator>();
        wall = GetComponent<WallCollider>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

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

        Vector3 movement = new Vector3(0, 0, control.magnitude);
        transform.eulerAngles = new Vector3(0, -angle, 0);
        rigid.velocity = new Vector3(horiz, 0, vert) * speed;
    }
}
