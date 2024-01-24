using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : MonoBehaviour
{
    [Tooltip("The number of seconds that the points will be double")][SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Double Points triggered by player");
            var laserShooter = other.GetComponent<LaserShooter>();
            if (laserShooter)
            {
                StartCoroutine(DoubleThePoints(laserShooter));        // co-routine
                                                                                             // NOTE: If you just call "StartCoroutine", then it will not work, 
                                                                                             //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        }
        else
        {
            Debug.Log("Shield triggered by " + other.name);
        }
    }

    private IEnumerator DoubleThePoints(LaserShooter laserShooter)
    {   // co-routines
        for (float i = duration; i > 0; i--)
        {
            int currentScore = laserShooter.GetScoreField().GetNumber();
            int multipliedScore = currentScore * 2;
            Debug.Log("Double points" + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
            laserShooter.GetScoreField().SetNumber(multipliedScore);
        }
        Debug.Log("Double Score done!");

    }
}
