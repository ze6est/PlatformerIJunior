using UnityEngine;

public class Aggro : MonoBehaviour
{
    [SerializeField] private TriggerObserver _triggerObserver;
    [SerializeField] private WaipointMovement _waipointMovement;
    [SerializeField] private AgentMoveToPlayer _follow;

    private void OnEnable()
    {
        _triggerObserver.TriggerEntered += OnTriggerEntered;
        _triggerObserver.TriggerExited += OnTriggerExited;
    }

    private void Start()
    {
        _follow.enabled = false;
    }

    private void OnDisable()
    {
        _triggerObserver.TriggerEntered -= OnTriggerEntered;
        _triggerObserver.TriggerExited -= OnTriggerExited;
    }

    private void OnTriggerEntered(Collider2D arg0)
    {
        _waipointMovement.enabled = false;
        _follow.enabled = true;
    }

    private void OnTriggerExited(Collider2D arg0)
    {
        _follow.enabled = false;
        _waipointMovement.enabled = true;
    }
}