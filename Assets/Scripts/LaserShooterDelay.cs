using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserShooterDelay : ClickSpawner
{
    [SerializeField] NumberField scoreField;
    [SerializeField] float secondsBetweenSpawns = 0.5f;

 

    private void update()
    {

        if (spawnAction.WasPressedThisFrame())
        {
            spawnObject();

        }
    }

    protected override GameObject spawnObject()
    {
        GameObject newObject = base.spawnObject();  // base = super

        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField);

        return newObject;
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            //GameObject newObject = base.spawnObject();  // base = super

            // Modify the text field of the new object.
            //ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            // if (newObjectScoreAdder)
            //  newObjectScoreAdder.SetScoreField(scoreField);
            yield return new WaitForSeconds(secondsBetweenSpawns);


        }
    }
}
