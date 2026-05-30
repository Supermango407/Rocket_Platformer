using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Asteroid : MonoBehaviour
{
    public Sprite[] asteroidSprites;
    private float turnSpeed = 0.0f;

    private void Start()
    {
        randomizeAsteroid();
    }

    private void randomizeAsteroid()
    {
        // set the random seed based on the position of the asteroid to
        // ensure that the same asteroid always has the same random properties
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        // Cantor pairing formula
        int seed = (x + y) * (x + y + 1) / 2 + y;

        Random.InitState(seed);
        Debug.Log("Random seed: " + seed);

        // randomly set the turn speed for the asteroid with a bias towards smaller values and
        // a minimum of 0.25 and a maximum of 1, and randomly make it positive or negative
        float randomValue = Random.Range(0.25f, 1f); // Get a random value between 0.25 and 1
        randomValue *= randomValue; // Square the random value to skew it towards smaller numbers
        randomValue *= Random.value < 0.5f ? 1 : -1; // Randomly make it positive or negative
        turnSpeed = randomValue * 100f;

        // randomly set the scale of asteroid between 0.05 and 0.1 with a bias towards smaller values
        float randomScale = Random.value; // Get a random value between 0 and 1
        randomScale *= randomScale; // Square the random value to skew it towards smaller numbers
        randomScale = Mathf.Lerp(0.05f, 0.1f, randomScale); // Map the skewed value to the desired range
        transform.localScale = new Vector3(randomScale, randomScale, 1f);

        // Randomly select a sprite for the asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (asteroidSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, asteroidSprites.Length);
            spriteRenderer.sprite = asteroidSprites[randomIndex];
        }
    }

    private void Update()
    {
        // Rotate the asteroid
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }
}
