using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 1;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horiz, 0, vert);

        transform.Translate(movement * speed);
    }
}
