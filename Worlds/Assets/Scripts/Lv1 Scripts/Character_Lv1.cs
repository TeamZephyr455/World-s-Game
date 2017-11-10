using System.Collections;
using UnityEngine;

public abstract class Character_Lv1 : MonoBehaviour
{
    public Animator myAnimator { get; private set; }

    [SerializeField]
    protected Transform FirePos;

    [SerializeField]
    protected int Health;

    public abstract bool IsDead { get; }

    [SerializeField]
    protected float movespeed;

    protected bool faceright;

    public bool Attack { get; set; }

    [SerializeField]
    protected GameObject FireBulletPrefab;

    // Use this for initialization
    public virtual void Start()
    {
        faceright = true;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDirection()
    {
        faceright = !faceright;

        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * 1, transform.localScale.z * 1);

    }

    public virtual void ShootFire(int value)
    {
        if (faceright)
        {
            GameObject tmp = (GameObject)Instantiate(FireBulletPrefab, transform.position, Quaternion.identity);
            tmp.GetComponent<FireBullet>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(FireBulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, -180, 0)));
            tmp.GetComponent<FireBullet>().Initialize(Vector2.left);
        }
    }

    public abstract IEnumerator TakeDamage();

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fire")
        {
            StartCoroutine(TakeDamage());
        }
    }
}
