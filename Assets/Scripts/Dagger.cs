using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    [SerializeField] float m_speed;
    private Vector3 m_shootDir;
    [SerializeField]private bool m_bShouldMove;
    private Cannon m_cannon;
    
    public void SetUp(Vector3 p_shootDir, Cannon p_cannon = null)
    {
        m_shootDir = p_shootDir;
        m_bShouldMove = true;
        if (p_cannon != null)
        {
            m_cannon = p_cannon;
        }
		Invoke("ShotMiss", 1.5f);
    }
    void Update()
    {
        if (m_bShouldMove) {
            transform.position += m_shootDir * m_speed * Time.deltaTime;
        }
    }

	void ShotMiss()
	{
		ShootController.Instance.CanShoot = true;
		Destroy(this.gameObject);
	}

    void OnTriggerEnter(Collider p_col)
    {
        if ( p_col.tag == "Target")
        {
            if (m_cannon) {
                //if (m_cannon.ObjectsToTele.Count == 0) { return; }
                for (int i = 0; i < m_cannon.ObjectsToTele.Count; i++)
                {
					if ( m_cannon.ObjectsToTele[i] == null) { continue; }
                    
                    if (m_cannon.ObjectsToTele[i].transform.tag != "Player")
                    {
						m_cannon.ObjectsToTele[i].transform.position = this.transform.position - (p_col.transform.position - m_shootDir).normalized * 2.5f;
                        // m_cannon.ObjectsToTele[i].transform.position = new Vector3(this.transform.position.x + Random.Range(0.1f, 0.5f),
                                                                                    // this.transform.position.y + Random.Range(0.1f, 0.5f),
                                                                                    // this.transform.position.z + Random.Range(0.1f, 0.5f));
                    } else {
                    	m_cannon.ObjectsToTele[i].transform.position = this.transform.position - (p_col.transform.position - m_shootDir).normalized * 2.5f;
					}
                }
            }
            else 
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = this.transform.position - (p_col.transform.position - m_shootDir).normalized * 3f;
				ShootController.Instance.CanShoot = true;
            }
        }
		else
		{
			if ( m_cannon ) { return; }
			ShootController.Instance.CanShoot = true;
		}
        m_bShouldMove = false;
    	Destroy(this.gameObject, 0.1f);
    }

	
}
