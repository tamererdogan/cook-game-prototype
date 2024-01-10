using UnityEngine;

public class ItemProgress : MonoBehaviour
{
    [SerializeField] private float totalProgress;
    [SerializeField] private float waitForStep;
    private float currentProgress;

    public float getTotalProgress()
    {
        return totalProgress;
    }

    public void setTotalProgress(float totalProgress)
    {
        this.totalProgress = totalProgress;
    }

    public float getWaitForStep()
    {
        return waitForStep;
    }

    public float getCurrentProgress()
    {
        return currentProgress;
    }

    public void setCurrentProgress(float currentProgress)
    {
        this.currentProgress = currentProgress;
    }

    public float increaseProgress()
    {
        currentProgress++;
        return currentProgress * 100 / totalProgress;
    }

    public bool isDone()
    {
        return currentProgress >= totalProgress;
    }
}