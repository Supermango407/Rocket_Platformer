using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D player_rigidbody;
    private Transform player_transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
        player_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player_transform.Rotate(0, 0, 1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player_transform.Rotate(0, 0, -1f);
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            player_rigidbody.AddForce(player_transform.up * 10f);
        }
    }
}
