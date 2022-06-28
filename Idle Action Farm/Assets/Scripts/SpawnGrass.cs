using System.Collections;
using UnityEngine;

public class SpawnGrass : MonoBehaviour
{
    private void Start()
    {
        var obj = Instantiate(DataManager.itemPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0)).
                  GetComponent<GrassScript>().spawner = this;
    }

    private void Spawn()
    {
        var obj = Instantiate(DataManager.itemPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0)).
                 GetComponent<GrassScript>().spawner = this;
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(DataManager.timeToSpawn);

        Spawn();
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }
}
