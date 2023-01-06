using System;
using System.Collections;
using UnityEngine;

public class ChickensController : MonoBehaviour
{
    public GameObject rooster;
    GameObject[] roosters;
    int[] roosterCount = new int[6];
    int totalRoosters = 0;
    int deployedRoosters = 0;

    void Start()
    {
    }

    public void PrepareChicken(int buttonIndex) {
        Vector2 position;

        switch (buttonIndex)
        {
            case 0:
                {
                    position = new Vector2(-7, 2);
                    break;
                }

            case 1:
                {
                    position = new Vector2(-7, 1);
                    break;
                }

            case 2:
                {
                    position = new Vector2(-7, 0);
                    break;
                }

            case 3:
                {
                    position = new Vector2(7, 2);
                    break;
                }

            case 4:
                {
                    position = new Vector2(7, 1);
                    break;
                }

            case 5:
                {
                    position = new Vector2(7, 0);
                    break;
                }

            default:
                {
                    position = new Vector2(0, 0);
                    break;
                }
        }

        float offset = 0.7f;
        if (position.x > 0)
        {
            offset = -0.7f;
        }

        float x = position.x + offset * roosterCount[buttonIndex];
        Instantiate(rooster, new Vector3(x, position.y, -6), rooster.transform.rotation);
        roosterCount[buttonIndex]++;
        totalRoosters++;
    }

    public void DeployChicken()
    {
        roosters = GameObject.FindGameObjectsWithTag("Rooster");
        StartCoroutine(DeploySingleRooster());
    }

    IEnumerator DeploySingleRooster() {
        while (deployedRoosters < totalRoosters)
        {
            yield return new WaitForSeconds(0.5f);
            try
            {
                GameObject rooster = roosters[deployedRoosters];
                if (rooster)
                {
                    rooster.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                    int forceX = rooster.transform.position.x > 0 ? -200 : 200;
                    roosters[deployedRoosters].GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, 0));
                    deployedRoosters++;
                }
            } catch (IndexOutOfRangeException error)
            {
                Utils.Print("FIXME");
            }
        }

        totalRoosters = 0;
        deployedRoosters = 0;
        roosterCount = new int[6];
    }
}
