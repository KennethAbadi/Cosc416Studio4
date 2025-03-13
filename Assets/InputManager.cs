using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new();
    public UnityEvent OnJump = new();
    public UnityEvent OnDash = new();
    public UnityEvent OnSettingsMenu = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnSettingsMenu?.Invoke();
        }
    }

}
