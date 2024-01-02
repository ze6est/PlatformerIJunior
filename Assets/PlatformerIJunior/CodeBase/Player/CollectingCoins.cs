using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Coin>())
            Destroy(collision.gameObject);
    }
}