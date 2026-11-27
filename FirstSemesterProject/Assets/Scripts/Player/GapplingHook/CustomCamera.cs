using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    public Transform target;
    public float lerpTime = 1f;
    public float elapsedTime = 0f;
    public float minDistanceToStop = 1f;
    public Vector3 startPosition;
    public bool reachedDestination = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // LERP EXAMPLE
        //if (!reachedDestination && target)
        //{
        //    elapsedTime += Time.deltaTime;
        //    transform.position = Vector3.Lerp(startPosition, target.transform.position, elapsedTime / lerpTime);
        //    if ((transform.position - target.transform.position).sqrMagnitude < minDistanceToStop)
        //    {
        //        reachedDestination = true;
        //        elapsedTime = 0f;
        //        startPosition = transform.position;
        //    }
        //}

        //SMOOTHDAMP
        if (!reachedDestination && target)
        {
            Vector3 velocity = Vector3.zero;
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position,ref velocity,1f/lerpTime);
            if ((transform.position - target.transform.position).sqrMagnitude < minDistanceToStop)
            {
                reachedDestination = true;
                elapsedTime = 0f;
                startPosition = transform.position;
            }
        }
    }
}
