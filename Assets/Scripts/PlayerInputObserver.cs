//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputObserver : MonoBehaviour
{
    public event Action<Vector3> onMoveInput;  // gets move direction (not row)
    public event Action onPlayerStopped;
    public event Action onShootInput; // gets mouse click position

    private void Update()
    {
        CatchMoveInput();
        CatchShootInput();
    }

    private void CatchMoveInput()
    {
        Vector3 axisInput = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        if(axisInput != Vector3.zero)
        {
            onMoveInput?.Invoke(axisInput);
        }
        else
        {
            onPlayerStopped?.Invoke();
        }
    }

    private void CatchShootInput()
    {
        if(Input.GetMouseButton(0))
        {
            onShootInput?.Invoke();
        }
    }
}
