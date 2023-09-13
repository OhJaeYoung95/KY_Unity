using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Example2 : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 360f;
    public float side = 0f;
    public float sideSpeed = 10f;
    public Vector3 positiveSide = Vector3.right;
    public Vector3 negativeSide = Vector3.left;

    private Color startColor = Color.white;
    private Color endColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float s = Input.GetAxis("Side");

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    side += Time.deltaTime * sideSpeed;
        //    Mathf.Clamp(0, 1, side);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    side -= Time.deltaTime * sideSpeed;
        //    Mathf.Clamp(0, -1, side);
        //}
        //if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        //{
        //    side = 0;
        //}

        var dir = new Vector3(s, 0f, v);
        //var dir = new Vector3(side, 0f, v);

        //dir = transform.TransformDirection(dir);
        //transform.position += dir * speed * Time.deltaTime;

        transform.Translate(dir * speed * Time.deltaTime);
        transform.rotation *= Quaternion.Euler(0f, h * rotSpeed * Time.deltaTime, 0f);

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    var newGo = new GameObject("ABC");
        //    var filter = newGo.AddComponent<MeshFilter>();
        //    var ren = newGo.AddComponent<MeshRenderer>();
        //    Destroy(filter, 3f);
        //    Destroy(ren, 3f);
        //}        

       // var findGo = GameObject.Find("Sphere");

        if (Input.GetKey(KeyCode.Space))
        {
            var findGo = GameObject.Find("Sphere");
            var pos = findGo.transform.position;
            if (findGo != null)
            {
                var newPos = pos + Random.insideUnitSphere * 5f;
                var newGo = Instantiate(findGo, newPos, Quaternion.identity);
                var ren = newGo.GetComponent<Renderer>();
                var t = Vector3.Distance(pos, newPos) / 5f;
                ren.material.color = Color.Lerp(startColor, endColor, t);
            }
        }
    }
}
