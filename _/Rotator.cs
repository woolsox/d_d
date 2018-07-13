using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public Vector2 rotateSpeed;

    void Update () {
        transform.Rotate(rotateSpeed * Time.deltaTime);
	}
}
