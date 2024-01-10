using System.Linq;
using UnityEngine;

public class ChefActionManager : MonoBehaviour
{
    private string[] canBeChopList = {"Cheese"};
    private string[] canBeCookList = {"Meat"};
    private float distance = 1f;
    [SerializeField] private GameObject handItem;
    [SerializeField] private GameObject breadPrefab;
    [SerializeField] private GameObject meatPrefab;
    [SerializeField] private GameObject cheesePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit? hit = GetHit();
            if (hit == null) return;
            string name = hit?.transform.gameObject.name;
            if (handItem == null)
            {
                switch (name) {
                    case "BreadBox":
                        takeItem(breadPrefab);
                        break;
                    case "MeatBox":
                        takeItem(meatPrefab);
                        break;
                    case "CheeseBox":
                        takeItem(cheesePrefab);
                        break;
                    case "ChoppingBoard":
                    case "Furnace":
                        GameObject progressItem = hit?.collider?.GetComponent<ProgressBoxManager>().hitAction();
                        if (progressItem == null) return;
                        takeItem(progressItem);
                        break;
                }
            } else {
                switch (name) {
                    case "Trash":
                        leaveItem();
                        break;
                    case "Plate":
                        hit?.collider?.GetComponent<PlateManager>().addItem(handItem);
                        leaveItem();
                        break;
                    case "ChoppingBoard":
                        if (!canBeChopList.Contains(handItem.gameObject.tag)) return;
                        hit?.collider?.GetComponent<ProgressBoxManager>().addItem(handItem);
                        leaveItem();
                        break;
                    case "Furnace":
                        if (!canBeCookList.Contains(handItem.gameObject.tag)) return;
                        hit?.collider?.GetComponent<ProgressBoxManager>().addItem(handItem);
                        leaveItem();
                        break;
                }
            }
            
        }
    }

    private RaycastHit? GetHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance)) return hit;
        return null;
    }

    private void takeItem(GameObject itemPrefab)
    {
        handItem = Instantiate(itemPrefab, transform.position + new Vector3(0, 1.2f, 0), transform.rotation, transform);
    }

    private void leaveItem()
    {
        Destroy(handItem);
        handItem = null;
    }
}
