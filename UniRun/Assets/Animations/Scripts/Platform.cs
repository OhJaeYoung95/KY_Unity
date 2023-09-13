using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;
        foreach (var obstacle in obstacles)
        {
            obstacle.SetActive(Random.value < 0.3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !stepped)
        {
            stepped = true;
            GameManager.Instance.AddScore(1);
        }
    }
}
