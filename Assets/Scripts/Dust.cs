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
        initPosition = this.transform.position;
    }

    private void OnEnable()
    {
        firstHit = false;
        dustStayTimeCount = 0.0f;
        audioSource.PlayOneShot(fallinDustSound);
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

    private void OnCollisionEnter(Collision obj)
    {
        if (!firstHit && obj.gameObject.CompareTag("DustBox"))
        {
            audioSource.PlayOneShot(hitDustSound);
            firstHit = true;
        }

        hitObject = true;
    }

    private void OnDisable()
    {
        transform.position = initPosition;
    }

}