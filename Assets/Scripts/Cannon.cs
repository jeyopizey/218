using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]GameObject m_pDagger;
    [SerializeField]float m_interval;
    [SerializeField]TeleChecker m_teleChecker;
    [SerializeField]Transform m_spawnPoint;
    [SerializeField]Transform m_direction;
    private float m_timer = 0;

    void Update()
    {
        m_timer += Time.deltaTime;
        if ( m_timer >= m_interval)
        {
            GameObject dagger = Instantiate(m_pDagger, m_spawnPoint.position, Quaternion.identity);
            dagger.transform.GetComponent<Dagger>().SetUp((m_direction.position - m_spawnPoint.position).normalized, this);
            dagger.transform.parent = this.transform;
            m_timer = 0;
        }
    }

    public List<GameObject> ObjectsToTele
    {
        get { return m_teleChecker.ObjectsToTele; }
    }

}
