[System.Serializable]
public class SaveData {
    public int lives;
    public int bombs;
    public string stageName;
    public int fileNumber;

    public SaveData (Player player, string stageName, int fileNumber) {
        this.lives = player.lives;
        this.bombs = player.bombs.Count;
        this.stageName = stageName;
        this.fileNumber = fileNumber;
    }
}