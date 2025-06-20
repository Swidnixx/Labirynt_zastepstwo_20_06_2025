public class Freez : PickUp
{
    public int freezTime = 10;
    public override void Picked()
    {
        GameManager.gameManager.FreezTime(freezTime);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}