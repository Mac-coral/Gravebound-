using UnityEngine;

public class CassettePlayer : MonoBehaviour
{
    [Header("Cassette Settings")]
    public ItemObject[] cassetteItems;
    private int insertedCassettes = 0;

    [Header("Maze Gate Settings")]
    public GameObject mazeGate;

    private bool isGateOpened = false;

    public void InsertCassette(ItemObject cassette)
    {
        for (int i = 0; i < cassetteItems.Length; i++)
        {
            if (cassetteItems[i] == cassette && cassetteItems[i] != null)
            {
                Debug.Log("Cassette inserted: " + cassette.name);
                cassetteItems[i] = null; // mark as used
                insertedCassettes++;
                break;
            }
        }

        if (!isGateOpened && insertedCassettes >= cassetteItems.Length)
        {
            Debug.Log("All cassettes inserted! Opening the maze gate...");
            isGateOpened = true;
            OpenGate();
        }
    }

    void OpenGate()
    {
        if (mazeGate != null)
        {
            StartCoroutine(LowerGate());
        }
    }

    System.Collections.IEnumerator LowerGate()
    {
        Vector3 startPos = mazeGate.transform.position;
        Vector3 endPos = startPos + Vector3.down * 5f;
        float duration = 2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            mazeGate.transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mazeGate.transform.position = endPos;
    }
}
