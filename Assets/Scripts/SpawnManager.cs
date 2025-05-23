using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform[] prefabObj;
    public static Vector2 newSpawnPos;
    private bool isDragging = false;
    private string spawnedYet = "n";
    private string newPrefab = "n";
    private GameObject lastPrefabInstance;
    static public int whichPrefab = 0;

    public string SpawnedYet
    {
        get { return spawnedYet; }
        set { spawnedYet = value; }
    }

    public string NewPrefab
    {
        get { return newPrefab; }
        set { newPrefab = value; }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        spawnPrefabs();
        replacePrefab();

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        // If the left mouse button is being held down, move the object
        if (isDragging)
        {
            // Get the position of the mouse in screen space and convert it to world space
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Set the velocity based on the difference between the current object position and the mouse position
            GetComponent<Rigidbody2D>().velocity = new Vector2(mousePos.x - transform.position.x, 0);
        }

        Debug.DrawRay(spawnPoint.position, Vector2.down * 10f, Color.blue);
        Debug.Log("RayVisible");
    }

    void spawnPrefabs()
    {
        if (spawnedYet == "n")
        {
            StartCoroutine(spawnTimer());
            spawnedYet = "w";
        }
    }

    void replacePrefab()
    {
        if (newPrefab == "y")
        {
            newPrefab = "n";
            int nextIndex = whichPrefab + 1;
            if (nextIndex < prefabObj.Length)
            {
                // Instantiate the next prefab and store the reference
                lastPrefabInstance = Instantiate(prefabObj[nextIndex].gameObject, newSpawnPos, prefabObj[0].rotation);
            }
            else
            {
                // If the index is out of bounds, destroy the last instantiated prefab
                if (lastPrefabInstance != null)
                {
                    Destroy(lastPrefabInstance.gameObject);
                }
            }
        }
    }

    public void MergeSound()
    {
        AudioSource mergeSound = GetComponent<AudioSource>();
        if (mergeSound != null)
        {
            mergeSound.PlayOneShot(mergeSound.clip);
        }
        else
        {
            Debug.LogError("AudioSource component not found on the SpawnManager.");
        }
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(.75f);
        Instantiate(prefabObj[Random.Range(0, 4)], transform.position, prefabObj[0].rotation);
        spawnedYet = "y";
    }

    public void MergeMute()
    {
        AudioSource mergeSound = GetComponent<AudioSource>();
        mergeSound.mute = !mergeSound.mute;
    }
}


