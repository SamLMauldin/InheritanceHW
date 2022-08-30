using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerupBase
{
    [SerializeField] Material _startingColor;
    [SerializeField] Material _endingColor;
    [SerializeField] GameObject _playerBody;
    [SerializeField] GameObject _playerTurret;


    protected override void CollectPowerUp(Player player)
    {
        player.InvincibilityPowerUp();
    }

    protected override void PowerUp()
    {
        _playerBody.GetComponent<MeshRenderer>().material = _startingColor;
        _playerTurret.GetComponent<MeshRenderer>().material = _startingColor;
    }

    protected override void PowerDown()
    {
        _playerBody.GetComponent<MeshRenderer>().material = _endingColor;
        _playerTurret.GetComponent<MeshRenderer>().material = _endingColor;
    }
}
