using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool IsPaused { get; private set; } = false;

    public static void SetPause(bool pause)
    {
        IsPaused = pause;

        if (IsPaused)
        {
            //pause stuff
        }
        else
        {
            //unpausestuff
        }
    }
}
