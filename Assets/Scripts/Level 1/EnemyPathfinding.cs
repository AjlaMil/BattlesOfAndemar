using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(Attack(path));
        transform.Rotate(0, 90, 0); // DORADI OVOOO
    }

    IEnumerator Attack(List<Waypoint> path) // With IEnumerator, this now becomes a coroutine, which means it can run alongside other things.
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 pos = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 6 , waypoint.transform.position.z);

            transform.position = pos;
            yield return new WaitForSeconds(1f);
        }
    }

 
}
