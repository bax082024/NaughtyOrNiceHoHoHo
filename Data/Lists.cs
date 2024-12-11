using System.ComponentModel;

namespace Lists
{
  public class Lists
  {
    private List<string> NiceMusicGenre = new List<string>();

    public void AddGenre(string genre)
    {
      NiceMusicGenre.Add("Punk");
      NiceMusicGenre.Add("Synthpop");
      NiceMusicGenre.Add("Reggae");
      NiceMusicGenre.Add("Salsa");
      NiceMusicGenre.Add("Opera");
      NiceMusicGenre.Add("K-pop");
    }

    private List<string> NiceCarModel = new List<string>();

    public void AddCar(string model)
    {
      NiceCarModel.Add("Tesla");
      NiceCarModel.Add("Mercedes");
      NiceCarModel.Add("Nissan leaf");
      NiceCarModel.Add("Kia Optima");
      NiceCarModel.Add("Ford Focus");
    }
  }
}