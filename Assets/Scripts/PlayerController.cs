using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 1;
    public bool debug = false;
    Animator aninmator;

    // Start is called before the first frame update
    void Start() {
        aninmator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 control = new Vector2(horiz, vert);
        float angle = Vector2.SignedAngle(Vector2.up, control);
        float magnitude = Vector2.ClampMagnitude(control, 1f).magnitude;

        // if (control.magnitude > 1) {
        //     control.Normalize();
        // }

        if (debug) {
            Debug.Log(string.Format("x:{0} y:{1}, deg:{2} mag:{3}", horiz, vert, angle, magnitude));
        }

        if (aninmator != null) {
            aninmator.SetFloat("MoveSpeed", magnitude);
        }

        if (control.magnitude > 0) {
            Vector3 movement = new Vector3(0, 0, magnitude);
            transform.eulerAngles = new Vector3(0, -angle, 0);
            transform.Translate(movement * speed);
        }
    }
}
