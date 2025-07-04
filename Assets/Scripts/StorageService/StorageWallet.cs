using Newtonsoft.Json;

public class StorageWallet
{
    [JsonProperty("money")]
    public int Money { get; private set; }
    [JsonProperty("exp")]
    public int Experience { get; private set; }

    public void EnterData(int money, int experience)
    {
        Money = money;
        Experience = experience;
    }
}
