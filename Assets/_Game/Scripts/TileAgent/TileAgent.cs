using UnityEngine;

using Unity.Mathematics;

public class TileAgent : MonoBehaviour
{
    private Tile _occupiedTile;
    private MovementSystem _movementSystem;

    public void Init(Tile startTile, MovementSystem movementSystem)
    {
        _occupiedTile  = startTile;
        _movementSystem = movementSystem;
    }

    private void Update()
    {
        if (Input.GetButtonDown("HorizontalLower"))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                _movementSystem.RequestMove(new int2(1, 0));
            }
            else
            {
                _movementSystem.RequestMove(new int2(-1, 0));
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _movementSystem.RequestMove(new int2(0, 1));
            }
            else
            {
                _movementSystem.RequestMove(new int2(0, 1));
            }
        }
    }
}
