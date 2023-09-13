using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigid;
    public float speed = 10f;


    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        rigid.velocity = new Vector3(h, 0, v) * speed;
    }

    public void OnDie()
    {
        gameObject.SetActive(false);

        var findGo = GameObject.FindWithTag("GameController");
        var gameManager = findGo.GetComponent<GameManager>();
        gameManager.EndGame();
    }
}
