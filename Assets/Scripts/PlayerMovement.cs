using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 1;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Debug.Log(string.Format("x:{0} y:{1}", horiz, vert));

        Vector2 control = new Vector2(horiz, vert);
        float angle = Vector2.SignedAngle(Vector2.up, control);
        //        if(control.magnitude > 1) {
        //            control.Normalize();
        //        }

        if (control.magnitude > 0) {
            Vector3 movement = new Vector3(0, 0, Vector2.ClampMagnitude(control, 1f).magnitude);
            transform.eulerAngles = new Vector3(0, -angle, 0);
            transform.Translate(movement * speed);
        }
    }
}
