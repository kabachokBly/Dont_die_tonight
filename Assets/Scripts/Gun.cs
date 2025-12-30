using Cinemachine.Utility;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    private float timeBtwShots;
    public float startTimeBtwShots = 0;
    public float offset = -90;
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(GameInput.Instance.GetMousePosition()) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBtwShots <= 0)
        {
            if (GameInput.Instance.GetMouseButton())
            {
                Instantiate(bullet, transform.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
