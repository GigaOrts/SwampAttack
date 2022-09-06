using System.Collections;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private int _burstShootCount;

    private WaitForSeconds _waitForTime;
    private Coroutine _coroutine;

    private float _burstDelay = 0.2f;

    private void Awake()
    {
        _waitForTime = new WaitForSeconds(_burstDelay);
    }

    public override void Shoot(Transform shootPoint)
    {
        if (_coroutine != null)
            StopCoroutine(BurstShootCoroutine(shootPoint));

        _coroutine = StartCoroutine(BurstShootCoroutine(shootPoint));
    }

    private IEnumerator BurstShootCoroutine(Transform shootPoint)
    {
        for (int i = 0; i < _burstShootCount; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            yield return _waitForTime;
        }
    }
}
