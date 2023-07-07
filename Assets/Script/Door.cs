using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public CameraFade cameraFade;
    [SerializeField]
    private GameObject _requiredKey;
    private KeyInventory _keyInventory;
    private Animator _doorAnim;
    public GameObject _uIPrompt;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _keyInventory = player.GetComponent<KeyInventory>();
        _doorAnim = GetComponent<Animator>();
    }

    public void Open()
    {
        if (_keyInventory.HasKey(_requiredKey))
        {
            _doorAnim.SetBool("KEY", true);
        }
        else
        {
            Debug.Log("Non hai la chiave");
        }
    }

    private IEnumerator TeleportPlayerToNextLevel()
    {
        cameraFade.FadeNextLevel();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
