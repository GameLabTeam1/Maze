using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDropHandler : MonoBehaviour
{
    [Tooltip ("Place here the cheese prefab")]
    public GameObject Cheese;
    [Tooltip ("Amount of blocks of cheese the mouse has")]
    public int MaxCheeseAmount;
    public HUD HUDScreen;

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
            CheeseDrop();
            
        }
        if (Input.GetKeyDown(KeyCode.C) && m_TouchingCheese)
        {
            CheesePickUp();
            
        }
    }

    ///// <summary>
    ///// choose what to do with the cheese (drop one or pick up one)
    ///// </summary>
    //private void CheeseInteract()
    //{
    //    if (m_TouchingCheese)
    //    {
    //        CheesePickUp();
    //        HUDScreen.CheesePickedUp();
    //    }
    //    else if (!m_TouchingCheese) 
    //    { 
    //        CheeseDrop();
    //        HUDScreen.CheeseDropped();
    //    }
    //}

    /// <summary>
    /// places a block of cheese if the number of cheese already spawned is not higher than the maximum amount
    /// </summary>
    private void CheeseDrop()
    {
        if(m_CheeseCount < MaxCheeseAmount && !m_TouchingCheese)
        {
            Instantiate(Cheese, transform.position, Quaternion.identity);
            m_CheeseCount++;
            HUDScreen.CheeseDropped();
        }
    }

    /// <summary>
    /// Destroys the block of cheese
    /// </summary>
    private void CheesePickUp()
    {
        if (m_TouchingCheese)
        {
            Destroy(m_SelectedCheese);
            m_CheeseCount--;
            m_TouchingCheese = false;
            m_SelectedCheese = null;
            HUDScreen.CheesePickedUp();
        }
    }

    #region Collisions

    private void OnTriggerEnter(Collider collision)
    {
            if (collision.gameObject.CompareTag("Cheese"))
            {
                m_SelectedCheese = collision.gameObject;
                m_TouchingCheese = true;
            }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            m_TouchingCheese = false;
        }
    }
    #endregion
}
