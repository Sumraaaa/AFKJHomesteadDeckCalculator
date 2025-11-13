using UnityEngine;

public class ForgeCard : Card
{
    public bool isArtisan = false;

    public override void OnActivation(HomesteadManager manager)
    {
        if (isArtisan)
            manager.ArtisanTriggered();
        base.OnActivation(manager);
    }
}
