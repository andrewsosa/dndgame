using UnityEngine;
using UnityEngine.Events;

public class CombatController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {

    }


}
