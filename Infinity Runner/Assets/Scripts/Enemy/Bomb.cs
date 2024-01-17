using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rig;
    private Player player;

    public int damage;

    public float xAxis;
    public float yAxis;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.OnHit(damage);
        }
    }
}
