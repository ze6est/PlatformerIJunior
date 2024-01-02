using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            Vector2 position = new Vector2(transform.position.x, transform.position.y + 1);

            Instantiate(_coin, position, Quaternion.identity);            
        }
    }
}