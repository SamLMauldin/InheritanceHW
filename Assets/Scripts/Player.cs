using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    int _currentTreasure;

    public Text scoreText;

    TankController _tankController;

    bool _inv = false;
    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }
    void Start()
    {
        _currentHealth = _maxHealth;
        scoreText.text = "Treasure Amount: " + _currentTreasure.ToString();
    }


    void Update()
    {
        
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if(_inv != true)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
        }
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //play particles
        //play sounds
    }

    public void Slow()
    {
        TankController controller = this.GetComponent<TankController>();
        if (controller != null)
        {
            controller.MaxSpeed = controller.MaxSpeed/2;
        }
    }

    public void IncreaseTreasure(int amount)
    {
        _currentTreasure += amount;
        scoreText.text = "Treasure Amount: " + _currentTreasure.ToString();
        Debug.Log("Player's treasure: " + _currentTreasure);
    }

    public void InvincibilityPowerUp()
    {
        _inv = !_inv;
        StartCoroutine(Timer());
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        _inv = !_inv;
    }
}
