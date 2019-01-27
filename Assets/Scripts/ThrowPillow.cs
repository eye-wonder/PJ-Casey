using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPillow : MonoBehaviour
{
    [SerializeField]
    private KeyCode _recallKey = KeyCode.F;

    [SerializeField]
    private Vector2 _forceApplied = new Vector2(5f, 5f);

    [SerializeField]
    private Vector2 _spawnPositionOffset = new Vector2(1f, 0.5f);

    [SerializeField]
    private Transform _pillowPrefab;

    [SerializeField]
    private bool _facingRight; // This needs to be hooked up to the player later
    private bool _pillowExists;

    [SerializeField]
    private bool _pillowComingBack;

    [Header("Arc")]
    [SerializeField]
    private LaunchArcRenderer arcRenderer;
    [SerializeField]
    private Material arcYes;
    [SerializeField]
    private Material arcNo;

    private Transform pillow;

    private Animator animator;

    private void Awake()
    {
        _pillowExists = false;
    }

    private void Start()
    {
        if (!arcRenderer) { this.GetComponentInChildren<LaunchArcRenderer>(); }
        _facingRight = this.GetComponent<Player>().movingRight;
        arcRenderer.RenderArc(new Vector2(0f, 0f), 10, 0, 0);
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        
        _facingRight = this.GetComponent<Player>().movingRight;
        _forceApplied = this.GetComponent<Player>().throwVectorXY * this.GetComponent<Player>().throwStrength * Camera.main.orthographicSize;


        ReturnPillowOnKeyPress();


        //Render Arc preview
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("iswalking", false);
            animator.SetBool("isThrowing", true);
            this.GetComponent<Player>().canMove = false;


            //make the line green if you can throw, red otherwise
            if (_pillowExists)
            {
                arcRenderer.GetComponent<LineRenderer>().material = arcNo;
            }
            else
            {
                arcRenderer.GetComponent<LineRenderer>().material = arcYes;
            }

            //render arc right
            if (_facingRight && _forceApplied.x >= 0)
            {
                arcRenderer.gameObject.SetActive(true);
                arcRenderer.RenderArc(new Vector2(_forceApplied.x, _forceApplied.y), 10, transform.position.x + _spawnPositionOffset.x, transform.position.y + _spawnPositionOffset.y);

                
            }
            //render arc left
            else if (!_facingRight && _forceApplied.x < 0)
            {
                arcRenderer.gameObject.SetActive(true);
                arcRenderer.RenderArc(new Vector2(_forceApplied.x, _forceApplied.y), 10, transform.position.x - _spawnPositionOffset.x, transform.position.y + _spawnPositionOffset.y);
            }
            //disable arc render
            else
            {
                arcRenderer.gameObject.SetActive(false);
            }
        }

        //Throw pillow
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isThrowing", false);
            animator.SetBool("hasPillow", false);
            this.GetComponent<Player>().canMove = true;

            if ((_facingRight && _forceApplied.x >= 0) && !_pillowExists) // Facing Right
            {
                pillow = Instantiate(_pillowPrefab,
                                     new Vector3((transform.position.x + _spawnPositionOffset.x), (transform.position.y + _spawnPositionOffset.y), 0),
                                     Quaternion.identity);

                pillow.GetComponent<ThrowMe>().Throw(_forceApplied);

                _pillowExists = true;
            }

            else if ((!_facingRight && _forceApplied.x < 0) && !_pillowExists) // Facing Left
            {
                pillow = Instantiate(_pillowPrefab,
                                     new Vector3((transform.position.x - _spawnPositionOffset.x), (transform.position.y + _spawnPositionOffset.y), 0),
                                     Quaternion.identity);

                pillow.GetComponent<ThrowMe>().Throw(new Vector2(_forceApplied.x, _forceApplied.y));

                _pillowExists = true;
            }

            arcRenderer.gameObject.SetActive(false);
        }
    }


    public void ReturnPillowOnKeyPress()
    {
        if(Input.GetKeyDown(_recallKey) && !_pillowComingBack && _pillowExists)
        {
            _pillowComingBack = true;
            pillow.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetBool("isThrowing", false);
        }

        if (_pillowComingBack)
        {
            //if the pillow has returned to you, destroy it
            if (Vector3.Distance(this.gameObject.transform.position, pillow.transform.position) < 1.0f)
            {
                Destroy(pillow.gameObject);
                _pillowExists = false;
                _pillowComingBack = false;
                animator.SetBool("hasPillow", true);

            }
            else //move it towards you
            {
                pillow.position = Vector3.MoveTowards(pillow.position, this.transform.position, 0.3f);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(_recallKey) && other.tag == "Pillow")
        {
            Destroy(other.gameObject);
            _pillowExists = false;
        }
    }
}
