using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField]
    private AudioClip fallinDustSound;
    [SerializeField]
    private AudioClip hitDustSound;
    
    private AudioSource audioSource;
    private Vector3 initPosition;
    private bool firstHit;
    private bool hitObject;
    private float dustStayTimeCount;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        initPosition = transform.position;
    }

    private void OnEnable()
    {
        ResetObject();
    }

    private void Update()
    {
        if (hitObject)
        {
            dustStayTimeCount += Time.deltaTime;
        }

        if (dustStayTimeCount >= 5.0f)
        {
            this.gameObject.SetActive(false);
        }

    }

    private void ResetObject()
    {
        firstHit = false;
        dustStayTimeCount = 0.0f;
        gameObject.layer = LayerMask.NameToLayer("AliveDust");
        audioSource.PlayOneShot(fallinDustSound);
    }

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Plane"))
        {
            gameObject.layer = LayerMask.NameToLayer("DeadDust");
        }
        
        hitObject = true;
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (!firstHit && obj.gameObject.CompareTag("DustBoxBottom"))
        {
            audioSource.PlayOneShot(hitDustSound);
        }

        firstHit = true;
    }

    private void OnDisable()
    {
        transform.position = initPosition;
    }

}