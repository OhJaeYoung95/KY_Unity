using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().OnDie();
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
            //var normal = other.transform.forward;
            //var reflect = Vector3.Reflect(rb.velocity.normalized, normal);
            //rb.velocity = reflect * speed;

        }
    }
}
