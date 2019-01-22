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
        CountTrueTime();
        DeleteDust();
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
        dustStayTimeCount = 0.0f;
        gameObject.layer = LayerMask.NameToLayer("AliveDust");
        audioSource.PlayOneShot(fallinDustSound);
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
                audioSource.PlayOneShot(hitDustSound);
            }
        
            if (_object.gameObject.CompareTag("IncineratorBottom"))
            {
                if (GameSceneManager.Instance.GetGameState() == GameState.Play)
                {
                    audioSource.PlayOneShot(hitDustSound);
                    CountManager.Instance.GameTrashAdd();
                }

            }
        }
        
        firstHit = true;
    }

    private void OnDisable()
    {
        transform.position = initPosition;
    }

}