using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SquareController : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float fallSpeed;

    private void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        if(collision.gameObject.tag != "Square"){
            Destroy(gameObject);
        }
    }
}

