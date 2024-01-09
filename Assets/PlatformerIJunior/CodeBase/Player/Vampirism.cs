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
    [SerializeField] private float _delay = 0.5f;

    private RaycastHit2D[] _hit = new RaycastHit2D[1];
    private Coroutine _takeHealthJob;
    private EnemieHealth _enemyHealth;
    private bool _isVampirism;

    private void Start()
    {
        _isVampirism = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && _isVampirism)
        {
            _isVampirism = false;

            StopTakeHealth();

            _takeHealthJob = StartCoroutine(TakeHealth());            
        }
    }    

    private IEnumerator TakeHealth()
    {
        float duration = _duration;

        WaitForSeconds waitTime = new WaitForSeconds(_delay);

        while (duration > 0)
        {
            duration -= _delay;
            int hitCount = VisualPhysics2D.CircleCastNonAlloc(transform.position, _radius, Vector3.zero, _hit, _collisions);            

            if (hitCount > 0)
            {
                _enemyHealth = _hit[0].transform.GetComponent<EnemieHealth>();

                if(_enemyHealth != null )
                {
                    _enemyHealth.TakeDamage(_healthInDelay);
                    _health.Heal(_healthInDelay);
                }                                                
            }            

            yield return waitTime;
        }

        _isVampirism = true;
    }

    private void StopTakeHealth()
    {
        if (_takeHealthJob != null)
            StopCoroutine(_takeHealthJob);
    }
}