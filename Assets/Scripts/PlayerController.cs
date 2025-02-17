using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public Animator animator;
    public Transform cameraTransform;
    public float mouseSensitivity = 2f;
    public float attackRange = 2f;
    public LayerMask attackableLayer;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float cameraPitch = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleCameraRotation();
        HandleMovement();
        HandleAttack();
    }

    void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -89f, 89f);

        cameraTransform.localEulerAngles = new Vector3(cameraPitch, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * moveZ + right * moveX).normalized;

        if (moveDirection.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        animator.SetBool("IsWalking", moveDirection.magnitude > 0);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            animator.SetTrigger("Attack");
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward * attackRange, 1f, attackableLayer);
        foreach (Collider hitCollider in hitColliders)
        {
            DamageableBox damageable = hitCollider.GetComponent<DamageableBox>();
            if (damageable != null)
            {
                damageable.TakeDamage();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * attackRange, 1f);
    }
}