using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void OpenMusicURL() {
        Application.OpenURL("https://www.tam-music.com/");
    }

    public void OpenSFXURL() {
        Application.OpenURL("https://www.zapsplat.com");
    }
}
