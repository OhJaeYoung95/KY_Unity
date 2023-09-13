using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example3 : MonoBehaviour
{
    public GameObject sphere;
    private List<GameObject> sphereList = new List<GameObject>();

    public GameObject target;

    Vector3 direction;

    public int sphereSpawnCount;
    public int currentSphereCount;

    public float spawnRadius;

    public float speed = 3f;
    public float rotateSpeed = 2f;

    public float moveDuration = 100f;
    public float startTime = 0f;
    private Quaternion startRot;
    private Quaternion endRot;
    public bool isMoving = false;

    private Coroutine currentCo = null;


    void Start()
    {
        spawnRadius = Random.Range(5f, 20f);
        sphereSpawnCount = Random.Range(5, 15);
        currentSphereCount = -1;
    }

    void Update()
    {
        if (currentSphereCount < 0)
        {
            GameReset();
            ColorSet(sphereList[currentSphereCount]);
        }


        if (!isMoving)
        {
            float dis = Vector3.Distance(target.transform.position, transform.position);
            if (dis > 0.1f)
            {
                isMoving = true;

                direction = target.transform.position - transform.position;
                direction.Normalize();
                startTime = Time.time;
                startRot = transform.rotation;
                endRot = Quaternion.LookRotation(direction);
            }
        }
        else
        {
            if(currentCo == null)
                currentCo = StartCoroutine(Rotate());
            float dis = Vector3.Distance(target.transform.position, transform.position);

            if (dis <= 0.1f)
            {
                isMoving = false;
                sphereList.Remove(target);
                Destroy(target);
                currentSphereCount--;
                currentCo = null;
                if (currentSphereCount >= 0)
                    ColorSet(sphereList[currentSphereCount]);
            }
        }
    }

    void GameReset()
    {
        sphereSpawnCount = Random.Range(5, 15);
        currentSphereCount = sphereSpawnCount - 1;
        for (int i = 0; i < sphereSpawnCount; ++i)
        {
            Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
            var newSphere = Instantiate(sphere, randomPos, Quaternion.identity);
            sphereList.Add(newSphere);
        }
    }

    void ColorSet(GameObject obj)
    {
        var ren = obj.GetComponent<Renderer>();
        ren.material.color = Color.red;
        target = obj;
    }

    IEnumerator Rotate()
    {
        transform.rotation = Quaternion.Slerp(startRot, endRot, (Time.time - startTime));
        yield return new WaitWhile(() => (Time.time - startTime) < 1);

        StartCoroutine(Wait(2f));

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        transform.position += direction * speed * Time.deltaTime;
        yield return new WaitWhile(()=> Vector3.Distance(target.transform.position, transform.position) > 0.1f);
    }

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
