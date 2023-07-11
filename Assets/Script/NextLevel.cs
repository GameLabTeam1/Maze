using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public CameraFade cameraFade;
    public HUD hud;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            player.enabled = false;
            hud.SaveTime();
            StartCoroutine(TeleportPlayerToNextLevel());
        }
    }

    public IEnumerator TeleportPlayerToNextLevel()
    {
        cameraFade.FadeNextLevel();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
