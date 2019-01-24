using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField]
    private AudioClip fallinDustSound;
    [SerializeField]
    private AudioClip hitDustBoxSound;
    [SerializeField]
    private AudioClip hitIncineratorSound;
    
    private AudioSource audioSource;
    private Vector3 initPosition;
    private bool firstHit;
    private float dustStayTimeCount;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        initPosition = transform.position;
        ResetObject();
    }

    private void OnEnable()
    {
        audioSource.PlayOneShot(fallinDustSound);
    }

    private void Update()
    {
        CountTrueTime();
        DeleteDust();
    }
    
    private void OnDisable()
    {
        ResetObject();
    }

    private void CountTrueTime()
    {
        if (firstHit)
        {
            dustStayTimeCount += Time.deltaTime;
        }
    }

    private void DeleteDust()
    {
        if (dustStayTimeCount >= 4.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void ResetObject()
    {
        firstHit = false;
        transform.position = initPosition;
        dustStayTimeCount = 0.0f;
        gameObject.layer = LayerMask.NameToLayer("AliveDust");
    }

    private void OnCollisionEnter(Collision _object)
    {
        if (_object.gameObject.CompareTag("Plane"))
        {
            gameObject.layer = LayerMask.NameToLayer("DeadDust");
            Debug.Log("Plane更新");
        }        
    }

    private void OnTriggerEnter(Collider _object)
    {
        if (!firstHit)
        {
            if (_object.gameObject.CompareTag("DustBoxBottom"))
            {
                audioSource.PlayOneShot(hitDustBoxSound);
            }
        
            if (_object.gameObject.CompareTag("IncineratorBottom"))
            {
                if (GameSceneManager.Instance.GetGameState() == GameState.Play)
                {
                    audioSource.PlayOneShot(hitIncineratorSound);
                    CountManager.Instance.GameTrashAdd();
                }

            }
        }
        
        firstHit = true;
    }

}