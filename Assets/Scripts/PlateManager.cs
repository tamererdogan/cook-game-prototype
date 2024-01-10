using System.Collections.Generic;
using UnityEngine;

public class PlateManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private List<GameObject> hamburgerItemList = new List<GameObject>();
    private string[] hamburgerItemOrder = {"Bread", "CookedMeat", "ChoppedCheese", "Bread"};

    public void addItem(GameObject itemPrefab)
    {
        GameObject createdItem = Instantiate(itemPrefab, transform.position + new Vector3(0, 0.5f + getPositionOffset(), 0), transform.rotation, transform);
        hamburgerItemList.Add(createdItem);
        if (!checkOrder()) wrongOrderAction();
        if (hamburgerItemList.Count == 4) successOrderAction();
    }

    private void successOrderAction()
    {
        int score = uiManager.addScore();
        if (score >= 300) uiManager.gameOverAction();
        clearList();
        Debug.Log("Başarılı sipariş.");
    }

    private void wrongOrderAction()
    {
        int health = uiManager.reduceHealth();
        if (health <= 0) uiManager.gameOverAction();
        clearList();
        Debug.Log("Hatalı sipariş.");
    }

    private void clearList()
    {
        foreach (GameObject hamburgerItem in hamburgerItemList) Destroy(hamburgerItem);
        hamburgerItemList.Clear();
    }

    private float getPositionOffset()
    {
        float offset = 0f;
        foreach (GameObject hamburgerItem in hamburgerItemList) offset += hamburgerItem.transform.localScale.y * 2;
        return offset;
    }

    private bool checkOrder()
    {
        if (hamburgerItemList.Count > 4) return false;
        for (int i = 0; i < hamburgerItemList.Count; i++)
            if (hamburgerItemList[i].transform.tag != hamburgerItemOrder[i]) return false;

        return true;
    }
}
