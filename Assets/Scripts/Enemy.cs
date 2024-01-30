using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Destroy_Effect;

    void OnCollisionEnter2D(Collision2D Target)
    {
        if (Target.collider.GetComponent<Bird>())
        {
            Instantiate(Destroy_Effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameController.instance.EnemyDefeated(); // Notify GameController when enemy is destroyed
        }
        else if (Target.contacts[0].normal.y < 0.5)
        {
            Instantiate(Destroy_Effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameController.instance.EnemyDefeated(); // Notify GameController when enemy is destroyed
        }
    }
}
