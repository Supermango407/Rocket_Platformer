using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float turn_speed = 0.1f;

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
            player_rigidbody.AddTorque(turn_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player_rigidbody.AddTorque(-turn_speed);
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            player_rigidbody.AddForce(player_transform.up * speed);
        }
    }
}
