using UnityEngine;

public class Cube : MonoBehaviour {


    public GameObject PrefabCube;
    GameObject newCube;
    public GameObject PrefabSphere;
    GameObject Sphere;

    int collisionCount;

    public float speed = 0.1f;
    private void Update() {

        //float currentZ = gameObject.transform.position.z;
        //currentZ += speed;
        //gameObject.transform.position = new Vector3(
        //    gameObject.transform.position.x,
        //    gameObject.transform.position.y,
        //    currentZ
        //);
    }

    void OnCollisionEnter(Collision collision) {

        Debug.Log("Collided with: " + collision.collider.name + " Count: " + collisionCount);

        if (collision.collider.name == "Obstacle" && collisionCount == 0) {

            var movingCube = collision.gameObject;
            var obstacle = collision.collider.gameObject;

            Debug.Log("Hit the Obstacle");
            var oldPosition = obstacle.transform.position;
            Destroy(obstacle);

            newCube = Instantiate(PrefabCube, oldPosition, Quaternion.identity) as GameObject;
            newCube.name = "NewCube";
            collisionCount++;
            Debug.Log("collisionCount is equal to " + collisionCount);
        }

        else if (collision.collider.name == "NewCube" && collisionCount == 1) {
        
            Debug.Log("Hit the NewCube");
            Destroy(newCube);
            Sphere = Instantiate(PrefabSphere, transform.position, Quaternion.identity) as GameObject;
            collisionCount++;
        }
    }
}

// collision.colliander triggers the collision with a specific game object, not the plane or sth that already touches the cube 
// it's essential store the old position of the obstacle and instantiate the cube in the same position so that it appear in the position of the obstacle. 