using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickToMove : MonoBehaviour
    {
        NavMeshAgent m_Agent;
        RaycastHit m_HitInfo = new RaycastHit();

        [SerializeField]
        public float agentSpeed = 3.5f; // Default speed, adjustable in the Inspector

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_Agent.speed = agentSpeed; // Set the NavMeshAgent's speed
        }

        void Update()
        {
            // Check for left mouse click and if Left Shift is not held
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    m_Agent.destination = m_HitInfo.point;
            }

            // Update the agent's speed if you change it in the Inspector
            m_Agent.speed = agentSpeed;
        }
    }
}
