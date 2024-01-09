using System.Collections;
using Nomnom.RaycastVisualization;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] private LayerMask _collisions;
    [SerializeField] private float _radius = 2;
    [SerializeField] private int _healthInDelay;
    [SerializeField] private float _duration = 6;
    [SerializeField] private float _delay = 1;

    private RaycastHit2D[] _hit = new RaycastHit2D[1];
    private Coroutine _takeHealthJob;
    private Health _enemieHealth;
    private bool _isVampirism;
    private bool _abilityIsReady;

    private void Start()
    {
        _abilityIsReady = true;
    }

    private void Update()
    {
        int hitCount = VisualPhysics2D.CircleCastNonAlloc(transform.position, _radius, Vector3.zero, _hit, _collisions);

        if (hitCount > 0)
        {
            _isVampirism = true;
            _enemieHealth = _hit[0].transform.GetComponent<Health>();
        }
        else
        {
            _isVampirism = false;
            StopTakeHealth();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && _isVampirism && _abilityIsReady)
        {
            StopTakeHealth();

            _takeHealthJob = StartCoroutine(TakeHealth());            
        }
    }    

    private IEnumerator TakeHealth()
    {
        _abilityIsReady = false;

        float duration = _duration;

        WaitForSeconds waitTime = new WaitForSeconds(_delay);

        while (duration > 0)
        {
            duration -= _delay;

            if(_enemieHealth != null)
            {
                _enemieHealth.TakeDamage(_healthInDelay);
                _health.Heal(_healthInDelay);
            }            

            yield return waitTime;
        }

        _abilityIsReady = true;
    }

    private void StopTakeHealth()
    {
        if (_takeHealthJob != null)
            StopCoroutine(_takeHealthJob);
    }
}