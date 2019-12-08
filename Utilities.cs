public class Utilities
{
    public float DistanceCalculation(Transform x, Transform y)
    {
        float z = Vector3.Distance(x, y); //distance between two transforms

        return z;
    }

    public void SpawningEnemies()
    {
        for (int i = 0; i < 49; i++)
        {
            print(EnemyList[i]);
            //making sure there are enimies
            if (EnemyList[i] == null)
            {
                print("Spawn new enemy");
                //getting a random position in the map
                randPos = new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40));
                GameObject newEnemy = new GameObject("Enemy"); //spawn the object
                newEnemy.transform.position = randPos; //move it to the random spot
                EnemyList[i] = Instantiate(Enemy, newEnemy.transform); //adding to list

            }

        }

        EnemyList = GameObject.FindGameObjectsWithTag("ai");
    }

    public void ARSelectionOnIOS()
    {
        if (Input.touchCount > 0)//# of fingers on the screen
        {
            var touch = Input.GetTouch(0); //first touch
            if (touch.phase == TouchPhase.Began)//if a touch happens
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);//camera is the point to start ray

                if (Physics.Raycast(ray, out hit, 200))//raycast to hit an object
                {

                    GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor"); //Finding image anchors in the scene
                    foreach (GameObject g in anchors) //cycling through image anchors
                    {
                        ImageAnchor anchor = g.GetComponent<ImageAnchor>(); //getting script off image anchor
                        if (hit.transform.name == anchor.select.name)//chacking what anchor was tapped
                        {
                            //do something if the correct object was tapped
                        }
                        else
                        {
                            //do something if this is not the item tapped
                        }
                    }
                }

            }
        }
    }

    public void
}