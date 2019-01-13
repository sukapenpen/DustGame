using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField]
    private AudioClip fallinDustSound;
    [SerializeField]
    private AudioClip hitDustSound;
    
    private AudioSource audioSource;
    private bool firstHit;
    private float dustBoxStayTimeCount;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        firstHit = false;
        dustBoxStayTimeCount = 0.0f;
    }

    private void Start()
    {
        audioSource.PlayOneShot(fallinDustSound);
    }

    private void OnCollisionEnter(Collision obj)
    {
        if (!firstHit && obj.gameObject.CompareTag("DustBox"))
        {
            audioSource.PlayOneShot(hitDustSound);
            firstHit = true;
        }
    }

    /*
    private void OnCollisionStay()
    {
        
    }
    */
}