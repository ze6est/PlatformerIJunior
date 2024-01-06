using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] private int _healing = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.Heal(_healing);
            Destroy(gameObject);
        }
    }
}