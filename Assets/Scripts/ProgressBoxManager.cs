using System;
using System.Collections;
using UnityEngine;

public class ProgressBoxManager : MonoBehaviour
{
    [SerializeField] private GameObject changePrefab;
    private Canvas canvas;
    private GameObject item;
    private bool isBusy;

    void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        setBusy(false);
    }

    public void addItem(GameObject itemPrefab)
    {
        if (item != null) return;
        item = Instantiate(itemPrefab, transform.position + new Vector3(0, 0.5f, 0), transform.rotation, transform);
    }

    public GameObject hitAction()
    {
        if (item == null || isBusy) return null;
        ItemProgress itemProgress = item.GetComponent<ItemProgress>();
        if (itemProgress.isDone())
        {
            GameObject returnItem = item;
            removeItem();
            return returnItem;
        }
        StartCoroutine(waitAction(itemProgress, doneAction));
        return null;
    }

    void doneAction()
    {
        float oldTotalProgress = item.GetComponent<ItemProgress>().getTotalProgress();
        removeItem();
        addItem(changePrefab);
        ItemProgress newProgress = item.GetComponent<ItemProgress>();
        newProgress.setCurrentProgress(oldTotalProgress);
        newProgress.setTotalProgress(oldTotalProgress);
    }

    IEnumerator waitAction(ItemProgress itemProgress, Action doneAction) 
    {
        setBusy(true);
        yield return new WaitForSeconds(itemProgress.getWaitForStep());
        float progressRate = itemProgress.increaseProgress();
        Debug.Log("İşlem yüzdesi: %" + progressRate);
        if (itemProgress.isDone()) doneAction();
        setBusy(false);
    }

    void removeItem()
    {
        Destroy(item);
        item = null;
    }

    void setBusy(bool isBusy)
    {
        this.isBusy = isBusy;
        canvas.gameObject.SetActive(isBusy);
    }
}
