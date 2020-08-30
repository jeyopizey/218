using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    [SerializeField]List<GameObject> m_props = new List<GameObject>();
    [SerializeField]float m_interval;
    [SerializeField]int m_maxCount;
    [SerializeField]float m_xRange;
    [SerializeField]float m_yRange;
    [SerializeField]float m_zRange;

    private float m_timer;

    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_interval)
        {
            int randCount = Random.Range(0, m_maxCount);
            for (int i = 0; i < randCount; i++)
            {
                Vector3 randPos;
                randPos = new Vector3(this.transform.position.x + Random.Range(-m_xRange, m_xRange),
                                      this.transform.position.y + Random.Range(-m_yRange, m_yRange),
                                      this.transform.position.z + Random.Range(-m_zRange, m_zRange));
                GameObject prop = Instantiate(m_props[Random.Range(0, m_props.Count)], randPos, Quaternion.identity);
                float randSize = Random.Range(1, 1.3f);
                prop.transform.localScale = new Vector3(randSize, randSize, randSize);
                Destroy(prop, Random.Range(11, 15));
            }
            m_timer = 0;
        }
    }
}
