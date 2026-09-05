using UnityEngine;
using System.Collections.Generic;

public class TrackGenerator : MonoBehaviour
{
    // Assign in inspector or place a prefab named "forward_track1" in a Resources folder
    public GameObject trackPrefab;

    public List<GameObject> trackList = new List<GameObject>();
    public Transform spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        FirstTrack();

        // Instantiate the prefab 3 times, using the child named "SpawnPosition" of the last placed
        // track to determine where to place the next one.
        // for (int i = 0; i < 3; i++)
        // {
        //     NextTracks();
        // }
    }

    void FirstTrack()
    {
        GameObject track = Instantiate(trackPrefab, Vector3.zero, Quaternion.identity);
        trackList.Add(track);

        foreach (Transform child in track.transform)
        {
            if (child.name == "SpawnPosition")
            {
                spawnPosition = child;
                break;
            }
        }




        //spawnPosition = track.transform.Find("SpawnPosition");
    }

    void NextTracks()
    {
        GameObject track = Instantiate(trackPrefab, spawnPosition);
        trackList.Add(track);
        //track.transform.localPosition = Vector3.zero;

        spawnPosition = track.transform.Find("SpawnPosition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
