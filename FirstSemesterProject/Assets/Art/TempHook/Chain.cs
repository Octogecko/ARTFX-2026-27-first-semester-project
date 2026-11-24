using System.Linq;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] float expandSpeed;
    [SerializeField] float xOffset;
    [SerializeField] float range;
    [SerializeField] float boxHeight = 2;
    [SerializeField] float endingEnemyDistance = 1f;
    [SerializeField] float endingWallDistance = 1f;
    [SerializeField] LayerMask lockableObjects;
    [SerializeField] LayerMask walls;

    private SpriteRenderer spriteRenderer;
    private GameObject player;

    private Vector3 target;
    private GameObject targetObject;
    private float distanceToTarget;
    private bool dragging = false;
    private bool approaching = false;
    private float opposite;
    private float adjacent;
    private float alpha;

    private bool reachedTarget = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetObject = ClosestLockableGameObject();
        if (targetObject == null || targetObject.CompareTag("Wall"))
        {
            target = transform.position - transform.right * range;
        }
        else
        {
            target = targetObject.transform.position;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localPosition = new Vector3(xOffset, transform.localPosition.y);
    }

    void Update()
    {
        transform.position = player.transform.position;

        if (targetObject != null)
        {
            distanceToTarget = Vector3.Distance(targetObject.transform.position, transform.position);
        }
        else
        {
            distanceToTarget = Vector3.Distance(target, transform.position);
        }

        if (reachedTarget)
        {
            spriteRenderer.size = new Vector2(spriteRenderer.size.x + expandSpeed * Time.deltaTime, spriteRenderer.size.y);
        }
        else
        {
            spriteRenderer.size = new Vector2(spriteRenderer.size.x - expandSpeed * Time.deltaTime, spriteRenderer.size.y); 
        }

        if (Mathf.Abs(spriteRenderer.size.x) >= distanceToTarget && (targetObject == null || !targetObject.CompareTag("Wall")))
        {
            reachedTarget = true;
            if (targetObject != null && targetObject.CompareTag("Enemy") && !dragging)
            {
                DragEnemy(targetObject);
            }
        }

        opposite = transform.position.y - target.y;
        adjacent = transform.position.x - target.x;
        alpha = Mathf.Atan2(opposite, adjacent) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, alpha);

        
        if (Mathf.Abs(spriteRenderer.size.x) < 0.5 && reachedTarget)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (dragging && distanceToTarget > endingEnemyDistance)
        {
            targetObject.transform.position += transform.right * expandSpeed * Time.fixedDeltaTime;
        }
        else if (dragging && distanceToTarget < endingEnemyDistance)
        {
            dragging = false;
        }

        if (approaching && distanceToTarget > endingWallDistance)
        {
            player.transform.position -= transform.right * expandSpeed * Time.fixedDeltaTime;
        }
        else if (approaching && distanceToTarget <= endingWallDistance)
        {
            approaching = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.gameObject == targetObject && targetObject.CompareTag("Wall"))
            {
                reachedTarget = true;
                ApproachTarget(targetObject);
            }
        }
    }

    private void OnDestroy()
    {
        if (targetObject != null && !targetObject.CompareTag("Wall"))
        {
            targetObject.GetComponent<IEnemyMovement>().SetMovementEnabled(true);
        }
        else if (targetObject != null && targetObject.CompareTag("Wall"))
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    private GameObject ClosestLockableGameObject()
    {
        Collider2D[] objects = Physics2D.OverlapBoxAll(transform.position - transform.right * (range / 2), new Vector2(range, boxHeight), transform.rotation.eulerAngles.z, lockableObjects).Concat(Physics2D.OverlapBoxAll(transform.position - transform.right * (range / 2), new Vector2(range, 0.72f), transform.rotation.eulerAngles.z, walls)).ToArray();
        if (objects.Length == 0)
        {
            return null;
        }

        Collider2D closestObject = objects[0];
        float lowestDistance = (transform.position - objects[0].transform.position).magnitude;
        foreach (Collider2D collider in objects)
        {
            float currentDistance = (transform.position - collider.transform.position).magnitude;
            if (currentDistance < lowestDistance)
            {
                closestObject = collider;
                lowestDistance = currentDistance;
            }
        }

        return closestObject.gameObject;
    }

    private void DragEnemy(GameObject enemy)
    {
        targetObject.GetComponent<IEnemyMovement>().SetMovementEnabled(false);
        dragging = true;
    }

    private void ApproachTarget(GameObject target)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        approaching = true;
    }
}
