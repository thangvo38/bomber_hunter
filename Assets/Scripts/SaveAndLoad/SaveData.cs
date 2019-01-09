[System.Serializable]
public class SaveData {
    public int lives;
    public int bombs;
    public string stageName;
    public int fileNumber;

    public SaveData (int lives, int bombs, string stageName, int fileNumber) {
        this.lives = lives;
        this.bombs = bombs;
        this.stageName = stageName;
        this.fileNumber = fileNumber;
    }
}