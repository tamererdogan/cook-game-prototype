using UnityEngine;

public class ChefActionController : MonoBehaviour
{
    [SerializeField] private float distance = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit? hit = GetHit();
            if (hit != null)
            {
                Debug.Log(hit?.transform.gameObject.name);
            }
        }
    }

    private RaycastHit? GetHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance)) return hit;
        return null;
    }
}
