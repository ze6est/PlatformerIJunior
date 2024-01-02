using UnityEngine;
using UnityEngine.Events;

public class TriggerObserver : MonoBehaviour
{
    public event UnityAction<Collider2D> TriggerEntered;
    public event UnityAction<Collider2D> TriggerExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered?.Invoke(collision);        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerExited?.Invoke(collision);        
    }
}