using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    protected abstract void CollectPowerUp(Player player);

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;
    [SerializeField] float powerUpDuration = 1f;
    [SerializeField] GameObject _powerUp;
    [SerializeField] GameObject _art;
    Collider _collider;


    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            CollectPowerUp(player);
            //spawn particles & sfx because we need to disable object
            Feedback();

            PowerUp();
            _art.SetActive(false);
            _collider.enabled = !_collider.enabled;

            Debug.Log("Got Powerup");
            StartCoroutine(PowerUpTimer());
        }
    }

    protected abstract void PowerUp();
    protected abstract void PowerDown();

    IEnumerator PowerUpTimer()
    {
        Debug.Log("Power up started");

        yield return new WaitForSeconds(5);
        PowerDown();
        Debug.Log("Lost Powerup");
        Debug.Log("Power up ended");
        _powerUp.SetActive(false);
    }

    private void Feedback()
    {
        //particles 
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
        }
        //audio. TODO - consider Object Pooling for performance
        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }
}

