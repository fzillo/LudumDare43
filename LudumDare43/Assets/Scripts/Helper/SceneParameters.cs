using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneParameters : MonoBehaviour
{
    public static bool ShowPlayButton = true;
    public static bool BeginWithOpenMenu = true;

    public bool GetShowPlayButton()
    {
        return ShowPlayButton;
    }

    public void SetShowPlayButton(bool showButton)
    {
        ShowPlayButton = showButton;
    }

    public bool GetBeginWithOpenMenu()
    {
        return BeginWithOpenMenu;
    }

    public void SetBeginWithOpenMenu(bool beginWithOpenMenu)
    {
        BeginWithOpenMenu = beginWithOpenMenu;
    }
}
