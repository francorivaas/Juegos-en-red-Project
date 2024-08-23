using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState<T> : State<T>
{
    SpaceShipController _shipController;
    T _quietInput;
    T _destroyInput;
    public MoveState(SpaceShipController spaceshipcontroller, T quietInput, T destroyInput)
    {
        _shipController = spaceshipcontroller;
        _quietInput = quietInput;
        _destroyInput = destroyInput;
    }
    public override void Sleep()
    {
        base.Sleep();
    }
    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) _shipController.QuitGame();
        if (Input.GetKeyDown(KeyCode.U)) _shipController.currentHealth = 0;
        // Transicion a Destroy sino hay vida
        if (_shipController.currentHealth <= 0)
        {
            _fsm.Transition(_destroyInput);
            return;
        }
        // Obtener el input horizontal y vertical (A/D y W/S)
        float moveX = Input.GetAxis("Horizontal"); // A/D
        float moveY = Input.GetAxis("Vertical");   // W/S
        // Calcular el deltaTime
        float theTime = Time.deltaTime;
        // Actualizar la nueva dirección del controlador
        _shipController.newDirection = new Vector2(moveX, moveY);
        // Calcular los vectores de movimiento lateral y vertical
        Vector3 side = _shipController.Speed * moveX * theTime * _shipController.shipTr.right;
        Vector3 vertical = _shipController.Speed * moveY * theTime * _shipController.shipTr.up;
        // Calcular la dirección final del movimiento
        Vector3 endDirection = side + vertical;
        // Aplicar la velocidad calculada al Rigidbody de la nave
        _shipController.shipRb.velocity = endDirection;
        //Disparar
        if (Input.GetKeyDown(KeyCode.Space)) _shipController.Shoot();
        //Recargar
        if (Input.GetKeyDown(KeyCode.R)) _shipController.Reload();
        // Transición a Quiet si no hay input de movimiento
        if (moveX == 0 && moveY == 0) _fsm.Transition(_quietInput);
    }
}
