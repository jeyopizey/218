using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleChecker : MonoBehaviour
{
    [SerializeField]private List<GameObject> m_objectsToTele = new List<GameObject>();

    void OnTriggerEnter(Collider p_col)
    {
        if (p_col.tag == "CanTeleport" || p_col.tag == "Player")
        {
            m_objectsToTele.Add(p_col.gameObject);
        }
    }

    void OnTriggerExit(Collider p_col)
    {
        m_objectsToTele.Remove(p_col.gameObject);
    }

    public List<GameObject> ObjectsToTele
    {
        get { return m_objectsToTele; }
    }
}
