using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyState<T> : State<T>
{
    SpaceShipController _shipController;
    public DestroyState(SpaceShipController spaceshipcontroller)
    {
        _shipController = spaceshipcontroller;
    }
    public override void Enter()
    {
        _shipController.DestroyShip();
    }
}
