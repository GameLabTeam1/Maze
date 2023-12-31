using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandsImage : MonoBehaviour
{
    [Tooltip("Time before this object will be destroyed")]
    public float TimeUntilDestroy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterTime(TimeUntilDestroy));
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
