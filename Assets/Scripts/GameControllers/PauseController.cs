using UnityEngine;

public class PauseController : MonoBehaviour
{
    private static PlayerMovement movement;
    private static PlayerLook look;

    void Start()
    {
        movement = FindAnyObjectByType<PlayerMovement>();
        look = FindAnyObjectByType<PlayerLook>();
    }

    public static bool IsPaused { get; private set; } = false;

    public static void SetPause(bool pause) // allows for pausing the game (specifically the character) from any script
    {
        IsPaused = pause;

        if (IsPaused)   // disables and renables movement and look controllers based on pause state
        {
            movement.enabled = false;
            look.enabled = false;
        }
        else
        {
            movement.enabled = true;
            look.enabled = true;
        }
    }
}
