using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ColorByDistance : MonoBehaviour
{
    private Color startColor = Color.black;
    private Color endColor = Color.white;
    public GameObject[] spheres;

    private float minDis = float.MaxValue;
    private float maxDis = float.MinValue;    
    
    // Start is called before the first frame update
    void Start()
    {
        //thisRen = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        minDis = float.MaxValue;
        maxDis = float.MinValue;

        foreach (var obj in spheres)
        {
            float objDis = Vector3.Distance(transform.position, obj.transform.position);
            if (objDis > maxDis)
                maxDis = objDis;

            if (objDis < minDis)
                minDis = objDis;
        }

        foreach (var obj in spheres)
        {
            var t = (Vector3.Distance(transform.position, obj.transform.position) - minDis) / (maxDis - minDis);
            var ren = obj.GetComponent<Renderer>();
            ren.material.color = Color.Lerp(startColor, endColor, t);
        }
    }
}
