using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnTime = 0;
    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        var findGo = GameObject.FindWithTag("Player");
        target = findGo.transform;

        spawnTime = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= spawnTime)
        {
            timeAfterSpawn = 0;
            spawnTime = Random.Range(spawnRateMin, spawnRateMax);
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.LookAt(target);
        }
    }
}
