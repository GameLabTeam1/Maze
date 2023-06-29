using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDropHandler : MonoBehaviour
{
    [Tooltip ("Place here the cheese prefab")]
    public GameObject Cheese;
    [Tooltip ("Amount of blocks of cheese the mouse has")]
    public int MaxCheeseAmount;
    public HUD HUDscreen;

    #region PrivateVars
    private int m_CheeseCount; //how many block of cheese have already been spawned
    private GameObject m_SelectedCheese;
    private bool m_TouchingCheese = false;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheeseInteract();
        }
    }

    /// <summary>
    /// choose what to do with the cheese (drop one or pick up one)
    /// </summary>
    private void CheeseInteract()
    {
        if (m_TouchingCheese)
        {
            CheesePickUp();
            HUDscreen.CheesePickedUp();
        }
        else if (!m_TouchingCheese) 
        { 
            CheeseDrop();
            HUDscreen.CheeseDropped();
        }
    }

    /// <summary>
    /// places a block of cheese if the number of cheese already spawned is not higher than the maximum amount
    /// </summary>
    private void CheeseDrop()
    {
        if(m_CheeseCount <= MaxCheeseAmount)
        {
            Instantiate(Cheese, transform.position, Quaternion.identity);
            m_CheeseCount++;
        }
    }

    /// <summary>
    /// Destroys the block of cheese
    /// </summary>
    private void CheesePickUp()
    {
        Destroy(m_SelectedCheese);
    }

    #region Collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ICheese isCheese))
        {
            m_TouchingCheese = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ICheese isCheese))
        {
            m_TouchingCheese = false;
        }
    }
    #endregion
}
