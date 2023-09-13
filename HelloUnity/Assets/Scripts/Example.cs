using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MyVector
{

}

public class Example : MonoBehaviour
{
    public Transform childTr;

    // Start is called before the first frame update
    void Start()
    {
        var myForward = transform.forward;

        var v1 = new Vector3(1f, 2f, 3f);
        var v2 = new Vector3(0f, 1f, 6f);

        var v3 = v1 + v2;
        Debug.Log(v3);

        var v4 = v2 - v1; 
        // v2 + (-1 * v1);
        // v2 == v1 + v4
        Debug.Log(v4);

        var dir = v4.normalized;

        Debug.Log(v4);
        Debug.Log(dir);

        dir = (v2 - v1) / (v2 - v1).magnitude;

        var distance = Vector3.Distance(v1, v2);
        var distance2 = (v2 - v1).magnitude;

        var v5 = Vector3.one * 5f;
        v5.Scale(new Vector3(1f, 2f, 3f));

        var parallel = Vector3.Dot(Vector3.left, Vector3.left); // 1
        var opposite = Vector3.Dot(Vector3.left, Vector3.right); // -1
        var ortho = Vector3.Dot(Vector3.left, Vector3.up); // 0
        var up = Vector3.Cross(Vector3.forward, Vector3.right); // (0, 1, 0)

        var lerped = Vector3.Lerp(Vector3.zero, Vector3.one, 0.5f);
        lerped = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, 0.5f);


        // a dot b = |b| * cos(theta)
        // x = cos(theta)
        // theta = acos(x)
        // (a dot b) / |b| = cos(theta)
        // theta = acos((a dot b) / |b|)
    }

    // Update is called once per frame
    void Update()
    {
        //childTr.position += childTr.forward * Time.deltaTime;
        //childTr.Translate(Vector3.forward * Time.deltaTime, Space.Self);

        //childTr.localPosition += Vector3.forward * Time.deltaTime;
        //childTr.Translate(childTr.forward * Time.deltaTime, Space.World);

        //transform.Rotate(Vector3.up * Time.deltaTime * 30f, Space.Self);
        //transform.Rotate(transform.up * Time.deltaTime * 30f, Space.World);

        //transform.rotation *= Quaternion.Euler(transform.up * Time.deltaTime * 30f);
        //transform.localRotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * 30f);

        var toTarget = (childTr.position - transform.position).normalized;
        var dot = Vector3.Dot(transform.forward, toTarget);
        var angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        Debug.Log($"ACos {angle}");

        angle = Vector3.Angle(transform.forward, toTarget);
        Debug.Log($"Angle {angle}");

    }


}
