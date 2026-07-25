using UnityEngine;

public class Medium : MonoBehaviour
{
    public MediumData mediumData;
    public MediumState mediumState;

    void Awake()
    {
        mediumState = new MediumState(mediumData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
