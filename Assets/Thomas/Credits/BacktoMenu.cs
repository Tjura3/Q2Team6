using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoMenu : MonoBehaviour
{
    public LevelLoader LL;
    public void Back()
    {
        LL.LoadMainMenu();
    }
}
