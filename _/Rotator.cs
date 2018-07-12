using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public float x;
    public float y;

    void Update () {
        transform.Rotate(new Vector2(x, y) * Time.deltaTime);
	}
}
