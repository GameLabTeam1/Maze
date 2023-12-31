using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Camera _camera;
    private RaycastHit _hit;
    private NavMeshAgent _agent;
    [SerializeField] 
    private LayerMask _floorlayerMask;
    [SerializeField] 
    private float _maxDistance;
    private bool _isInDialogueRange = false;
    private bool _isInKeyRange = false;
    private bool _isInDoorRange = false;
    //private bool _isInObstaclesRange = false;
    private bool _isTriggered = false;
    private string _textClone;
    private Animator _animator;
    private UIDialogue _uiDialogue;
    private Key _keyClone = null;
    private Obstacles _currentObstacle = null;
    private Door _currentDoor = null;
    private KeyInventory _keyInventory;
    [SerializeField]
    private HUD _hud;
    [SerializeField] 
    private GameObject _pauseMenu;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _uiDialogue = GetComponent<UIDialogue>();
        _keyInventory = GetComponent<KeyInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMenuActive())
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit, Mathf.Infinity, _floorlayerMask))
            {
                _agent.SetDestination(_hit.point);
                _animator.SetBool("CHANGE", Random.value < 0.5f);
            }
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending)
        {
            _agent.ResetPath();
            _animator.SetBool("MOVE", false);
        }

        if (_agent.remainingDistance > 0.1f)
        {
            _animator.SetBool("MOVE", true);
        }

        if (_agent.remainingDistance > _maxDistance || IsMenuActive())
        {
            _animator.SetBool("MOVE", false);
            _agent.ResetPath();
            Debug.Log("Annullato");
        }


        if (/*_isInObstaclesRange &&*/ Input.GetMouseButtonDown(1)) //Se si vuole che lo faccia sempre togliere: isInObstaclesRange
        {
            _agent.ResetPath();
            _animator.SetBool("TAIL", true);
            _animator.SetBool("MOVE", false);
            if (!_isTriggered && _currentObstacle != null)
            {
                _currentObstacle.Use();
                _isTriggered = true;
                _currentObstacle.uIPrompt.SetActive(false);
            }
        } else if (Input.GetMouseButtonUp(1))
        {
            _animator.SetBool("TAIL", false);
        }

        if (_isInDialogueRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!_uiDialogue.dialoguePanel.activeSelf)
            {
                _uiDialogue.ShowDialogue(_textClone);
            }
            else
            {
                _uiDialogue.HideDialogue();
            }
        }

        if (_isInKeyRange && Input.GetKeyDown(KeyCode.E))
        {
            _keyClone.AddKey();
        }

        if (_isInDoorRange && Input.GetKeyDown(KeyCode.E))
        {
            _currentDoor.Open();
            _keyInventory.keys.Clear();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !IsMenuActive()) 
        {
            ResumeButton();
        }

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        SnakeDialogue snakeDialogue = other.GetComponent<SnakeDialogue>();
        Obstacles obstacle = other.GetComponent<Obstacles>();
        Door door = other.GetComponent<Door>();
        Key key = other.GetComponent<Key>();
        if (snakeDialogue != null)
        {
            _isInDialogueRange = true;
            _textClone = snakeDialogue.dialogueText;
            snakeDialogue.uIPrompt.SetActive(true);
        }
        if (obstacle != null)
        {
            //_isInObstaclesRange = true;
            _currentObstacle = obstacle;
            if (!obstacle.IsTriggered())
            {
                obstacle.uIPrompt.SetActive(true);
                _isTriggered = false;
            }
            else _isTriggered = true;
        }

        if (door != null)
        {
            _isInDoorRange = true;
            _currentDoor = door;
            //door._uIPrompt.SetActive(_keyClone);
            door._uIPrompt.SetActive(true);
        }

        if (key != null)
        {
            _keyClone = key;
            _isInKeyRange = true;
            key.uIPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SnakeDialogue snakeDialogue = other.GetComponent<SnakeDialogue>();
        Obstacles obstacle = other.GetComponent<Obstacles>();
        Door door = other.GetComponent<Door>();
        Key key = other.GetComponent<Key>();
        if (snakeDialogue != null)
        {
            _isInDialogueRange = false;
            _uiDialogue.HideDialogue();
            _textClone = string.Empty;
            snakeDialogue.uIPrompt.SetActive(false);
        }
        if (obstacle != null)
        {
            //_isInObstaclesRange = false;
            _currentObstacle = null;
            obstacle.uIPrompt.SetActive(false);
        }
        if (door != null)
        {
            _isInDoorRange = false;
            _currentDoor = null;
            door._uIPrompt.SetActive(false);
            _uiDialogue.HideDialogue();
        }
        if (key != null)
        {
            _isInKeyRange = false;
            _keyClone = null;
            key.uIPrompt.SetActive(false);
        }
    }

    private bool IsMenuActive()
    {
        return _pauseMenu.activeInHierarchy;
    }

    private void OpenMenu()
    {
        _pauseMenu.SetActive(true);
        _hud.isRunning = false;
    }
    private void CloseMenu()
    {
        _pauseMenu.SetActive(false);
        _hud.isRunning = true;
    }

    public void ResumeButton()
    {
        if (!IsMenuActive()) OpenMenu(); else CloseMenu();
    }
}
