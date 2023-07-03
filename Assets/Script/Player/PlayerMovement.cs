using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private RaycastHit _hit;
    private NavMeshAgent _agent;
    [SerializeField] private LayerMask _floorlayerMask;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Animator _animator;
    public UIDialogue uiDialogue;
    private bool isInDialogueRange = false;
    private bool isInKeyRange = false;
    private bool isInDoorRange = false;
    private bool isInObstaclesRange = false;
    private bool isTriggered = false;
    private string _textClone;
    private Obstacles currentObstacle = null;
    private GameObject currentKey = null;
    private Door currentDoor = null;
    private KeyInventory _keyInventory;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _keyInventory = GetComponent<KeyInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit, Mathf.Infinity, _floorlayerMask))
            {
                _agent.SetDestination(_hit.point);
            }
        }

        if (_agent.remainingDistance > _maxDistance)
        {
            _agent.ResetPath();
            Debug.Log("Annullato");
        }

        if (isInDialogueRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!uiDialogue.dialoguePanel.activeSelf)
            {
                // Se il pannello del dialogo non è attivo, avvia il dialogo
                uiDialogue.ShowDialogue(_textClone);
            }
            else
            {
                // Se il pannello del dialogo è attivo, chiudi il dialogo
                uiDialogue.HideDialogue();
            }
        }

        if (isInObstaclesRange && Input.GetKeyDown(KeyCode.E)) //Se si vuole che lo faccia sempre togliere: isInObstaclesRange
        {
            _animator.SetBool("TAIL", true);
            if (!isTriggered && currentObstacle != null)
            {
                currentObstacle.Use();
                isTriggered = true;
                currentObstacle.uIPrompt.SetActive(false);
            }
        } else if (Input.GetKeyUp(KeyCode.E))
        {
            _animator.SetBool("TAIL", false);
        }

        if (isInKeyRange && Input.GetKeyDown(KeyCode.E))
        {
            _keyInventory.AddKey(currentKey);
            Destroy(currentKey);
        }

        if (isInDoorRange && Input.GetKeyDown(KeyCode.E))
        {
            currentDoor.Open();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SnakeDialogue snakeDialogue = other.GetComponent<SnakeDialogue>();
        Obstacles obstacle = other.GetComponent<Obstacles>();
        Door door = other.GetComponent<Door>();
        if (snakeDialogue != null)
        {
            isInDialogueRange = true;
            _textClone = snakeDialogue.dialogueText;
            snakeDialogue.uIPrompt.SetActive(true);
        }
        if (obstacle != null)
        {
            isInObstaclesRange = true;
            currentObstacle = obstacle;
            Debug.Log("Sasso copiato");
            if (!obstacle.IsTriggered())
            {
                obstacle.uIPrompt.SetActive(true);
                isTriggered = false;
            }
            else isTriggered = true;
        }

        if (door != null)
        {
            isInDoorRange = true;
            currentDoor = door;
        }

        if (other.gameObject.CompareTag("Key"))
        {
            isInKeyRange = true;
            currentKey = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SnakeDialogue snakeDialogue = other.GetComponent<SnakeDialogue>();
        Obstacles obstacle = other.GetComponent<Obstacles>();
        Door door = other.GetComponent<Door>();
        if (snakeDialogue != null)
        {
            isInDialogueRange = false;
            uiDialogue.HideDialogue();
            _textClone = string.Empty;
            snakeDialogue.uIPrompt.SetActive(false);
        }
        if (obstacle != null)
        {
            isInObstaclesRange = false;
            currentObstacle = null;
            Debug.Log("Sasso lontano");
            obstacle.uIPrompt.SetActive(false);
        }
        if (door != null)
        {
            isInDoorRange = false;
            currentDoor = null;
        }
        if (other.gameObject.CompareTag("Key"))
        {
            isInKeyRange = false;
            currentKey = null;
        }
    }
}
