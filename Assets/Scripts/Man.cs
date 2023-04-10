using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    public string type;
    public GameObject model;
    [SerializeField] public List<Dialogue> dialogues;
    public string notInterestedText;
    public ItemType itemToGive;
    public string itemToGiveText;
    public string thankText;
    public static Vector3? previousSeducedPosition = null;

    private void Awake()
    {
        if (previousSeducedPosition != null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = (Vector3)previousSeducedPosition;
            previousSeducedPosition = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetSeducedPosition(Vector3 position)
    {
        previousSeducedPosition = position;
    }
}
